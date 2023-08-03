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

            List<SqlParamsOutModel<MySqlDbType>> sqlParamsOutModel = new List<SqlParamsOutModel<MySqlDbType>>()
            {
                new SqlParamsOutModel<MySqlDbType>("id", MySqlDbType.Int64)
            };
            SqlModel<MySqlDbType> sqlModel = new SqlModel<MySqlDbType>("TokenCreate", sqlParamsInModel, sqlParamsOutModel);
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

            List<SqlParamsOutModel<MySqlDbType>> sqlParamsOutModel = new List<SqlParamsOutModel<MySqlDbType>>()
            {
                new SqlParamsOutModel<MySqlDbType>("id", MySqlDbType.Int64)
            };
            SqlModel<MySqlDbType> sqlModel = new SqlModel<MySqlDbType>("UserCreate", sqlParamsInModel, sqlParamsOutModel);
            return sqlModel;
        }

        public static SqlModel<MySqlDbType> UserGetWhereTokenId()
        {
            List<SqlParamsInModel> sqlParamsInModel = new List<SqlParamsInModel>
            {
                new SqlParamsInModel("_token_id", "id"),
            };

            List<SqlParamsOutModel<MySqlDbType>> sqlParamsOutModel = new List<SqlParamsOutModel<MySqlDbType>>()
            {
                new SqlParamsOutModel<MySqlDbType>("id", MySqlDbType.Int64),
                new SqlParamsOutModel<MySqlDbType>("login", MySqlDbType.String),
                new SqlParamsOutModel<MySqlDbType>("email", MySqlDbType.String),
                new SqlParamsOutModel<MySqlDbType>("nik", MySqlDbType.String),
                new SqlParamsOutModel<MySqlDbType>("check_active", MySqlDbType.Bool),
                new SqlParamsOutModel<MySqlDbType>("check_conf_email", MySqlDbType.Bool),
                new SqlParamsOutModel<MySqlDbType>("token_id", MySqlDbType.String),
                new SqlParamsOutModel<MySqlDbType>("token_value", MySqlDbType.String),
                new SqlParamsOutModel<MySqlDbType>("token_date", MySqlDbType.Date),
            };
            SqlModel<MySqlDbType> sqlModel = new SqlModel<MySqlDbType>("UserGetWhereTokenId", sqlParamsInModel, sqlParamsOutModel);
            return sqlModel;
        }
    }
}
