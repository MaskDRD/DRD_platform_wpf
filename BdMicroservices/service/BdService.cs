using platform.BdMicroservices.model;
using System;
using System.Collections.Generic;
using System.Data;

namespace platform.BdMicroservices.service
{
    abstract class BdService
    {
        public virtual DataTable GetTablesSql(
            SqlModel sqlModel, 
            Dictionary<string, object> body
        )
        {
            throw new Exception("Требуется реализация метода GetTablesSql");
        }

        public virtual Dictionary<string, object> GetDictionarySql(
            SqlModel sqlModel, 
            Dictionary<string, object> body
        ) 
        {
            throw new Exception("Требуется реализация метода GetDictionarySql");
        }
    }
}
