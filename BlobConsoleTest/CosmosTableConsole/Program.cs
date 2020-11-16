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
            CrearContacto();
        }

        /// <summary>
        /// Crea o Actualiza una Tabla con los datos
        /// que se solicitan al cliente
        /// </summary>
        private static void CrearContacto()
        {
            Console.WriteLine("Incia la Creacion de Contacto");
            
            //Instacias para el contacto 
            Contacto crearContact = new Contacto();
            Entity.Contacto contacto = new Entity.Contacto();

            Console.WriteLine("Digite la Tabla");
            var table = Common.CreateTable(Console.ReadLine().ToLower());

            Console.WriteLine("Digite Apellido");
            contacto.Apellido = Console.ReadLine();

            Console.WriteLine("Digite Email");
            contacto.Email = Console.ReadLine();

            Console.WriteLine("Digite Nombre");
            contacto.Nombre = Console.ReadLine();           

            Console.WriteLine("Digite Telefono");
            contacto.Telefono = Console.ReadLine();

            contacto.PartitionKey = contacto.Apellido;
            contacto.RowKey = contacto.Nombre;

            var result = crearContact.InsertOperation(table,contacto);

            Console.WriteLine($"Finaliza la corrida se crea o actualiza {result.Apellido}");

        }

        private static void CrearContactoAsync()
        {
            Console.WriteLine("Incia la Creacion de Contacto");
            string storageConnectionString = AppSettings.LoadAppSettings().StorageConnectionString;
            CloudStorageAccount storageAccount = Common.CreateStorageAccountFromConnectionString(storageConnectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            CloudTable table = tableClient.GetTableReference("Tabla2");

            Contacto contact = new Contacto();
            var correr = Task.Factory.StartNew(async () => contact.InsertOperationAsync(table));
            correr.Wait();

            Console.WriteLine("Finaliza la corrida Asyncrona");
        }
    }
}
