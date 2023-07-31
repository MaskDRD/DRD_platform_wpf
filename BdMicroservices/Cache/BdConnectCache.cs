using MySqlConnector;
using platform.BdMicroservices.service;
using platform.UtlMicroservices;
using System.Collections.Generic;
using System.Configuration;

namespace platform.BdMicroservices.Cache
{
    sealed class BdConnectCache: Singleton<BdConnectCache>
    {
        public Dictionary<string, BdService> connectBd = new Dictionary<string, BdService>();
        public BdConnectCache()
        {
            ConnectionStringSettingsCollection connectionStringSettingsCollection = ConfigurationManager.ConnectionStrings;
            foreach (ConnectionStringSettings connectionStringSettings in connectionStringSettingsCollection)
            {    
                switch (connectionStringSettings.ProviderName)
                {
                    case "MySql.Data.MySqlClient":
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionStringSettings.ConnectionString);
                        BdMySqlService bdMySqlService = new BdMySqlService(mySqlConnection);
                        connectBd.Add(connectionStringSettings.Name, bdMySqlService);
                        break;
                }
            }
        }
    }
}
