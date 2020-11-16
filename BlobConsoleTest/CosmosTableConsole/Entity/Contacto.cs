using Microsoft.Azure.Cosmos.Table;

namespace CosmosTableConsole.Entity
{
    public class Contacto : TableEntity
    {
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }

        public Contacto()
        {
            PartitionKey = Apellido;
            RowKey = Nombre;
        }

        public Contacto(string apellido, string nombre)
        {
            PartitionKey = apellido;
            RowKey = nombre;
        }
    }
}
