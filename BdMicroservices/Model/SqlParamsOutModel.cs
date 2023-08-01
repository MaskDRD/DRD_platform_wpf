using MySqlConnector;

namespace platform.BdMicroservices.model
{
    class SqlParamsOutModel<T>
    {
        public SqlParamsOutModel(string name, T type) {
            Name = name;
            Type = type;
        } 

        public string Name { get; set; }
        public T Type { get; set; }
    }
}
