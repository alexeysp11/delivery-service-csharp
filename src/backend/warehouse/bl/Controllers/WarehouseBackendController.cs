using System.Text;
using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Extensions;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.Delivery;
using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Models.Business.Processes;
using Cims.WorkflowLib.Models.Network;
using DeliveryService.Core.Contexts;

namespace DeliveryService.WarehouseBackendBL.Controllers
{
    /// <summary>
    /// Backend service controller that serves requests from the warehouse employees.
    /// </summary>
    public class WarehouseBackendController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public WarehouseBackendController(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        #region preprocessorder
        /// <summary>
        /// Method for determining the first action of personnel to process an order: for example, 1) transfer ingredients 
        /// from the warehouse to the kitchen or 2) create an order for the delivery of missing ingredients from the store 
        /// to the warehouse.
        /// </summary>
        public string PreprocessOrderRedirect(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.PreprocessOrderRedirect: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);

                // Get ingredients amount from DB.
                bool isSufficient = true;

                // Find corresponding records in the DeliveryOrderProduct table by order ID (a table of associations between 
                // the Product, DeliveryOrder and Quantity).
                var deliveryOrderProducts = context.DeliveryOrderProducts
                    .Include(x => x.Product)
                    .Include(x => x.DeliveryOrder)
                    .Where(x => x.DeliveryOrder.Id == model.Id);
                var productIds = (from product in deliveryOrderProducts select product.Product.Id).ToList();

                // Using product IDs from the order, find the corresponding products in the WHProduct warehouse. It will be more 
                // relevant for those products that need to be stored in a warehouse in finished form (for example, drinks, snacks).
                // var whproducts = context.WHProducts.Where(x => productIds.Any(pid => pid == x.Product.Id));

                // Using the product IDs from the Product order, find the corresponding records in the Ingredients table (look 
                // at the link to the object FinalProduct). This will allow you to find:
                //     1) corresponding records in the Recipes table (if it is necessary to check the relevance of the recipe 
                // by the BusinessEntityStatus value);
                //     2) products that correspond to the ingredient (look at the link to the IngredientProduct object).
                var ingredients = context.Ingredients
                    .Include(x => x.IngredientProduct)
                    .Include(x => x.FinalProduct)
                    .Where(x => productIds.Any(pid => pid == x.FinalProduct.Id));
                var ingredientProductIds = (from ingredient in ingredients select ingredient.IngredientProduct.Id).ToList();

                // Pseudo-randomly select executors from the warehouse and courier delivery departments.
                var rand = new System.Random();
                var responsibleEmployees = new Dictionary<string, Employee>();
                var userGroupNames = new List<string>() { "warehouse employee", "courier" };
                foreach (var userGroupName in userGroupNames)
                {
                    var userGroup = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == userGroupName);
                    if (userGroup == null)
                        throw new System.Exception("Specified user group is not defined");

                    var userAccountIds = (from userAccount in userGroup.Users select userAccount.Id).ToList();
                    var potentialExecutors = 
                        (from employee in context.Employees 
                        where employee.UserAccounts != null && employee.UserAccounts.Any(ua => userAccountIds.Contains(ua.Id))
                        select employee).ToList();
                    if (potentialExecutors == null || !potentialExecutors.Any())
                        throw new System.Exception("The list of potential executors is null or empty");
                    
                    var selectedEmployee = potentialExecutors[rand.Next(potentialExecutors.Count)];
                    if (selectedEmployee == null)
                        throw new System.Exception("Randomly selected employee is null");
                    
                    responsibleEmployees.Add(userGroupName, selectedEmployee);
                }
                var whEmployee = responsibleEmployees[userGroupNames[0]];
                var courierEmployee = responsibleEmployees[userGroupNames[1]];

