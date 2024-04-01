using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Monetary;
using WorkflowLib.Models.Business.Products;
using WorkflowLib.Models.Network;
using DeliveryService.Core.Contexts;

namespace DeliveryService.Frontend.Customer.BL.Controllers
{
    /// <summary>
    /// A class that represents a client-side app controller that processes requests from the customer.
    /// </summary>
    public class CustomerClientControllerBL
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public CustomerClientControllerBL(
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
            System.Console.WriteLine("CustomerClient.MakeOrderRequest: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");

                // Send HTTP request.
                // string backendResponse = _customerBackendController.MakeOrderRequest(new ApiOperation
                // {
                //     RequestObject = model
                // });
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakeOrderRequest: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerClient.MakeOrderRequest: end");
            return response;
        }
        #endregion  // makeorder
        
        #region makepayment
        /// <summary>
        /// A method that stores the data necessary to carry out electronic payment on the part of the client.
        /// </summary>
        public string MakePaymentSave(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("CustomerClient.MakePaymentSave: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");

                // Update DB.
                System.Console.WriteLine("CustomerClient.MakePaymentSave: cache");

                // 
                response = "DB is updated";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerClient.MakePaymentSave: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for transmitting information from the client regarding the completed electronic payment.
        /// </summary>
        public string MakePaymentRespond(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("CustomerClient.MakePaymentRespond: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");

                // Validation.
                System.Console.WriteLine("CustomerClient.MakePaymentRespond: validation");
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakePaymentRespond: cache");

                // Send HTTP request.
                // string backendResponse = _customerBackendController.MakePaymentRespond(new ApiOperation()
                // {
                //     RequestObject = model
                // });
                
                // Insert into cache.
                System.Console.WriteLine("CustomerClient.MakePaymentRespond: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CustomerClient.MakePaymentRespond: end");
            return response;
        }
        #endregion  // makepayment
    }
}