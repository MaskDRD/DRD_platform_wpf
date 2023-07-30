
namespace platform.BdMicroservices.model
{
    class SqlParamsInModel
    {
        public SqlParamsInModel(string nameSql, string nameBody)
        {
            NameSql = nameSql;
            NameBody = nameBody;
        }

        public string NameSql { get; set; }
        public string NameBody { get; set; }
    }
}
