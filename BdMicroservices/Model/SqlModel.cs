namespace platform.BdMicroservices.Model
{
    class SqlModel
    {
        public SqlModel(string sql, string connectionName) { 
            ConnectionName = connectionName;
            Sql = sql;
        }

        public SqlModel(
            string sql,
            string connectionName,
            SqlParamsModel paramsIn
        ) {
            ConnectionName = connectionName;
            Sql = sql;
            ParamsIn = paramsIn;
        }

        public SqlModel(
            string sql,
            string connectionName,
            SqlParamsModel paramsIn,
            SqlParamsModel paramsOut
        ) {
            ConnectionName = connectionName;
            Sql = sql;
            ParamsIn = paramsIn;
            ParamsOut = paramsOut;
        }


        public string Type { get; set; }

        public string Sql { get; set; }

        public string ConnectionName { get; set; }

        public SqlParamsModel ParamsIn { get; set; }
        public SqlParamsModel ParamsOut { get; set; }
    }
}
