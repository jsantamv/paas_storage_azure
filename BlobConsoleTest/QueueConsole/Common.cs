using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Queue;

namespace QueueConsole
{
    public class Common
    {
        public static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the application.");
                throw;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                Console.ReadLine();
                throw;
            }

            return storageAccount;
        }


        /// <summary>
        /// Ejemplo de Creacion de las Colas. 
        /// </summary>
        public static void CreateQueue()
        {
            string consstr = AppSettings.LoadAppSettings().connectionstring;

            // Retrieve storage account information from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(consstr);

            // Cliente de generador de colas obtener las referencias de tus Queues
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference("filaprocesos");
            queue.CreateIfNotExists();
            CloudQueueMessage peekMassege = queue.PeekMessage();

            //las siguientes lineas me ayudaran a consumir las colas
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("contenedorregistros");
            container.CreateIfNotExists();


            // Emulacion para creacion de colas
            for (int i = 0; i < 100; i++)
            {
                CloudQueueMessage nuevoMensaje = new CloudQueueMessage($"Operacion: {i}");
                queue.AddMessage(nuevoMensaje);

                Console.WriteLine(i);
            }

            // Ejemplo para consumir las colas 
            foreach (CloudQueueMessage item in queue.GetMessages(20, TimeSpan.FromSeconds(100)))
            {
                string filePath = $"log{item.Id}.txt";
                TextWriter tempFile = File.CreateText(filePath);
                var message = queue.GetMessage().AsString;
                tempFile.WriteLine(message);
                tempFile.Close();

                Console.WriteLine("Archivo Creado");

                using (var fileStrem = System.IO.File.OpenRead(filePath))
                {
                    CloudBlockBlob myBlob = container.GetBlockBlobReference($"log{item.Id}.txt");
                    myBlob.UploadFromStream(fileStrem);
                    Console.WriteLine("Blob Creado");
                }
                //Eliminamos la cola
                queue.DeleteMessage(item);
            }

            Console.ReadLine();
        }


    }
}
