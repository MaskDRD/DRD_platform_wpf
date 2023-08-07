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
            List<SqlParamsOutModel<MySqlDbType>> sqlParamsOutModel = new List<SqlParamsOutModel<MySqlDbType>>()
            {
                new SqlParamsOutModel<MySqlDbType>("check_login_", MySqlDbType.Bool),
                new SqlParamsOutModel<MySqlDbType>("check_email_", MySqlDbType.Bool),
                new SqlParamsOutModel<MySqlDbType>("check_nik_", MySqlDbType.Bool),
            };
            SqlModel<MySqlDbType> sqlModel = new SqlModel<MySqlDbType>("UserCheck", sqlParamsInModel, sqlParamsOutModel);
            return sqlModel;
        }

        public static SqlModel<MySqlDbType> TokenCreate()
        {
            List<SqlParamsInModel> sqlParamsInModel = new List<SqlParamsInModel>
            {
                new SqlParamsInModel("_value", "value"),
                new SqlParamsInModel("_id_user", "id_user"),
            };
            SqlModel<MySqlDbType> sqlModel = new SqlModel<MySqlDbType>("TokenCreate", sqlParamsInModel);
            return sqlModel;
        }

        public static SqlModel<MySqlDbType> UserCreate()
        {
            List<SqlParamsInModel> sqlParamsInModel = new List<SqlParamsInModel>
            {
                new SqlParamsInModel("_login", "login"),
                new SqlParamsInModel("_password", "password"),
                new SqlParamsInModel("_email", "email"),
                new SqlParamsInModel("_nik", "nik"),
            };

            SqlModel<MySqlDbType> sqlModel = new SqlModel<MySqlDbType>("UserCreate", sqlParamsInModel);
            return sqlModel;
        }

        public static SqlModel<MySqlDbType> UserGetWhereTokenId()
        {
            List<SqlParamsInModel> sqlParamsInModel = new List<SqlParamsInModel>
            {
                new SqlParamsInModel("_token_id", "id"),
            };

            SqlModel<MySqlDbType> sqlModel = new SqlModel<MySqlDbType>("UserGetWhereTokenId", sqlParamsInModel);
            return sqlModel;
        }
    }
}
