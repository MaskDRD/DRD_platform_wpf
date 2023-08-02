using MySqlConnector;
using platform.BdMicroservices.model;

using System.Collections.Generic;

namespace platform.AuthMicroservices.config
{
    static class AuthConfigBd
    {
        public static SqlModel<MySqlDbType> UserCheck()
        {
            List<SqlParamsInModel> sqlParamsInModel = new List<SqlParamsInModel>
            {
                new SqlParamsInModel("_login", "login"),
                new SqlParamsInModel("_email", "email"),
                new SqlParamsInModel("_nik", "nik"),
            };
            SqlModel<MySqlDbType> sqlModel = new SqlModel<MySqlDbType>("UserCheck", sqlParamsInModel);
            return sqlModel;
        }

        public static SqlModel<MySqlDbType> TokenCreate()
        {
            List<SqlParamsInModel> sqlParamsInModel = new List<SqlParamsInModel>
            {
                new SqlParamsInModel("_value", "value"),
                new SqlParamsInModel("_id_user", "id_user"),
            };

            List<SqlParamsOutModel<MySqlDbType>> sqlParamsOutModel = new List<SqlParamsOutModel<MySqlDbType>>()
            {
                new SqlParamsOutModel<MySqlDbType>("id", MySqlDbType.Int64)
            };
            SqlModel<MySqlDbType> sqlModel = new SqlModel<MySqlDbType>("TokenCreate", sqlParamsInModel, sqlParamsOutModel);
            return sqlModel;
        }
    }
}
