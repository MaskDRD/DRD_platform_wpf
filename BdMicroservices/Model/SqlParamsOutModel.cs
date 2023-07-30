using MySqlConnector;

namespace platform.BdMicroservices.model
{
    class SqlParamsOutModel
    {
        public SqlParamsOutModel(string name, MySqlDbType type) {
            Name = name;
            Type = type;
        } 

        public string Name { get; set; }
        public MySqlDbType Type { get; set; }
    }
}
