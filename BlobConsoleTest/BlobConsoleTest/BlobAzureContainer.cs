using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlobConsoleTest
{
    /// <summary>
    /// For this examples requiere use the library CLI link
    /// dotnet add package WindowsAzure.Storage --version 9.3.3
    /// </summary>
    public class BlobAzureContainer
    {

        /// <summary>
        /// Retrieve the connection string for use with the application. The storage
        /// connection string is stored in an environment variable on the machine
        /// running the application called AZURE_STORAGE_CONNECTION_STRING. If the
        /// environment variable is created after the application is launched in a
        /// console or with Visual Studio, the shell or application needs to be closed
        /// and reloaded to take the environment variable into account.
        /// </summary>
        public string ConnectionString { get; set; }
        public string ContainerName { get; set; }
        public string FileName { get; set; }


        public BlobAzureContainer()
        {
            ConnectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            ContainerName = "default";
        }

        /// <summary>
        /// Crea un Blob Container
        /// pero si existe deja el mismo
        /// </summary>
        public void ContainerCreate()
        {
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(ConnectionString);

            // Create the container and return a container client object
            //BlobContainerClient containerClient = blobServiceClient.CreateBlobContainer(containerName + Guid.NewGuid().ToString());
            //BlobContainerClient containerClient = blobServiceClient.CreateBlobContainer(containerName);

            // Forma para validar si existe
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);

            //Ejemplo de validacion
            if (container.Exists())
                throw new Exception($"El Contenedor: `{container.Name}` ya existe ");

            container.CreateIfNotExists();
            Console.WriteLine($"Contenedor: {container.Name}");
        }

        public void UploadFile()
        {

            BlobServiceClient blobServiceClient = new BlobServiceClient(ConnectionString);
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);

            BlobClient blobClient = container.GetBlobClient(FileName);

            Console.WriteLine($"Uploading to Blob storage as blob:\n\t {blobClient.Uri}\n");

            // Open the file and upload its data
            using FileStream uploadFileStream = File.OpenRead(FileName);
            //Con todo el arbol de directorios
            blobClient.Upload(uploadFileStream, true);
            uploadFileStream.Close();

            //en la Raiz del Contenedor
            blobClient.Upload(FileName);

        }

        public void ListingBlob()
        {
            Console.WriteLine("Listing blobs...");
            BlobServiceClient blobServiceClient = new BlobServiceClient(ConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

            // List all blobs in the container
            foreach (BlobItem blobItem in containerClient.GetBlobs())
            {
                Console.WriteLine("\t" + blobItem.Name);
            }
        }


        public void DownloadBlobs()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(ConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

            // Download the blob to a local file
            // Append the string "DOWNLOADED" before the .txt extension 
            // so you can compare the files in the data directory
            //string downloadFilePath = localFilePath.Replace(".txt", "DOWNLOADED.txt");

            //Console.WriteLine("\nDownloading blob to\n\t{0}\n", downloadFilePath);

            //// Download the blob's contents and save it to a file
            //BlobDownloadInfo download = await blobClient.DownloadAsync();

            //using (FileStream downloadFileStream = File.OpenWrite(downloadFilePath))
            //{
            //    await download.Content.CopyToAsync(downloadFileStream);
            //    downloadFileStream.Close();
            //}
        }

        public async void DownloadBlobsAsyc()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(ConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

            // Clean up
            Console.Write("Press any key to begin clean up");
            Console.ReadLine();

            Console.WriteLine("Deleting blob container...");
            await containerClient.DeleteAsync();

            //Console.WriteLine("Deleting the local source and downloaded files...");
            //File.Delete(localFilePath);
            //File.Delete(downloadFilePath);

            Console.WriteLine("Done");
        }

    }
}