                // Based on product IDs and corresponding ingredients, you can:
                //     1) find the corresponding products in the WHProduct warehouse;
                //     2) create a product transfer ProductTransfer, specifying the quantity DeliveryOrderProduct.Quantity as 
                // QuantityDelta (all other fields must also be filled in);
                //     3) subtract the quantity DeliveryOrderProduct.Quantity from the quantity of products in the warehouse 
                // WHProduct.Quantity multiplied by Ingredient.Quantity;
                //     4) compare the number of products that are currently in stock with the minimum quantity WHProduct.MinQuantity:
                //             - if WHProduct.Quantity is greater than or equal to WHProduct.MinQuantity, then deliver from the 
                // warehouse to the kitchen;
                //             - if WHProduct.Quantity is less than WHProduct.MinQuantity, then create DeliveryOrder and 
                // DeliveryOrderProduct objects in order to order delivery from the store (the quantity of each product in the order 
                // is equal to the delta between the actual current value of WHProduct.Quantity and the average of WHProduct.MinQuantity 
                // and WHProduct.MaxQuantity).
                // Attention: Point 4 (see the general description of working with data structures) does not take into account 
                // a situation that can slow down the business process of order processing if WHProduct.Quantity is less than 
                // WHProduct.MinQuantity and greater than zero.
                // In this case, it is necessary to both start the delivery process from the warehouse to the kitchen and order 
                // delivery from the store.
                var whingredients = context.WHProducts
                    .Include(x => x.Product)
                    .Where(x => ingredientProductIds.Any(pid => pid == x.Product.Id));
                var deliveryOrderStore2Wh = new DeliveryOrder
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    ParentDeliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id),
                    CustomerUid = whEmployee.Uid,
                    CustomerName = whEmployee.FullName,
                    OrderCustomerType = OrderCustomerType.Employee,
                    ExecutorUid = courierEmployee.Uid,
                    ExecutorName = courierEmployee.FullName,
                    OrderExecutorType = OrderExecutorType.Employee,
                    Destination = model.Origin,
                    OpenOrderDt = System.DateTime.Now
                };
                var deliveryOrderProductsStore2Wh = new List<DeliveryOrderProduct>();
                foreach (var whingredient in whingredients)
                {
                    var ingredient = ingredients.FirstOrDefault(x => x.IngredientProduct.Id == whingredient.Product.Id);
                    if (ingredient == null)
                        throw new System.Exception("Specified ingredient does not exist in the collection");
                    
                    var deliveryOrderProduct = deliveryOrderProducts.FirstOrDefault(x => x.Product.Id == ingredient.FinalProduct.Id);
                    if (deliveryOrderProduct == null)
                        throw new System.Exception("Specified IngredientProduct does not exist in the DeliveryOrderProducts collection");
                    
                    var qtyDelta = deliveryOrderProduct.Quantity * ingredient.Quantity;
                    var productTransfer = new ProductTransfer
                    {
                        Uid = System.Guid.NewGuid().ToString(),
                        WHProduct = whingredient,
                        DeliveryOrderProduct = deliveryOrderProduct,
                        DeliveryOrder = deliveryOrderProduct.DeliveryOrder,
                        Date = System.DateTime.Now,
                        OldQuantity = whingredient.Quantity,
                        NewQuantity = whingredient.Quantity - qtyDelta,
                        QuantityDelta = qtyDelta
                    };
                    whingredient.Quantity = (int)productTransfer.NewQuantity;
                    if (whingredient.Quantity < whingredient.MinQuantity)
                    {
                        isSufficient = false;
                        var whingredientLimits = new List<int> { whingredient.MinQuantity, whingredient.MaxQuantity };
                        var deliveryOrderProductStore2Wh = new DeliveryOrderProduct
                        {
                            Uid = System.Guid.NewGuid().ToString(),
                            Product = whingredient.Product,
                            DeliveryOrder = deliveryOrderStore2Wh,
                            Quantity = (int)whingredientLimits.Average() - whingredient.Quantity
                        };
                        deliveryOrderProductsStore2Wh.Add(deliveryOrderProductStore2Wh);
                    }
                    context.ProductTransfers.Add(productTransfer);
                }
                if (!isSufficient)
                {
                    deliveryOrderStore2Wh.ProductsPrice = deliveryOrderProductsStore2Wh.Sum(x => x.Product.Price * x.Quantity);
                    context.DeliveryOrders.Add(deliveryOrderStore2Wh);
                    context.DeliveryOrderProducts.AddRange(deliveryOrderProductsStore2Wh);
                }
                System.Console.WriteLine($"isSufficient : {isSufficient}");
                context.SaveChanges();

                // Calculte delivery time.
                var wh2kitchenDuration = new System.TimeSpan(0, 5, 0);
                var kitchen2whDuration = new System.TimeSpan(0, 5, 0);
                var store2whDuration = new System.TimeSpan(0, 15, 0);
                var preparemealDuration = new System.TimeSpan(0, 15, 0);
                var resultDuration = wh2kitchenDuration + kitchen2whDuration + preparemealDuration;

                // Start creating tasks for employees as part of order processing, preparation and delivery. 
                // - If the amount of products/ingredients is sufficient, then invoke wh2kitchen.
                // - Otherwise, invoke requeststore2wh.
                if (isSufficient)
                {
                    response = Wh2KitchenStart(model);
                }
                else
                {
                    resultDuration += store2whDuration;
                    response = RequestStore2WhStart(deliveryOrderStore2Wh);
                }
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.PreprocessOrderRedirect: end");
            return response;
        }
        #endregion  // preprocessorder

        #region store2wh
        /// <summary>
        /// A method that allows you to begin the process of delivering products from the store to the warehouse.
        /// </summary>
        public string RequestStore2WhStart(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.RequestStore2WhStart: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.RequestStore2WhStart: update DB");
                
                // Getting the products that should be delivered.
                var deliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id);
                if (deliveryOrder == null)
                    throw new System.Exception($"Delivery order could not be null (delivery order ID: {model.Id})");
                var deliveryOrderProducts = context.DeliveryOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.DeliveryOrder.Id == model.Id && x.Product != null);
                if (deliveryOrderProducts.Count() == 0)
                    throw new System.Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {model.Id})");
                
                // Get sender and receiver of the notification.
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new System.Exception("Admin user could not be null");
                var warehouseEmployee = GetWarehouseEmployeeRandomly();

                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append("RequestStore2Wh: request delivery of order #").Append(model.Id.ToString()).Append(" from the store to the warehouse");
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();

                // Body text.
                sbMessageText.Append("Please be informed that you are responsible for requesting delivery of order #");
                sbMessageText.Append(model.Id.ToString());
                sbMessageText.Append(" from the store to the warehouse.\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("The system automatically determined that the warehouse is short of the following products:\n");
                foreach (var deliveryOrderProduct in deliveryOrderProducts)
                {
                    sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                    sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
                }
                sbMessageText.Append("\n");
                sbMessageText.Append("Please check that the list of products required for delivery is correct and confirm your request.\n");

                // Notify warehouse employee.
                System.Console.WriteLine("WarehouseBackend.RequestStore2WhStart: notify employee");
                var notification = new Notification
                {
                    SenderId = adminUser.Id,
                    ReceiverId = warehouseEmployee.Id,
                    TitleText = titleText,
                    BodyText = sbMessageText.ToString()
                };
                // new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                // {
                //     notification
                // });

                // Create a business task for requesting delivery of order from the store to the warehouse.
                var businessTask = new BusinessTask
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Name = notification.TitleText,
                    Subject = notification.TitleText,
                    Description = notification.BodyText,
                    Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Open)
                };
                var businessTaskDeliveryOrder = new BusinessTaskDeliveryOrder
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    BusinessTask = businessTask,
                    DeliveryOrder = deliveryOrder,
                    Discriminator = EnumExtensions.GetDisplayName(BusinessTaskDiscriminator.RequestStore2Wh)
                };
                context.BusinessTasks.Add(businessTask);
                context.BusinessTaskDeliveryOrders.Add(businessTaskDeliveryOrder);
                context.SaveChanges();

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.RequestStore2WhStart: end");
            return response;
        }

        /// <summary>
        /// A method that allows you to request the start of the process of delivering products from the store to the warehouse.
        /// </summary>
        public string RequestStore2WhRespond(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.RequestStore2WhRespond: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.RequestStore2WhRespond: cache");

                // The BusinessTask and DeliveryOrder classes are connected using the BusinessTaskDeliveryOrder class,
                // so get the collection of business task objects that are related to the delivery order.
                var deliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id);
                if (deliveryOrder == null)
                    throw new System.Exception($"Delivery order could not be null (delivery order ID: {model.Id})");
                var businessTasks = context.BusinessTaskDeliveryOrders
                    .Where(x => x.BusinessTask != null 
                        && x.DeliveryOrder != null 
                        && x.Discriminator == EnumExtensions.GetDisplayName(BusinessTaskDiscriminator.RequestStore2Wh)
                        && x.DeliveryOrder.Id == model.Id)
                    .Select(x => x.BusinessTask);
                if (businessTasks == null || !businessTasks.Any())
                    throw new System.Exception($"The collection of BusinessTask objects could not be null or empty (delivery order ID: {model.Id})");
                
                // Iterate through the entire collection of business tasks and "close" each of them 
                // by setting Status to Closed.
                foreach (var businessTask in businessTasks)
                {
                    businessTask.Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Closed);
                }

                // Change the status of the corresponding delivery order.
                deliveryOrder.Status = EnumExtensions.GetDisplayName(OrderStatus.Requested);
                context.SaveChanges();

                // Send HTTP request.
                // string backendResponse = new CourierBackendController(_contextOptions).Store2WhStart(new ApiOperation
                // {
                //     RequestObject = deliveryOrder
                // });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.RequestStore2WhRespond: end");
            return response;
        }
        #endregion  // requeststore2wh
        
        #region store2wh
        /// <summary>
        /// A method that allows you to save the value of an incoming parameter 
        /// as part of the process of delivering products from the store to the warehouse. 
        /// </summary>
        public string Store2WhSave(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Store2WhSave: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Store2WhSave: cache");

                // Send HTTP request.
                // string backendResponse = new WarehouseClientController(_contextOptions).Store2WhSave(new ApiOperation
                // {
                //     RequestObject = model
                // });
                
                // Getting the products that should be delivered.
                var deliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id);
                var deliveryOrderProducts = context.DeliveryOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.DeliveryOrder.Id == model.Id && x.Product != null);
                if (deliveryOrderProducts.Count() == 0)
                    throw new System.Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {model.Id})");
                
                // Get sender and receiver of the notification.
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new System.Exception("Admin user could not be null");
                var warehouseEmployee = GetWarehouseEmployeeRandomly();
                
                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append("ConfirmStore2Wh: confirm delivery of order #").Append(model.Id.ToString()).Append(" from the store to the warehouse");
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();

                // Body text.
                sbMessageText.Append("Please be informed that you are responsible for confirming delivery of order #");
                sbMessageText.Append(model.Id.ToString());
                sbMessageText.Append(" from the store to the warehouse.\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Products for delivery:\n");
                foreach (var deliveryOrderProduct in deliveryOrderProducts)
                {
                    sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                    sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
                }

                // Notify warehouse employee.
                var notification = new Notification
                {
                    SenderId = adminUser.Id,
                    ReceiverId = warehouseEmployee.Id,
                    TitleText = titleText,
                    BodyText = sbMessageText.ToString()
                };
                // new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                // {
                //     notification
                // });

                // Create a business task for requesting delivery of order from the store to the warehouse.
                var businessTask = new BusinessTask
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Name = notification.TitleText,
                    Subject = notification.TitleText,
                    Description = notification.BodyText,
                    Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Open)
                };
                var businessTaskDeliveryOrder = new BusinessTaskDeliveryOrder
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    BusinessTask = businessTask,
                    DeliveryOrder = deliveryOrder,
                    Discriminator = EnumExtensions.GetDisplayName(BusinessTaskDiscriminator.ConfirmStore2Wh)
                };
                context.BusinessTasks.Add(businessTask);
                context.BusinessTaskDeliveryOrders.Add(businessTaskDeliveryOrder);
                context.SaveChanges();

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.Store2WhSave: end");
            return response;
        }
        #endregion  // store2wh

        #region confirmstore2wh
        /// <summary>
        /// A method that is responsible for confirming the delivery of products from the store to the warehouse.
        /// </summary>
        public string ConfirmStore2WhAccept(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.ConfirmStore2WhAccept: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.ConfirmStore2WhAccept: cache");

                // Close the business task that is related to the delivery order passed as a parameter.
                var deliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id);
                if (deliveryOrder == null)
                    throw new System.Exception($"Delivery order could not be null (delivery order ID: {model.Id})");
                var businessTasks = context.BusinessTaskDeliveryOrders
                    .Where(x => x.BusinessTask != null 
                        && x.DeliveryOrder != null 
                        && x.Discriminator == EnumExtensions.GetDisplayName(BusinessTaskDiscriminator.ConfirmStore2Wh)
                        && x.DeliveryOrder.Id == model.Id)
                    .Select(x => x.BusinessTask);
                if (businessTasks == null || !businessTasks.Any())
                    throw new System.Exception($"The collection of BusinessTask objects could not be null or empty (delivery order ID: {model.Id})");
                
                // Iterate through the entire collection of business tasks and "close" each of them 
                // by setting Status to Closed.
                foreach (var businessTask in businessTasks)
                {
                    businessTask.Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Closed);
                }

                // Change the status of the corresponding delivery order.
                deliveryOrder.CloseOrderDt = System.DateTime.Now;
                deliveryOrder.Status = EnumExtensions.GetDisplayName(OrderStatus.Finished);

                // Get the parent delivery order that should be delivered from the warehouse to the kitchen.
                var parentDeliveryOrder = context.DeliveryOrders
                    .Where(x => x.Id == model.Id)
                    .Select(x => x.ParentDeliveryOrder)
                    .FirstOrDefault();
                if (parentDeliveryOrder == null)
                    throw new System.Exception("Parent delivery order could not be null");
                parentDeliveryOrder.Status = EnumExtensions.GetDisplayName(OrderStatus.InProcess);
                context.SaveChanges();
                
                // Start the step for delivering from warehouse to kitchen.
                response = Wh2KitchenStart(parentDeliveryOrder);
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.ConfirmStore2WhAccept: end");
            return response;
        }
        #endregion  // confirmstore2wh
        
        #region wh2kitchen
        /// <summary>
        /// A method that allows you to begin the process of delivering products and ingredients from the warehouse to the kitchen.
        /// </summary>
        public string Wh2KitchenStart(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenStart: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Wh2KitchenStart: cache");
                
                // Getting the products that should be delivered.
                var deliveryOrderProducts = context.DeliveryOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.DeliveryOrder.Id == model.Id && x.Product != null);
                if (deliveryOrderProducts.Count() == 0)
                    throw new System.Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {model.Id})");
                
                // Get sender and receiver of the notification.
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new System.Exception("Admin user could not be null");
                var warehouseEmployee = GetWarehouseEmployeeRandomly();
                
                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append("Wh2Kitchen: deliver order #").Append(model.Id.ToString()).Append(" from the warehouse to the kitchen");
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();
                
                // Body text.
                sbMessageText.Append("Please be informed that you are responsible for shipping order #");
                sbMessageText.Append(model.Id.ToString());
                sbMessageText.Append(" from the warehouse to the kitchen.\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Products for delivery:\n");
                foreach (var deliveryOrderProduct in deliveryOrderProducts)
                {
                    sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                    sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
                }
                
                // Notify warehouse employee.
                var notification = new Notification
                {
                    SenderId = adminUser.Id,
                    ReceiverId = warehouseEmployee.Id,
                    TitleText = titleText,
                    BodyText = sbMessageText.ToString()
                };
                // new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                // {
                //     notification
                // });

                // Create input parameter.
                var initialOrder = context.InitialOrders.FirstOrDefault(x => x.DeliveryOrder.Id == model.Id);
                if (initialOrder == null)
                    throw new System.Exception("Initial order could not be null");
                var initialOrderProducts = context.InitialOrderProducts.Where(x => x.InitialOrder.Id == initialOrder.Id).ToList();
                if (initialOrderProducts == null || !initialOrderProducts.Any())
                    throw new System.Exception("List of products that is related to the initial order could not be null or empty");
                var initialOrderIngredients = context.InitialOrderIngredients.Where(x => x.InitialOrder.Id == initialOrder.Id).ToList();
                if (initialOrderIngredients == null || !initialOrderIngredients.Any())
                    throw new System.Exception("List of ingredients that is related to the initial order could not be null or empty");
                var deliveryWh2Kitchen = new DeliveryWh2Kitchen
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Name = notification.TitleText,
                    Subject = notification.TitleText,
                    Description = notification.BodyText,
                    Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Open),
                    InitialOrders = new List<InitialOrder>() 
                    {
                        initialOrder
                    },
                    InitialOrderProducts = initialOrderProducts,
                    InitialOrderIngredients = initialOrderIngredients
                };
                context.DeliveriesWh2Kitchen.Add(deliveryWh2Kitchen);
                context.SaveChanges();

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenStart: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for carrying out the delivery of ingredients 
        /// from the warehouse to the kitchen as part of processing a delivery order.
        /// </summary>
        public string Wh2KitchenExecute(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenExecute: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Wh2KitchenExecute: cache");

                // Close a business task that is associated with a delivery order.
                var initialOrder = context.InitialOrders
                    .Where(x => x.DeliveryOrder != null && x.DeliveryOrder.Id == model.Id)
                    .FirstOrDefault();
                if (initialOrder == null)
                    throw new System.Exception($"Could not find the initial order (delivery order ID: {model.Id})");
                var deliveryWh2Kitchen = context.DeliveriesWh2Kitchen
                    .Where(x => x.InitialOrders.Any(io => io.Id == initialOrder.Id))
                    .FirstOrDefault();
                if (deliveryWh2Kitchen == null)
                    throw new System.Exception($"Could not find the business task DeliveryWh2Kitchen (delivery order ID: {model.Id})");
                deliveryWh2Kitchen.Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Closed);
                context.SaveChanges();

                // Send HTTP request.
                // string backendResponse = new KitchenBackendController(_contextOptions).PrepareMealStart(new ApiOperation
                // {
                //     RequestObject = model
                // });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.Wh2KitchenExecute: end");
            return response;
        }
        #endregion  // wh2kitchen

        #region kitchen2wh
        /// <summary>
        /// A method that allows you to begin the process of delivering finished products from the kitchen to the warehouse.
        /// </summary>
        public string Kitchen2WhStart(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Kitchen2WhStart: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Kitchen2WhStart: cache");
                
                // Get sender and receiver of the notification.
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new System.Exception("Admin user could not be null");
                var warehouseEmployee = GetWarehouseEmployeeRandomly();

                // Get initial order by delivery order ID.
                var deliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id);
                if (deliveryOrder == null)
                    throw new System.Exception($"Delivery order could not be null (delivery order ID: {model.Id})");
                var initialOrder = context.InitialOrders.FirstOrDefault(x => x.DeliveryOrder.Id == deliveryOrder.Id);
                if (initialOrder == null)
                    throw new System.Exception($"Initial order could not be null (delivery order ID: {model.Id})");

                // Getting the products that should be delivered.
                var deliveryOrderProducts = context.DeliveryOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.DeliveryOrder.Id == model.Id && x.Product != null);
                if (deliveryOrderProducts.Count() == 0)
                    throw new System.Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {model.Id})");

                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append("Kitchen2Wh: deliver order #").Append(model.Id.ToString()).Append(" from the kitchen to the warehouse");
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();
                
                // Body text.
                sbMessageText.Append("Please be informed that you are responsible for shipping order #");
                sbMessageText.Append(model.Id.ToString());
                sbMessageText.Append(" from the kitchen to the warehouse.\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Products for delivery:\n");
                foreach (var deliveryOrderProduct in deliveryOrderProducts)
                {
                    sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                    sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
                }

                // Notify warehouse employee.
                var notification = new Notification
                {
                    SenderId = adminUser.Id,
                    ReceiverId = warehouseEmployee.Id,
                    TitleText = titleText,
                    BodyText = sbMessageText.ToString()
                }; 
                // new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                // {
                //     notification
                // });
                
                // Create DeliveryKitchen2Wh object.
                var deliveryKitchen2Wh = new DeliveryKitchen2Wh
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Name = notification.TitleText,
                    Subject = notification.TitleText,
                    Description = notification.BodyText,
                    InitialOrders = new List<InitialOrder>
                    {
                        initialOrder
                    },
                    Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Open)
                };
                context.DeliveriesKitchen2Wh.Add(deliveryKitchen2Wh);
                context.SaveChanges();

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.Kitchen2WhStart: end");
            return response;
        }

        /// <summary>
        /// A method that is responsible for controlling the delivery of finished products from the kitchen to the warehouse.
        /// </summary>
        public string Kitchen2WhExecute(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("WarehouseBackend.Kitchen2WhExecute: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("WarehouseBackend.Kitchen2WhExecute: cache");

                // Close a business task that is associated with a delivery order.
                var initialOrder = context.InitialOrders
                    .Where(x => x.DeliveryOrder != null && x.DeliveryOrder.Id == model.Id)
                    .FirstOrDefault();
                if (initialOrder == null)
                    throw new System.Exception($"Could not find the initial order (delivery order ID: {model.Id})");
                var deliveryKitchen2Wh = context.DeliveriesKitchen2Wh
                    .Where(x => x.InitialOrders.Any(io => io.Id == initialOrder.Id))
                    .FirstOrDefault();
                if (deliveryKitchen2Wh == null)
                    throw new System.Exception($"Could not find the business task DeliveryKitchen2Wh (delivery order ID: {model.Id})");
                deliveryKitchen2Wh.Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Closed);
                context.SaveChanges();

                // Send HTTP request.
                // string backendResponse = new CourierBackendController(_contextOptions).DeliverOrderStart(new ApiOperation
                // {
                //     RequestObject = model
                // });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("WarehouseBackend.Kitchen2WhExecute: end");
            return response;
        }
        #endregion  // kitchen2wh

        /// <summary>
        /// A method that allows you to randomly select a warehouse employee who will be responsible for performing 
        /// an atomic operation as part of processing a delivery order. 
        /// </summary>
        private Employee GetWarehouseEmployeeRandomly()
        {
            using var context = new DeliveringContext(_contextOptions);
            var rand = new System.Random();
            var userGroup = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "warehouse employee");
            if (userGroup == null)
                throw new System.Exception($"Specified user group is not defined");
            var userAccountIds = (from userAccount in userGroup.Users select userAccount.Id).ToList();
            var potentialExecutors = 
                (from employee in context.Employees 
                where employee.UserAccounts != null && employee.UserAccounts.Any(ua => userAccountIds.Contains(ua.Id))
                select employee).ToList();
            if (potentialExecutors == null || !potentialExecutors.Any())
                throw new System.Exception($"The list of potential executors is null or empty");
            var selectedEmployee = potentialExecutors[rand.Next(potentialExecutors.Count)];
            if (selectedEmployee == null)
                throw new System.Exception($"Randomly selected employee is null");
            return selectedEmployee;
        }
    }
}