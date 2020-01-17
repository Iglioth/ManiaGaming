 using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ManiaGaming.Context.MSSQLContext
{
    public abstract class BaseMSSQLContext
    {
        private readonly string connectionString;
        public BaseMSSQLContext(IConfiguration config)
        {
            connectionString = config.GetConnectionString("Development");
        }


        public DataSet ExecuteSql(string sql, List<KeyValuePair<string, string>> parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();

                foreach (KeyValuePair<string, string> kvp in parameters)
                {
                    SqlParameter param = new SqlParameter
                    {
                        ParameterName = "@" + kvp.Key,
                        Value = kvp.Value
                    };
                    cmd.Parameters.Add(param);
                }

                cmd.CommandText = sql;
                da.SelectCommand = cmd;

                conn.Open();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExecuteInsert(string sql, List<KeyValuePair<string, string>> parameters)
        {
            int id = new int();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();

                foreach (KeyValuePair<string, string> kvp in parameters)
                {
                    SqlParameter param = new SqlParameter
                    {
                        ParameterName = "@" + kvp.Key,
                        Value = kvp.Value
                    };
                    cmd.Parameters.Add(param);
                }

                cmd.CommandText = sql;

                conn.Open();
                id = (int)cmd.ExecuteScalar();
                conn.Close();

                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
