using System.Collections.Generic;

namespace platform.BdMicroservices.model
{
    class SqlModel<T>
    {
        public SqlModel(string name) {
            Name = name;
        }

        public SqlModel(
            string name,
            List<SqlParamsInModel> paramsIn
        ) {
            Name = name;
            ParamsIn = paramsIn;
        }

        public SqlModel(
            string name,
            List<SqlParamsInModel> paramsIn,
            List<SqlParamsOutModel<T>> paramsOut
        ) {
            Name = name;
            ParamsIn = paramsIn;
            ParamsOut = paramsOut;
        }

        public string Name { get; set; }

        public List<SqlParamsInModel> ParamsIn { get; set; }
        public List<SqlParamsOutModel<T>> ParamsOut { get; set; }
    }
}
