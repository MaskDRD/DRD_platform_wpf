using MySqlConnector;
using platform.UtlMicroservices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace platform.BdMicroservices.Cache
{
    sealed class BdConnectCache: Singleton<BdConnectCache>
    {
        public Dictionary<string, MySqlConnection> connectBd = new Dictionary<string, MySqlConnection>();
        public BdConnectCache()
        {
            ConnectionStringSettingsCollection connectionStringSettingsCollection = ConfigurationManager.ConnectionStrings;
            foreach (ConnectionStringSettings connectionStringSettings in connectionStringSettingsCollection)
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connectionStringSettings.ConnectionString);
                connectBd.Add(connectionStringSettings.Name, mySqlConnection);
            }
        }
    }
}
