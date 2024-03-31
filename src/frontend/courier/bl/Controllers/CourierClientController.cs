using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Network;
using DeliveryService.Core.Contexts;

namespace DeliveryService.Frontend.Courier.BL.Controllers
{
    /// <summary>
    /// Client-side app controller that serves requests from the courier.
    /// </summary>
    public class CourierClientController
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public CourierClientController(
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
            System.Console.WriteLine("CourierClient.Store2WhStart: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");

                // Update DB.
                System.Console.WriteLine("CourierClient.Store2WhStart: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierClient.Store2WhStart: end");
            return response;
        }

        /// <summary>
        /// A method that controls the process of delivering products from the store to the warehouse.
        /// </summary>
        public string Store2WhExecute(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.Store2WhExecute: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                
                // Update DB.
                System.Console.WriteLine("CourierClient.Store2WhExecute: cache");

                // Send HTTP request.
                // string backendResponse = new CourierBackendController(_contextOptions).Store2WhExecute(new ApiOperation
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
            System.Console.WriteLine("CourierClient.Store2WhExecute: end");
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
            System.Console.WriteLine("CourierClient.DeliverOrderStart: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");

                // Update DB.
                System.Console.WriteLine("CourierClient.DeliverOrderStart: cache");

                // 
                response = "success";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("CourierClient.DeliverOrderStart: end");
            return response;
        }
        
        /// <summary>
        /// The method that is responsible for executing the order delivery process.
        /// </summary>
        public string DeliverOrderExecute(DeliveryOrder model)
        {
            string response = "";
            System.Console.WriteLine("CourierClient.DeliverOrderExecute: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                
                // Update DB.
                System.Console.WriteLine("CourierClient.DeliverOrderExecute: cache");

                // Send HTTP request.
                // string backendResponse = new CourierBackendController(_contextOptions).DeliverOrderExecute(new ApiOperation
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
            System.Console.WriteLine("CourierClient.DeliverOrderExecute: end");
            return response;
        }
        #endregion  // deliverorder
    }
}