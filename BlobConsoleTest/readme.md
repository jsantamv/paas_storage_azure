# Configuracion de la clase BlobAzureContainer
Para esta clase vamos utilizar las siguientes Librerias. 

## Opciones para crear la cadena de conexion
1. Crear un archivo de configuracion con las credenciales para nuestro contenedor: **appsettings.json**

```b
{
  "connectionstring": "ver su cuenta de azure",  
}
```

2. Como variable de entorno en segun el ambiente.

**Windows**
```b
setx AZURE_STORAGE_CONNECTION_STRING "<yourconnectionstring>"
```
 **Linux**
 ```b
 export AZURE_STORAGE_CONNECTION_STRING="<yourconnectionstring>"
 ```

 **macOS**
 ```b
 export AZURE_STORAGE_CONNECTION_STRING="<yourconnectionstring>"
```
El siguiente diagrama muestra la relación entre estos recursos

![alt text](https://docs.microsoft.com/en-us/azure/storage/blobs/media/storage-blobs-introduction/blob1.png)

Use the following .NET classes to interact with these resources:

*BlobServiceClient*: The BlobServiceClient class allows you to manipulate Azure Storage resources and blob containers.
*BlobContainerClient*: The BlobContainerClient class allows you to manipulate Azure Storage containers and their blobs.
*BlobClient*: The BlobClient class allows you to manipulate Azure Storage blobs.
*BlobDownloadInfo*: The BlobDownloadInfo class represents the properties and content returned from downloading a blob.