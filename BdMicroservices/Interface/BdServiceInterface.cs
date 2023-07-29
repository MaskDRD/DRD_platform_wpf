using platform.BdMicroservices.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace platform.BdMicroservices.Interface
{
    interface BdServiceInterface
    {
        DbConnection dbConnection { get; set; }

        DataTable GetDataTable(SqlModel sqlModel, Dictionary<string, object> body);
        
        Dictionary<string, object> GetSql(SqlModel sqlModel, Dictionary<string, object> body);

        void RunSql(SqlModel sqlModel, Dictionary<string, object> body);

        void SetOutParams();
       
        void SetInParams();
    }
}
