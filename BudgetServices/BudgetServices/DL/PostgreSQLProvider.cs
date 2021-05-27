using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Npgsql;
using System.Data.Common;
using System.Data;

namespace BudgetServices.DL
{
    public class PostgreSQLProvider : ISqlProvider
    {
        const string CONNECTION_STRING = "Server=127.0.0.1;User ID=postgres;Password=$knvZ*8V46!G;Port=5432;Database=rodedevelopments;";

        public static DbConnection GetConnection()
        {
            return new NpgsqlConnection(CONNECTION_STRING);
        }

        public static int ExecuteNonQuery(SqlHelper helper)
        {
            Npgsql.NpgsqlCommand cmd = GetCommand(helper);

            return cmd.ExecuteNonQuery();
        }

        public static object ExecuteScalar(SqlHelper helper)
        {
            NpgsqlCommand cmd = GetCommand(helper);

            return cmd.ExecuteScalar();
        }

        public static System.Data.IDataReader ExecuteReader(SqlHelper helper, DbConnection connection)
        {
            NpgsqlCommand cmd = GetCommand(helper, connection);

            return cmd.ExecuteReader();
        }

        private static NpgsqlCommand GetCommand(SqlHelper helper, DbConnection connection = null)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            helper.Query = helper.Query.Trim();
            if (!helper.Query.EndsWith(";")) {
                helper.Query += ";";
            }
            cmd.CommandText = helper.Query;

            foreach (DbParameter parameter in helper.GetParameters()) {
                cmd.Parameters.Add(parameter);
            }

            if (connection != null) {
                if (!typeof(NpgsqlConnection).IsInstanceOfType(connection)) {
                    throw new Exception("Invalid connection passed. Must be of type 'Npgsql.NpgsqlConnection'");
                }
            }
            else {
                connection = GetConnection();
            }
            if (connection.State != System.Data.ConnectionState.Open) {
                connection.Open();
            }
            cmd.Connection = (NpgsqlConnection)connection;

            System.Diagnostics.Debug.WriteLine(GetFormattedSQLStatement(helper));
            //System.Console.WriteLine(helper.GetFormattedSQLStatement());

            return cmd;
        }

        public static string GetFormattedSQLStatement(SqlHelper helper)
        {
            List<DbParameter> parameterList = helper.GetParameters();
            if (parameterList.Count == 0) {
                return helper.Query;
            }

            System.Text.StringBuilder sqlBuilder = new System.Text.StringBuilder();
            System.Text.StringBuilder executeBuilder = new System.Text.StringBuilder();
            string modifiedQuery = helper.Query;

            sqlBuilder.Append("PREPARE formattedQuery(");
            executeBuilder.Append("EXECUTE formattedQuery(");

            for (Int32 i = 0; i< parameterList.Count; i++) {
                DbParameter parameter = parameterList[i];
                if (i != 0) {
                    sqlBuilder.Append(", ");
                    executeBuilder.Append(", ");
                }
                sqlBuilder.Append(GetPrintableType(parameter.DbType));
                executeBuilder.Append(GetPrintableValue(parameter));

                modifiedQuery = modifiedQuery.Replace(parameter.ParameterName, "$" + (i + 1).ToString());
            }

            sqlBuilder.Append(") AS \n");
            executeBuilder.Append(");");

            sqlBuilder.Append(modifiedQuery + ";\n");
            sqlBuilder.Append(executeBuilder);

            return sqlBuilder.ToString();
        }

        private static string GetPrintableType(DbType dbtype)
        {
            string retValue = null;
            switch (dbtype) {
                case DbType.String:
                    retValue = "VARCHAR";
                    break;
                case DbType.DateTime:
                    retValue = "TIMESTAMP";
                    break;
                default:
                    retValue = dbtype.ToString();
                    break;
            }

            return retValue;
        }

        private static string GetPrintableValue(DbParameter parameter)
        {
            string retValue = null;
            switch (parameter.DbType) {
                case DbType.Int32:
                    retValue = parameter.Value.ToString();
                    break;
                default:
                    retValue = "'" + parameter.Value.ToString() + "'";
                    break;
            }

            return retValue;
        }
    }
}
