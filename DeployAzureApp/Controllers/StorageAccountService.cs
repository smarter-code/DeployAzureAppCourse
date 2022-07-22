//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Auth;
//using Microsoft.WindowsAzure.Storage.Blob;

//namespace DeployAzureApp.Controllers
//{
//    public static class StorageAccountService
//    {
//        //Azure Storage Account

//        const string storageAccountName = "";
//        const string storageAccountKey = "";

//        public static async Task UploadFileToStorageAccountAsync(IFormFile file)
//        {
//            var storageAccount = new CloudStorageAccount(new StorageCredentials(storageAccountName, storageAccountKey), true);
//            var blobClient = storageAccount.CreateCloudBlobClient();
//            var container = blobClient.GetContainerReference("images");
//            await container.CreateIfNotExistsAsync();
//            await container.SetPermissionsAsync(new BlobContainerPermissions()
//            {
//                PublicAccess = BlobContainerPublicAccessType.Blob
//            });

//            var blob = container.GetBlockBlobReference(DateTime.Now.ToString("yyyyMMddhhmmss") + " " + file.FileName);
//            using (var stream = file.OpenReadStream())
//            {
//                await blob.UploadFromStreamAsync(stream);
//            }

//        }
//    }
//}
