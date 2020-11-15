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