using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace SandysBakery.DataAccess.Adaptors
{
    public class DataAdaptor : IDataAdaptor
    {
        public DataAdaptor()
        {
            //Constructor Logic
        }
        public string GetDbConnection
        {
            get { return WebConfigurationManager.ConnectionStrings["SandysBakeryConnection"].ConnectionString; }
        }
        public DataTable FetchData(string query, SqlParameter[] sqlParameters, bool isProc)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDbConnection);
                DataTable dataTable = new DataTable();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = query;
                    if (isProc)
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                    }
                    if (sqlParameters != null)
                    {
                        sqlCommand.Parameters.AddRange(sqlParameters);
                    }
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                }
                return dataTable;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int ExecuteQuery(string query, SqlParameter[] sqlParameters, bool isProc)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDbConnection);
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = query;
                    if (isProc)
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                    }
                    if (sqlParameters != null)
                    {
                        sqlCommand.Parameters.AddRange(sqlParameters);
                    }
                    int cmd = sqlCommand.ExecuteNonQuery();
                    return cmd;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int ExecuteQuery(string query, SqlParameter[] sqlParameters, bool isProc, ref int primaryKey)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDbConnection);
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = query;
                    if (isProc)
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                    }
                    if (sqlParameters != null)
                    {
                        sqlCommand.Parameters.AddRange(sqlParameters);
                    }
                    int cmd = sqlCommand.ExecuteNonQuery();
                    primaryKey = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    return cmd;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}