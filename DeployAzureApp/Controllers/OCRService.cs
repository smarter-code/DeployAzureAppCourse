using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Text;

namespace DeployAzureApp.Controllers
{
    public static class OCRService
    {
        // Azure Cognitive Services
        static string cognitiveServicesEndpoint = "";
        static string cognitiveServicesKey = "";
        static ComputerVisionClient client;

        public static ComputerVisionClient GetComputerVisionClient()
        {
            ComputerVisionClient client =
              new ComputerVisionClient(new ApiKeyServiceClientCredentials(cognitiveServicesKey))
              { Endpoint = cognitiveServicesEndpoint };
            return client;
        }

        public static async Task<List<string>> ReadImage(ComputerVisionClient client, IFormFile file)
        {
            List<string> extractedLines;
            using (var stream = file.OpenReadStream())
            {
                var ocrResult = await client.RecognizePrintedTextInStreamAsync(true, stream);
                extractedLines = ExtractWordsFromOcrResult(ocrResult);
            }
            return extractedLines;
        }

        private static List<string> ExtractWordsFromOcrResult(OcrResult ocrResult)
        {

            var result = new List<string>();

            foreach (var line in ocrResult.Regions[0].Lines)
            {
                var lineText = new StringBuilder();
                foreach (var word in line.Words)
                {
                    lineText.Append(word.Text + " ");
                }
                result.Add(lineText.ToString());
            }
            return result;
        }

    }
}
