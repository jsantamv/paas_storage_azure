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
    /// <summary>
    /// En esta clase se utilizaran las 
    /// siguientes librerias Microsoft.Azure
    /// Sin embargo este libreria ya esta obsoleta
    /// y la recomendacion es utilizar la que esta en la 
    /// clase BlobAzureContainer.cs. Esto es a modo de ejemplo, para ver como se utilizan las dos versiones
    /// </summary>
    public class BlobMicrosoftAzureContainer
    {
        /// <summary>
        /// Esta propiedad para es en caso de que no exista
        /// un contanedor por default.
        /// </summary>
        public string DefaultContainer { get; set; }

        /// <summary>
        /// Indica el nombre de archivo subido
        /// </summary>
        public string BlobName { get; set; }

        /// <summary>
        /// Ruta del archivo al que hay que subir
        /// </summary>
        public string PathName { get; set; }

        public BlobMicrosoftAzureContainer()
        {
            DefaultContainer = "default";
            BlobName = string.Empty;
        }

        /// <summary>
        /// Forma con Microsoft Azure Blob.
        /// </summary>
        public void UploadImage()
        {
            try
            {
                if (BlobName.Equals(string.Empty))
                    throw new Exception("El valor BlobName Referencia no puede ser vacio");

                _ = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                IConfiguration config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();

                CloudStorageAccount storagaeAcount = CloudStorageAccount.Parse(config["connectionstring"]);

                CloudBlobClient clientBlob = storagaeAcount.CreateCloudBlobClient();

                CloudBlobContainer container = clientBlob.GetContainerReference(DefaultContainer);
                container.CreateIfNotExists();

                //Permiso de accesso publico
                container.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });

                //Subir una imagen
                CloudBlockBlob myBlob = container.GetBlockBlobReference(BlobName);

                using (var fileStream = File.OpenRead(PathName))
                {
                    myBlob.UploadFromStream(fileStream);
                }

                Console.WriteLine("Archivo subido");
                Console.WriteLine(container.StorageUri);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
