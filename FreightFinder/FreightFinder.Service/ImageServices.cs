using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web;
using FreightFinder.Core.IServices;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace FreightFinder.Service
{
    public class ImageServices : IImageServices
    {
        public ImageServices()
        {
        }

        public byte[] getImage(string url)
        {
            var downloaded = Download(url);
            MemoryStream stream = new MemoryStream();
            downloaded.DownloadToStream(stream);
            return stream.ToArray();
        }

        private async System.Threading.Tasks.Task Upload(string url)
        {
            string storageConnection = "";//CloudConfigurationManager.GetSetting("BlobStorageConnectionString"); 
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(storageConnection);

            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            //create a block blob CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            //create a container 
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("appcontainer");

            //create a container if it is not already exists

            if (await cloudBlobContainer.CreateIfNotExistsAsync())
            {

                await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            }

            string imageName = "Test-" + Path.GetExtension("");

            //get Blob reference

            //CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName); cloudBlockBlob.Properties.ContentType = imageToUpload.ContentType;

            //await cloudBlockBlob.UploadFromStreamAsync(imageToUpload.InputStream);

        }

        private CloudBlockBlob Download(string url)
        {
            var urlParts = url.ToLower().Split('/');
            var containerName = urlParts[0];
            var imageName = urlParts[1];
            string storageConnection = "DefaultEndpointsProtocol=https;AccountName=freightfinderimages;AccountKey=+5TEm1FB0/qR82cX54lkizR2CeepL3QAaDbKp/MLo5kUW9RsrI18O/6MPrO+lCWwEzDDuLdcM1o8YbHaDtX+Bw==;EndpointSuffix=core.windows.net";//CloudConfigurationManager.GetSetting("BlobStorageConnectionString"); 
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(storageConnection);

            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
            CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
            blockBlob.Properties.ContentType = "image/jpg";
            blockBlob.SetProperties();
            return blockBlob;
        }
    }


}
