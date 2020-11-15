using System;
using System.IO;
using Microsoft.Azure;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;




namespace BlobConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();

            CloudStorageAccount storagaeAcount = CloudStorageAccount.Parse(config["connectionstring"]);
            
            CloudBlobClient clientBlob = storagaeAcount.CreateCloudBlobClient();
            
            CloudBlobContainer container = clientBlob.GetContainerReference("testplatzi");
            container.CreateIfNotExists();
            
            //Permiso de accesso publico
            container.SetPermissions(new BlobContainerPermissions{
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            //Subir una imagen
            CloudBlockBlob myBlob = container.GetBlockBlobReference("frijol.jpg");
            
            using(var fileStream = System.IO.File.OpenRead(@"F:\Proyecto Familiar\Chococafe\frijol.jpg"))
            {
                myBlob.UploadFromStream(fileStream);
            }
            
            Console.WriteLine("Archivo subido");
            Console.WriteLine(container.StorageUri);
            Console.ReadKey();

        }
    }
}
