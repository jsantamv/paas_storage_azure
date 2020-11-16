# Plataforma como servicio PAAS - ALMACENAMIENTO EN AZURE

## Microsoft Storage
Azure Storage incluye el almacenamiento de objetos, archivos, discos, colas y tablas. También hay servicios para las soluciones de almacenamiento híbrido, así como para transferir, compartir y realizar copias de seguridad de los datos.

Link crear cuenta paso a paso
- ![Pasos para crear cuenta en Azure](https://docs.microsoft.com/es-es/azure/storage/common/storage-account-create?toc=%2Fazure%2Fstorage%2Fblobs%2Ftoc.json&tabs=azure-portal)


### Azure Storage Explorer
Azure Storage Explorer

Descargar e instalar Storage Explorer desde ![Storage Explorer](https://azure.microsoft.com/es-mx/features/storage-explorer/)
1. Copiar la connectionString de access Keys.
2. Conectarnos a Azure desde StorageExplorer.
3. Elegir la opcion “mediante connectionstring”
2. Configurar la conexión en el Storage Explorer


# Ruta de Aprendizaje
1. Subir archivos a Blob Storage
2. Crear Tablas en Table Storage (CosmosDB)
3. Insertar registros en table Storage
4. Crear colas en Queues
5. Consumir colas en Queues
6. Por cada cola consumida crear un Blob con texto. 

## Azure Blob
Azure Blob Storage es la solución de almacenamiento de objetos de Microsoft para la nube. Blob Storage está optimizado para el almacenamiento de cantidades masivas de datos no estructurados. Los datos no estructurados son datos que no se ciñen a ningún un modelo de datos o definición concretos, como texto o datos binarios.

### Uso de .Net Core Seguridad
1. Es mejor utlizar .Net Core, sin embargo se puede utilizar node, phyton u otros. 
2. Cuidar nuestra seguridad

#### Comandos para creacón de un proyecto en la terminal, bash o powershell.

Creo un proyecto con los comandos de dotnet
```p
dotnet new console -n Blob.Console.Test
```
me dirijo a la carpeta creada y agrego un archivo de configuracion para almacenar mi connstring y lo agrego al archivo csproj. 
y agrego los siguientes paquetes nugets:

- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.FileExtensions
- Microsoft.Extensions.Configuration.Json
- Microsoft.Azure.Storage.Blob: Esta version esta desactualizada pero para el ejercicio es mas que suficiente. https://shorturl.at/rzMX0

## Documentación
- **Azure Storage**: https://docs.microsoft.com/es-es/azure/storage/
- **Azure Blob Storage**: https://docs.microsoft.com/es-es/azure/storage/blobs/storage-blobs-introduction