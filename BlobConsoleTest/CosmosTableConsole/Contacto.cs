using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosTableConsole
{
    public class Contacto
    {
        public async Task InsertOperationAsync(CloudTable table)
        {
            Entity.Contacto contacto = new Entity.Contacto("Jsanta", "Villegas")
            {
                Email = "jsan@hola.com",
                Telefono = "8888-8888"
            };

            TableOperation insertOperation = TableOperation.InsertOrMerge(contacto);
            TableResult result = await table.ExecuteAsync(insertOperation);
            Entity.Contacto insertContact = result.Result as Entity.Contacto;

            Console.WriteLine("Contacto insertado");
        }

        public Entity.Contacto InsertOperation(CloudTable table, Entity.Contacto contacto)
        {
            
            TableOperation insertOperation = TableOperation.InsertOrMerge(contacto);
            TableResult result = table.Execute(insertOperation);
            Entity.Contacto insertContact = result.Result as Entity.Contacto;

            Console.WriteLine($"Contacto insertado {insertContact.PartitionKey}");
            return insertContact;
        }
    }
}
