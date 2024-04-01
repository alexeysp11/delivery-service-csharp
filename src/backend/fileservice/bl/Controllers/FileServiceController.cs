using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Network;

namespace DeliveryService.Backend.FileService.BL.Controllers
{
    /// <summary>
    /// A backend service that is responsible for generating and processing files.
    /// </summary>
    public class FileServiceController
    {
        /// <summary>
        /// A method that generates a QR code for payment based on a customer order. 
        /// </summary>
        public string GenerateQrCode(InitialOrder model)
        {
            string response = "";
            System.Console.WriteLine("FileServiceController.GenerateQrCode: begin");
            try
            {
                // Initializing.
                if (model == null)
                    throw new System.Exception("Input parameter could not be null");
                
                // Update DB.
                System.Console.WriteLine("FileServiceController.GenerateQrCode: cache");

                // Generating QR code.
                System.Console.WriteLine("FileServiceController.GenerateQrCode: generating qr code");
                
                // Update DB.
                System.Console.WriteLine("FileServiceController.GenerateQrCode: cache");

                // 
                response = "qr code generated";
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("FileServiceController.GenerateQrCode: end");
            return response;
        }
    }
}