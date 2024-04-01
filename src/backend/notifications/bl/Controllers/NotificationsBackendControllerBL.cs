using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Customers;
using DeliveryService.Core.Contexts;

namespace DeliveryService.Backend.Notifications.BL
{
    /// <summary>
    /// Backend service controller that allows to send notifications to the users of the system.
    /// </summary>
    public class NotificationsBackendControllerBL
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public NotificationsBackendControllerBL(
            DbContextOptions<DeliveringContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// The method that is responsible for sending notifications to system users.
        /// </summary>
        public string SendNotifications(IEnumerable<Notification> notifications)
        {
            string response = "";
            System.Console.WriteLine("NotificationsBackend.SendNotifications: begin");
            try
            {
                // Validation.
                System.Console.WriteLine("NotificationsBackend.SendNotifications: validation");
                if (notifications == null || !notifications.Any())
                    throw new System.Exception("Collection of notifications could not be null or empty");
                if (notifications.Any(x => x == null))
                    throw new System.Exception("Collection of notifications could not contain null objects");
                using var context = new DeliveringContext(_contextOptions);

                foreach (var notification in notifications)
                {
                    // Update DB.
                    System.Console.WriteLine("NotificationsBackend.SendNotifications: cache");
                    context.Notifications.Add(notification);

                    // Send email.
                    // SendEmail();

                    // Send push notifications.
                    SendPush(notification);

                    // Send message via Telegram.
                    // SendMsgTelegram();
                    
                    // Update DB.
                    System.Console.WriteLine("NotificationsBackend.SendNotifications: cache");
                }
                context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("NotificationsBackend.SendNotifications: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for sending email notifications.
        /// </summary>
        public string SendEmail()
        {
            // 
            return "";
        }

        /// <summary>
        /// A basic method that allows you to send push notifications to the user.
        /// </summary>
        public string SendPush(Notification notification)
        {
            string response = "";
            System.Console.WriteLine("NotificationsBackend.SendPush: begin");
            try
            {
                // Validation.
                System.Console.WriteLine("NotificationsBackend.SendPush: validation");
                
                // Update DB.
                System.Console.WriteLine("NotificationsBackend.SendPush: cache");

                // Sending push notification.
                System.Console.WriteLine("NotificationsBackend.SendPush: notifying");
                
                // Update DB.
                System.Console.WriteLine("NotificationsBackend.SendPush: cache");

                // 
                response = "notification is sent";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("NotificationsBackend.SendPush: end");
            return response;
        }

        /// <summary>
        /// A method that allows you to notify users by sending messages to Telegram.
        /// </summary>
        public string SendMsgTelegram()
        {
            // 
            return "";
        }

        /// <summary>
        /// The method that is responsible for receiving notifications via the REST API.
        /// </summary>
        public string GetNotified()
        {
            // Preprocess.
            // Update DB.
            // Send HTTP request to backend service.
            
            // 
            return "";
        }
    }
}