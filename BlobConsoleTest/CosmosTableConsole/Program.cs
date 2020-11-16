using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace CosmosTableConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = Common.CreateTableAsync("Tabla2");
            var res2 = Common.CreateTable("Table3");

            Console.WriteLine($"Ejecutado Correctamente {res.Status} or {res2.Name}");

        }

        public static async Task<CloudTable> CreateTableAsyc(string tableName, string conectionStrig)
        {
            try
            {
                // Nos Conectamos
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(conectionStrig);

                // Este Cliente esteblece la conexion de storage a mi cosmos.
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());

                //ya Tengo mi tabla que exista segun la configuracion anterior
                CloudTable table = tableClient.GetTableReference(tableName);

                if (await table.CreateIfNotExistsAsync())
                    Console.WriteLine($"Tabla Creada {tableName}");
                else
                    Console.WriteLine($"La tabla ya existe {tableName}");

                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
         
        }

    }
}
