using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Cims.WorkflowLib.Extensions;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Models.Network;
using DeliveryService.Core.Contexts;

namespace DeliveryService.Backend.Customer.BL.Controllers
{
    /// <summary>
    /// A class that represents a backend service controller that processes requests from the customer.
    /// </summary>
    public class CustomerBackendControllerBL
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public CustomerBackendControllerBL(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        #region makeorder
        /// <summary>
        /// The method that is responsible for placing an order.
        /// </summary>
        public string MakeOrderRequest(InitialOrder model)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakeOrderRequest: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Validation.
                System.Console.WriteLine("CustomerClient.MakeOrderRequest: validation");

                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakeOrderRequest: cache");
                var initialOrderProducts = new List<InitialOrderProduct>();
                var initialOrderIngredients = new List<InitialOrderIngredient>();
                foreach (var pid in model.ProductIds)
                {
                    if (initialOrderProducts.Any(x => x.Product.Id == pid))
                        continue;
                    
                    int productQty = model.ProductIds.Where(x => x == pid).Count();
                    var product = context.Products.Where(x => x.Id == pid).FirstOrDefault();
                    if (product == null)
                        throw new System.Exception($"Product with the specified ID could not be found (initial order ID: {model.Id}, product ID: {pid})");
                    var initialOrderProduct = new InitialOrderProduct
                    {
                        Uid = System.Guid.NewGuid().ToString(),
                        Name = product.Name,
                        Product = product,
                        InitialOrder = model,
                        Quantity = productQty
                    };
                    initialOrderProducts.Add(initialOrderProduct);

                    var ingredientsTmp = context.Ingredients
                        .Include(x => x.IngredientProduct)
                        .Where(x => x.FinalProduct.Id == product.Id);
                    foreach (var ingredient in ingredientsTmp)
                    {
                        initialOrderIngredients.Add(new InitialOrderIngredient
                        {
                            Uid = System.Guid.NewGuid().ToString(),
                            Name = ingredient.Name,
                            Ingredient = ingredient,
                            InitialOrder = model,
                            InitialOrderProduct = initialOrderProduct,
                            Quantity = productQty * (int)ingredient.Quantity
                        });
                    }
                    
                    model.PaymentAmount += productQty * product.Price;
                }
                model.Uid = System.Guid.NewGuid().ToString();
                context.InitialOrderProducts.AddRange(initialOrderProducts);
                context.InitialOrderIngredients.AddRange(initialOrderIngredients);
                context.InitialOrders.Add(model);
                context.SaveChanges();

                // Validation.
                System.Console.WriteLine("CustomerBackend.MakeOrderRequest: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakeOrderRequest: cache");

                // Invoke makepayment.
                response = MakePaymentStart(model);
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerBackend.MakeOrderRequest: end");
            return response;
        }
        #endregion  // makeorder

        #region makepayment
        /// <summary>
        /// The method that is responsible for starting the electronic payment procedure for an order.
        /// </summary>
        public string MakePaymentStart(InitialOrder model)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakePayment: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Validation.
                System.Console.WriteLine("CustomerBackend.MakePayment: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakePayment: cache");

                // Get payment method.
                if (model.PaymentType == EnumExtensions.GetDisplayName(PaymentType.Card))
                {
                    // Create a form for card details.
                    System.Console.WriteLine("CustomerBackend.MakePayment: form for card details");
                }
                else if (model.PaymentType == EnumExtensions.GetDisplayName(PaymentType.QrCode))
                {
                    // Generate QR code.
                    // string qrResult = new FileServiceController().GenerateQrCode(new ApiOperation()
                    // {
                    //     RequestObject = model
                    // });

                    // Envelope QR code.
                    System.Console.WriteLine("CustomerBackend.MakePayment: envelope qr");
                }
                else
                {
                    throw new System.Exception("Incorrect parameter: PaymentType");
                }

