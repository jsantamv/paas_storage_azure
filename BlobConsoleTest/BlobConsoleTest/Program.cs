using System;
using System.IO;

namespace BlobConsoleTest
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
