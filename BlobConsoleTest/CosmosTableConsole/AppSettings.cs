using Microsoft.Extensions.Configuration;

namespace CosmosTableConsole
{
    /// <summary>
    /// Esta clase realiza el mapeo de todas mis
    /// propiedades defenidas previamente
    /// para automaticamente mapearlas
    /// Las cuales debe de defenirse en el igual 
    /// que mi archivivo de configuraccion
    /// en formato json. appsettings.json
    /// </summary>
    public class AppSettings
    {
        public string StorageConnectionString { get; set; }
        public string DefaulConnString { get; set; }

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
