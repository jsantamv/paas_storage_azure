using System;
using System.IO;

namespace BlobConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //CrearContendor();
            //SubirArchivo();
            ListarBlob();
        }

        public void modoPlatzi()
        {
            //Version del curso de platzi
            var myContainer = new BlobMicrosoftAzureContainer();
            Console.WriteLine("Indicar La ruta del Archivo");
            myContainer.PathName = Console.ReadLine();
            FileInfo fi = new FileInfo(myContainer.PathName);
            myContainer.BlobName = fi.Name;

            if (File.Exists(myContainer.PathName))
            {
                // This path is a file
                myContainer.UploadImage();
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", myContainer.PathName);
            }

            Console.ReadLine();
        }

        public static void CrearContendor()
        {
            try
            {
                var container = new BlobAzureContainer();
                container.ContainerCreate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SubirArchivo()
        {
            try
            {
                Console.WriteLine("Indicar Ruta del Archivo: ");
                var container = new BlobAzureContainer();
                container.FileName = Console.ReadLine();
                container.UploadFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void ListarBlob()
        {   
            try
            {
                Console.WriteLine("Indique el Contendor: ");
                var container = new BlobAzureContainer();
                container.ContainerName = Console.ReadLine();
                container.ListingBlob();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
