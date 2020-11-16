using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueueConsole
{
    public class AppSettings
    {
        public string StorageConnectionString { get; set; }
        public string DefaulConnString { get; set; }
        public string connectionstring { get; set; }

        /// <summary>
        /// Defino el metodo para mapear 
        /// todos mis propiedades 
        /// con las conexiones que tenga. 
        /// </summary>
        /// <returns></returns>
        public static AppSettings LoadAppSettings()
        {
            IConfigurationRoot configRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            AppSettings appSettings = configRoot.Get<AppSettings>();
            return appSettings;
        }
    }
}
