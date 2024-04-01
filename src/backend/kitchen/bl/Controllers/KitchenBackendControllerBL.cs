using System.Text;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Extensions;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Cooking;
using WorkflowLib.Models.Business.Customers;
using WorkflowLib.Models.Network;
using WorkflowLib.Models.Business.Processes;
using DeliveryService.Core.Contexts;

namespace DeliveryService.Backend.Kitchen.BL.Controllers
{
    /// <summary>
    /// Backend service controller that serves requests from the kitchen employees.
    /// </summary>
    public class KitchenBackendControllerBL
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public KitchenBackendControllerBL(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        #region preparemeal
        /// <summary>
        /// A method that is responsible for storing information necessary for the preparation of an order by kitchen staff.
        /// </summary>
        public string PrepareMealStart(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("KitchenBackend.PrepareMealStart: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Validation.
                System.Console.WriteLine("KitchenBackend.PrepareMealStart: validation");
                
                // Insert into cache.
                System.Console.WriteLine("KitchenBackend.PrepareMealStart: cache");
                
                // Get initial order, and the products that should be delivered, by delivery order ID.
                var deliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id);
                if (deliveryOrder == null)
                    throw new System.Exception($"Delivery order could not be null (delivery order ID: {model.Id})");
                var initialOrder = context.InitialOrders.FirstOrDefault(x => x.DeliveryOrder.Id == deliveryOrder.Id);
                if (initialOrder == null)
                    throw new System.Exception($"Initial order could not be null (delivery order ID: {model.Id})");
                var deliveryOrderProducts = context.DeliveryOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.DeliveryOrder.Id == model.Id && x.Product != null);
                if (deliveryOrderProducts.Count() == 0)
                    throw new System.Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {model.Id})");
                
                // Get sender and receiver of the notification.
                var rand = new System.Random();
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new System.Exception("Admin user could not be null");
                var userGroup = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "kitchen employee");
                if (userGroup == null)
                    throw new System.Exception($"Specified user group is not defined (delivery order ID: {model.Id})");
                var userAccountIds = (from userAccount in userGroup.Users select userAccount.Id).ToList();
                var potentialExecutors = 
                    (from employee in context.Employees 
                    where employee.UserAccounts != null && employee.UserAccounts.Any(ua => userAccountIds.Contains(ua.Id))
                    select employee).ToList();
                if (potentialExecutors == null || !potentialExecutors.Any())
                    throw new System.Exception($"The list of potential executors is null or empty (delivery order ID: {model.Id})");
                var kitchenEmployee = potentialExecutors[rand.Next(potentialExecutors.Count)];
                if (kitchenEmployee == null)
                    throw new System.Exception($"Randomly selected employee is null (delivery order ID: {model.Id})");
                
                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append("PrepareMeal: preparing order #").Append(model.Id.ToString());
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();

                // Body text.
                sbMessageText.Append("Please be informed that you are responsible for preparing order #");
                sbMessageText.Append(model.Id.ToString());
                sbMessageText.Append(".\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Products:\n");
                foreach (var deliveryOrderProduct in deliveryOrderProducts)
                {
                    sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                    sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
                }

                // Send request to the notifications backend.
                var notification = new Notification
                {
                    SenderId = adminUser.Id,
                    ReceiverId = kitchenEmployee.Id,
                    TitleText = titleText,
                    BodyText = sbMessageText.ToString()
                };
                // string notificationsRequest = new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                // {
                //     notification
                // });

                // Create the cooking operation object.
                var cookingOperation = new CookingOperation
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
                context.CookingOperations.Add(cookingOperation);
                context.SaveChanges();
                
                // Insert into cache.
                System.Console.WriteLine("KitchenBackend.PrepareMealStart: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("KitchenBackend.PrepareMealStart: end");
            return response;
        }

        /// <summary>
        /// The method that the kitchen staff is responsible for preparing the order.
        /// </summary>
        public string PrepareMealExecute(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("KitchenBackend.PrepareMealExecute: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);

                // Close a business task that is associated with a delivery order.
                var deliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id);
                if (deliveryOrder == null)
                    throw new System.Exception($"Delivery order could not be null (delivery order ID: {model.Id})");
                var initialOrder = context.InitialOrders.FirstOrDefault(x => x.DeliveryOrder.Id == deliveryOrder.Id);
                if (initialOrder == null)
                    throw new System.Exception($"Initial order could not be null (delivery order ID: {model.Id})");
                var cookingOperation = context.CookingOperations
                    .Where(x => x.InitialOrders.Any(io => io.Id == initialOrder.Id))
                    .FirstOrDefault();
                if (cookingOperation == null)
                    throw new System.Exception($"Could not find the business task CookingOperation (delivery order ID: {model.Id})");
                cookingOperation.Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Closed);
                context.SaveChanges();
                
                // Insert into cache.
                System.Console.WriteLine("KitchenBackend.PrepareMealExecute: cache");

                // Send HTTP request.
                // string backendResponse = new WarehouseBackendController(_contextOptions).Kitchen2WhStart(new ApiOperation
                // {
                //     RequestObject = model
                // });
                
                // Insert into cache.
                System.Console.WriteLine("KitchenBackend.PrepareMealExecute: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("KitchenBackend.PrepareMealExecute: end");
            return response;
        }
        #endregion  // preparemeal
    }
}