using platform.BdMicroservices.model;

using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;

namespace platform.BdMicroservices.service
{
    class BdMySqlService: BdService
    {
        private MySqlConnection DbConnection { get; }

        public BdMySqlService(MySqlConnection dbConnection)
        {
            DbConnection = dbConnection;
            DbConnection.Open();
        }

        public override DataTable GetTablesSql(SqlModel<MySqlDbType> sqlModel, Dictionary<string, object> body)
        {
            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = InitSqlDataAdapter(sqlModel);
            if (sqlModel.ParamsIn.Count != 0)
            {
                SetInParams(sqlModel, body, adapter);
            }
            adapter.Fill(dataTable);
            return dataTable;
        }

        public override Dictionary<string, object> GetDictionarySql(SqlModel<MySqlDbType> sqlModel, Dictionary<string, object> body)
        {
            List<MySqlParameter> outputParam = new List<MySqlParameter>();
            MySqlDataAdapter adapter = InitSqlDataAdapter(sqlModel);

            if (sqlModel.ParamsOut.Count != 0)
            {
                outputParam = SetOutParams(sqlModel, adapter);
            }
         
            if (sqlModel.ParamsIn.Count != 0)
            {
                SetInParams(sqlModel, body, adapter);
            }

            adapter.SelectCommand.ExecuteNonQuery();
            return SetResultDictionary(outputParam);
        }

        private MySqlDataAdapter InitSqlDataAdapter(SqlModel<MySqlDbType> sqlModel)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter
            {
                SelectCommand = new MySqlCommand(sqlModel.Name, DbConnection)
            };
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            return adapter;
        }

        private Dictionary<string, object> SetResultDictionary(List<MySqlParameter> outputParam)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (MySqlParameter param in outputParam)
            {
                result.Add(param.ParameterName, param.Value);
            }
            return result;
        }

        private List<MySqlParameter> SetOutParams(SqlModel<MySqlDbType> sqlModel, MySqlDataAdapter adapter)
        {
            List<MySqlParameter> outputParam = new List<MySqlParameter>();
            foreach (SqlParamsOutModel<MySqlDbType> paramsOut in sqlModel.ParamsOut)
            {
                MySqlParameter mySqlParameter = new MySqlParameter(paramsOut.Name, paramsOut.Type)
                {
                    Direction = ParameterDirection.Output
                };
                outputParam.Add(mySqlParameter);
                adapter.SelectCommand.Parameters.Add(mySqlParameter);
            }
            return outputParam;
        }

        private void SetInParams(
            SqlModel<MySqlDbType> sqlModel, 
            Dictionary<string, object> body,
            MySqlDataAdapter adapter
        )
        {
            foreach (SqlParamsInModel paramsIn in sqlModel.ParamsIn)
            {
                if (body.ContainsKey(paramsIn.NameBody))
                {
                    adapter.SelectCommand.Parameters.Add(
                        new MySqlParameter(paramsIn.NameSql, body[paramsIn.NameBody])
                        {
                            Direction = ParameterDirection.Input
                        }
                   );
                }
            }
        }
    }
}
