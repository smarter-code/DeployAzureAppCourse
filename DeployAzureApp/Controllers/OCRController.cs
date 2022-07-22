using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeployAzureApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OCRController : ControllerBase
    {

        public ILogger<OCRController> logger { get; }
        public OCRController(ILogger<OCRController> logger)
        {
            this.logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(IFormFile file)
        {

            try
            {
                //var computerVisionClient = OCRService.GetComputerVisionClient();
                //  var fileResult = await OCRService.ReadImage(computerVisionClient, file);
                //  AzureSQLService.WriteFileNameAndTextToSQL(file.FileName, fileResult);
                //  await StorageAccountService.UploadFileToStorageAccountAsync(file);
                // logger.LogInformation($"Successfully Analyzed: {file.FileName}");

                //  return new OkObjectResult(fileResult);

                return new OkObjectResult("Works Fine");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

    }
}
