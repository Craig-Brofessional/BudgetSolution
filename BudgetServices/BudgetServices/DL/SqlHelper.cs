using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;

namespace BudgetServices.DL
{
    public class SqlHelper
    {
        public string Query;
        private List<DbParameter> Parameters = new List<DbParameter>();

        //constructor

        public void AddParameter(string parameterName, object value, System.Data.DbType dbType)
        {
            Npgsql.NpgsqlParameter parameter = new Npgsql.NpgsqlParameter(parameterName, dbType);
            parameter.Value = value;
            Parameters.Add(parameter);
        }

        public List<DbParameter> GetParameters()
        {
            return Parameters;
        }
    }
}
