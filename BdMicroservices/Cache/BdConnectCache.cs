using MySqlConnector;
using platform.UtlMicroservices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;

namespace platform.BdMicroservices.Cache
{
    sealed class BdConnectCache: Singleton<BdConnectCache>
    {
        public Dictionary<string, DbConnection> connectBd = new Dictionary<string, DbConnection>();
        public BdConnectCache()
        {
            ConnectionStringSettingsCollection connectionStringSettingsCollection = ConfigurationManager.ConnectionStrings;
            foreach (ConnectionStringSettings connectionStringSettings in connectionStringSettingsCollection)
            {    
                switch (connectionStringSettings.ProviderName)
                {
                    case "MySql.Data.MySqlClient":
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionStringSettings.ConnectionString);
                        connectBd.Add(connectionStringSettings.Name, mySqlConnection);
                        break;
                }
            }
        }
    }
}