                // Save data into DB.
                var destinationExists = true;
                var destination = context.Addresses.FirstOrDefault(x => x.Name == model.Address);
                if (destination == null)
                {
                    destinationExists = false;
                    destination = new Address
                    {
                        Uid = System.Guid.NewGuid().ToString(),
                        Name = model.Address
                    };
                }
                var organization = context.Organizations
                    .Include(x => x.Company)
                    .Include(x => x.Company.Address)
                    .FirstOrDefault();
                if (organization == null || organization.Company == null)
                    throw new System.Exception("Organization or company is not defined");
                if (organization.Company.Address == null)
                    throw new System.Exception("Address of the company is not specified");
                var customer = context.Customers
                    .Include(x => x.UserAccount)
                    .FirstOrDefault(x => x.UserAccount != null && x.UserAccount.Uid == model.UserUid);
                if (customer == null)
                    throw new System.Exception("Specified customer does not exist in the database");
                var initialOrder = context.InitialOrders.FirstOrDefault(x => x.Id == model.Id);
                if (initialOrder == null)
                    throw new System.Exception("Specified initial order does not exist in the database");
                var deliveryOrder = new DeliveryOrder
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Payments = new List<Payment>
                    {
                        new Payment
                        {
                            Uid = System.Guid.NewGuid().ToString(),
                            PaymentType = model.PaymentType,
                            PaymentMethod = model.PaymentMethod,
                            Amount = model.PaymentAmount,
                            Payer = customer.FullName,
                            Receiver = string.IsNullOrEmpty(organization.Company.Name) ? "Our company" : organization.Company.Name,
                            Status = EnumExtensions.GetDisplayName(PaymentStatus.Requested)
                        }
                    },
                    CustomerUid = customer.Uid,
                    CustomerName = customer.FullName,
                    OrderCustomerType = OrderCustomerType.Customer,
                    ExecutorUid = organization.Company.Uid,
                    ExecutorName = organization.Company.Name,
                    OrderExecutorType = OrderExecutorType.Company,
                    Origin = organization.Company.Address,
                    Destination = destination,
                    OpenOrderDt = System.DateTime.UtcNow
                };
                initialOrder.DeliveryOrder = deliveryOrder;
                context.DeliveryOrders.Add(deliveryOrder);
                if (!destinationExists)
                    context.Addresses.Add(deliveryOrder.Destination);
                context.Payments.AddRange(deliveryOrder.Payments);
                var initialOrderProducts = context.InitialOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.InitialOrder != null && x.InitialOrder.Id == model.Id)
                    .ToList();
                foreach (var iop in initialOrderProducts)
                {
                    var deliveryOrderProduct = new DeliveryOrderProduct
                    {
                        Uid = System.Guid.NewGuid().ToString(),
                        Product = iop.Product,
                        DeliveryOrder = deliveryOrder,
                        Quantity = iop.Quantity
                    };
                    context.DeliveryOrderProducts.Add(deliveryOrderProduct);
                }
                deliveryOrder.ProductsPrice = model.PaymentAmount;
                deliveryOrder.TotalPrice = model.PaymentAmount;
                context.SaveChanges();

                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append("Please, provide your card details to pay for the order #").Append(deliveryOrder.Id.ToString());
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();

                // Body text.
                sbMessageText.Append("Hello,\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("We have just received a request from you to process the order #").Append(deliveryOrder.Id.ToString()).Append(".\n");
                sbMessageText.Append("Please provide us with your card details so that we can complete the payment process for your order.\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Your order will be prepared and delivered after payment.\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Thank you for using our services!");

                // Send request to the notifications backend.
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new System.Exception("Admin user could not be null");
                var notifications = new List<Notification>
                {
                    new Notification
                    {
                        SenderId = adminUser.Id,
                        ReceiverId = customer.UserAccount.Id,
                        TitleText = titleText,
                        BodyText = sbMessageText.ToString()
                    }
                };
                // string notificationsRequest = new NotificationsBackendController(_contextOptions).SendNotifications(notifications);

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakePayment: cache");
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerBackend.MakePayment: end");
            return response;
        }
        
        /// <summary>
        /// The method that is responsible for transmitting information from the client regarding the completed electronic payment.
        /// </summary>
        public string MakePaymentRespond(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.MakePayment: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");

                // Validation.
                System.Console.WriteLine("CustomerBackend.MakePayment: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.MakePayment: cache");

                // Calculate delivery time.
                string preprocessResponse = PreprocessOrderRedirect(model);

                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerBackend.MakePayment: end");
            return response;
        }
        #endregion  // makepayment

        #region preprocessorder
        /// <summary>
        /// A method that redirects a request to pre-process a delivery order.
        /// </summary>
        public string PreprocessOrderRedirect(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                
                // Validation.
                System.Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: validation");

                // Update DB.
                System.Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: cache");

                // Calculate delivery time.
                // var preprocessResponse = new WarehouseBackendController(_contextOptions).PreprocessOrderRedirect(new ApiOperation()
                // {
                //     RequestObject = model
                // });

                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerBackend.PreprocessOrderRedirect: end");
            return response;
        }
        #endregion  // preprocessorder
    }
}