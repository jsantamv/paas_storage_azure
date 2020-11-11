# Plataforma como servicio PAAS - ALMACENAMIENTO EN AZURE

## Microsoft Storage
Azure Storage incluye el almacenamiento de objetos, archivos, discos, colas y tablas. También hay servicios para las soluciones de almacenamiento híbrido, así como para transferir, compartir y realizar copias de seguridad de los datos.

Link crear cuenta paso a paso
- https://docs.microsoft.com/es-es/azure/storage/common/storage-account-create?toc=%2Fazure%2Fstorage%2Fblobs%2Ftoc.json&tabs=azure-portal

### Azure Storage Explorar
Azure Storage Explorer

Descargar e instalar Storage Explorer desde https://azure.microsoft.com/es-mx/features/storage-explorer/
1. Copiar la connectionString de access Keys.
2. Conectarnos a Azure desde StorageExplorer.
3. Elegir la opcion “mediante connectionstring”
2. Configurar la conexión en el Storage Explorer

### Uso de .Net Core Seguridad
1. Es mejor utlizar .Net Core, sin embargo se puede utilizar node, phyton u otros. 
2. Cuidar nuestra seguridad

#### Comandos para creacón de un proyecto en la terminal, bash o powershell.

Creo un proyecto con los comandos de dotnet
```p
dotnet new console -n Blob.Console.Test
```
me dirijo a la carpeta creada y agrego un archivo de configuracion para almacenar mi connstring y lo agrego al archivo csproj. 
y agrego los siguientes paquetes nugets
```p
Install-Package Microsoft.Extensions.Configuration -Version 5.0.0
```



## Documentación
- https://docs.microsoft.com/es-es/azure/storage/