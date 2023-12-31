﻿using MySqlConnector;
using platform.BdMicroservices.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace platform.BdMicroservices.service
{
    abstract class BdService
    {
        public virtual DataTable GetTablesSql(
            SqlModel<MySqlDbType> sqlModel, 
            Dictionary<string, object> body
        )
        {
            throw new Exception("Требуется реализация метода GetTablesSql");
        }

        public virtual Task<Dictionary<string, object>> GetDictionarySql(
            SqlModel<MySqlDbType> sqlModel, 
            Dictionary<string, object> body
        ) 
        {
            throw new Exception("Требуется реализация метода GetDictionarySql");
        }
    }
}
