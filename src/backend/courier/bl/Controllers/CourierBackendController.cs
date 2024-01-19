using System.Text;
using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Extensions;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.Delivery;
using Cims.WorkflowLib.Models.Business.Processes;
using Cims.WorkflowLib.Models.Network;
using DeliveryService.Core.Contexts;

namespace DeliveryService.CourierBackendBL.Controllers
{
    /// <summary>
    /// Backend service controller that serves requests from the courier.
    /// </summary>
    public class CourierBackendController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }
        private Notification Notification { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public CourierBackendController(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        #region store2wh
        /// <summary>
        /// A method that allows to save a request for the delivery of products from a store to a warehouse.
        /// </summary>
        public string Store2WhStart(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.Store2WhStart: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);

                // Get the object related to the specified delivery order.
                var deliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id);
                if (deliveryOrder == null)
                    throw new System.Exception($"Delivery order could not be null (delivery order ID: {model.Id})");

                // Update DB.
                System.Console.WriteLine("CourierBackend.Store2WhStart: cache");
                
                // Create a DeliveryOperation object and associate it with the delivery order.
                NotifyDeliverOrder(model, "Store2Wh");
                var deliveryOperation = new DeliveryOperation
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Name = Notification.TitleText,
                    Subject = Notification.TitleText,
                    Description = Notification.BodyText,
                    CustomerName = deliveryOrder.CustomerName,
                    Origin = deliveryOrder.Origin,
                    Destination = deliveryOrder.Destination,
                    Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Open)
                };
                deliveryOrder.DeliveryOperation = deliveryOperation;
                context.DeliveryOperations.Add(deliveryOperation);
                context.SaveChanges();

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierBackend.Store2WhStart: end");
            return response;
        }

        /// <summary>
        /// A method that controls the process of delivering products from the store to the warehouse.
        /// </summary>
        public string Store2WhExecute(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.Store2WhExecute: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("CourierBackend.Store2WhExecute: cache");

                // Close the related business task.
                var deliveryOperation = context.DeliveryOrders
                    .Where(x => x.Id == model.Id && x.DeliveryOperation != null)
                    .Select(x => x.DeliveryOperation)
                    .FirstOrDefault();
                if (deliveryOperation == null)
                    throw new System.Exception("Delivery operation is not defined");
                deliveryOperation.Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Closed);
                context.SaveChanges();

                // Notify warehouse backend controller.
                // string deliveryRequest = new WarehouseBackendController(_contextOptions).Store2WhSave(new ApiOperation()
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
            System.Console.WriteLine("CourierBackend.Store2WhExecute: end");
            return response;
        }
        #endregion  // store2wh

        #region deliverorder
        /// <summary>
        /// The method that is responsible for starting the order delivery process.
        /// </summary>
        public string DeliverOrderStart(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.DeliverOrderStart: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("CourierBackend.DeliverOrderStart: cache");
                
                // Get the object related to the specified delivery order.
                var deliveryOrder = context.DeliveryOrders.FirstOrDefault(x => x.Id == model.Id);
                if (deliveryOrder == null)
                    throw new System.Exception($"Delivery order could not be null (delivery order ID: {model.Id})");

                // Create a DeliveryOperation object and associate it with the delivery order.
                NotifyDeliverOrder(model, "DeliverOrder");
                var deliveryOperation = new DeliveryOperation
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Name = Notification.TitleText,
                    Subject = Notification.TitleText,
                    Description = Notification.BodyText,
                    CustomerName = deliveryOrder.CustomerName,
                    Origin = deliveryOrder.Origin,
                    Destination = deliveryOrder.Destination,
                    Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Open)
                };
                deliveryOrder.DeliveryOperation = deliveryOperation;
                context.DeliveryOperations.Add(deliveryOperation);
                context.SaveChanges();

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierBackend.DeliverOrderStart: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for executing the order delivery process.
        /// </summary>
        public string DeliverOrderExecute(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.DeliverOrderExecute: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                using var context = new DeliveringContext(_contextOptions);
                
                // Update DB.
                System.Console.WriteLine("CourierBackend.DeliverOrderExecute: cache");
                
                // Close the related business task.
                var deliveryOrder = context.DeliveryOrders
                    .Where(x => x.Id == model.Id && x.DeliveryOperation != null)
                    .Include(x => x.DeliveryOperation)
                    .FirstOrDefault();
                if (deliveryOrder == null)
                    throw new System.Exception($"Delivery order is not defined (delivery order ID: {model.Id})");
                var deliveryOperation = deliveryOrder.DeliveryOperation;
                if (deliveryOperation == null)
                    throw new System.Exception($"Delivery operation is not defined (delivery order ID: {model.Id})");
                deliveryOperation.Status = EnumExtensions.GetDisplayName(BusinessTaskStatus.Closed);

                // Change the status of the corresponding delivery order.
                deliveryOrder.CloseOrderDt = System.DateTime.UtcNow;
                deliveryOrder.Status = EnumExtensions.GetDisplayName(OrderStatus.Finished);
                context.SaveChanges();

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierBackend.DeliverOrderExecute: end");
            return response;
        }
        #endregion  // deliverorder

        private string NotifyDeliverOrder(DeliveryOrder model, string stageName)
        {
            string response = "";
            System.Console.WriteLine("CourierBackend.NotifyDeliveryOrder: begin");
            try
            {
                if (model == null)
                    throw new System.Exception("Delivery oder could not be null");
                if (string.IsNullOrEmpty(model.CustomerUid))
                    throw new System.Exception($"CustomerUid could not be null or empty in the specified DeliveryOrder (ID: {model.Id})");
                if (string.IsNullOrEmpty(model.CustomerName))
                    throw new System.Exception($"CustomerName could not be null or empty in the specified DeliveryOrder (ID: {model.Id})");
                if (string.IsNullOrEmpty(model.ExecutorUid))
                    throw new System.Exception($"ExecutorUid could not be null or empty in the specified DeliveryOrder (ID: {model.Id})");
                if (string.IsNullOrEmpty(model.ExecutorName))
                    throw new System.Exception($"ExecutorName could not be null or empty in the specified DeliveryOrder (ID: {model.Id})");
                
                using var context = new DeliveringContext(_contextOptions);

                // Get sender and receiver of the notification.
                var adminUser = context.UserAccounts.FirstOrDefault();
                if (adminUser == null)
                    throw new System.Exception($"Admin user could not be null (delivery order ID: {model.Id})");
                Employee courierEmployee = null;
                if (model.OrderExecutorType == OrderExecutorType.Employee)
                {
                    courierEmployee = context.Employees
                        .Include(x => x.UserAccounts)
                        .FirstOrDefault(x => x.Uid == model.ExecutorUid);
                }
                else
                {
                    var rand = new System.Random();

                    var userGroup = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == "courier");
                    if (userGroup == null)
                        throw new System.Exception($"Specified user group is not defined (delivery order ID: {model.Id})");

                    var userAccountIds = (from userAccount in userGroup.Users select userAccount.Id).ToList();
                    var potentialExecutors = 
                        (from employee in context.Employees 
                        where employee.UserAccounts != null && employee.UserAccounts.Any(ua => userAccountIds.Contains(ua.Id))
                        select employee).ToList();
                    if (potentialExecutors == null || !potentialExecutors.Any())
                        throw new System.Exception($"The list of potential executors is null or empty (delivery order ID: {model.Id})");
                    
                    courierEmployee = potentialExecutors[rand.Next(potentialExecutors.Count)];
                    if (courierEmployee == null)
                        throw new System.Exception($"Randomly selected employee is null (delivery order ID: {model.Id})");
                }
                if (courierEmployee == null)
                    throw new System.Exception($"Courier employee could not be null (delivery order ID: {model.Id})");
                var courierUser = courierEmployee.UserAccounts.FirstOrDefault();
                if (courierUser == null)
                    throw new System.Exception($"Courier user could not be null (delivery order ID: {model.Id})");

                // Getting the products that should be delivered.
                var deliveryOrderProducts = context.DeliveryOrderProducts
                    .Include(x => x.Product)
                    .Where(x => x.DeliveryOrder.Id == model.Id && x.Product != null);
                if (deliveryOrderProducts.Count() == 0)
                    throw new System.Exception($"There are no existing products associated with the specified DeliveryOrder (ID: {model.Id})");
                
                // Title text.
                var sbMessageText = new StringBuilder();
                sbMessageText.Append(stageName).Append(": deliver order #").Append(model.Id.ToString()).Append(" from the store to the warehouse");
                string titleText = sbMessageText.ToString();
                sbMessageText.Clear();

                // Body text.
                sbMessageText.Append("Please be informed that you are responsible for shipping order #");
                sbMessageText.Append(model.Id.ToString());
                sbMessageText.Append(" from the store to the warehouse.\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Ordering information:\n");
                sbMessageText.Append("UID: ").Append(model.Uid).Append(".\n");
                sbMessageText.Append("Creation date: ").Append(model.OpenOrderDt.ToString()).Append(".\n");
                sbMessageText.Append("Order author: ").Append(model.OrderCustomerType.ToString()).Append(" ").Append(model.CustomerName).Append(".\n");
                sbMessageText.Append("\n");
                sbMessageText.Append("Products for delivery:\n");
                foreach (var deliveryOrderProduct in deliveryOrderProducts)
                {
                    sbMessageText.Append("- ").Append(deliveryOrderProduct.Product.Name).Append(" ");
                    sbMessageText.Append("(quantity: ").Append(deliveryOrderProduct.Quantity).Append(").\n");
                }
                sbMessageText.Append("\n");
                sbMessageText.Append("Approximate price for products: $").Append(model.ProductsPrice.ToString()).Append("\n");

                // Notify the customer.
                Notification = new Notification
                {
                    SenderId = adminUser.Id,
                    ReceiverId = courierUser.Id,
                    TitleText = titleText,
                    BodyText = sbMessageText.ToString()
                };
                // new NotificationsBackendController(_contextOptions).SendNotifications(new List<Notification>
                // {
                //     Notification
                // });

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierBackend.NotifyDeliveryOrder: end");
            return response;
        }
    }
}