using System;
using System.IO;

using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;

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


            CloudStorageAccount(account_name = None, account_key = None, sas_token = None, is_emulated = None, endpoint_suffix = None)

            string getConnString = config["connectionstring"];

            Console.WriteLine(getConnString);
            //Console.ReadKey();
        }
    }
}
