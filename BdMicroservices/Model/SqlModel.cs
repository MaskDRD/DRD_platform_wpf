namespace platform.BdMicroservices.Model
{
    class SqlModel
    {
        public SqlModel(string sql) { 
            Sql = sql;
        }

        public SqlModel(
            string sql,
            SqlParamsModel paramsIn
        ) {
            Sql = sql;
            ParamsIn = paramsIn;
        }

        public SqlModel(
            string sql,
            SqlParamsModel paramsIn,
            SqlParamsModel paramsOut
        ) {
            Sql = sql;
            ParamsIn = paramsIn;
            ParamsOut = paramsOut;
        }

        public string Sql { get; set; }

        public SqlParamsModel ParamsIn { get; set; }
        public SqlParamsModel ParamsOut { get; set; }
    }
}
