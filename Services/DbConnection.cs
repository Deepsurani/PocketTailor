using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class DbConnection:IDisposable
    {
        public SqlConnection con;
        public SqlDataAdapter da;
        public SqlCommand cmd;
        public DataTable dt;

        public void MyCon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Dbcon"].ToString());
            con.Open();
        }
        public DbConnection()
        {
            MyCon();
        }
        public string AddUpdateDeleteData(string SqlQuery, Dictionary<string, object> Parameters)
        {
            try
            {
                cmd = new SqlCommand(SqlQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Parameters != null)
                {
                    foreach (var SingleParam in Parameters)
                    {
                        cmd.Parameters.AddWithValue(SingleParam.Key, SingleParam.Value);
                    }
                }
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    return "Your Data is Successfully Store.";
                }
                else
                {
                    return "Something Wrong in Database.";
                }

            }
            catch (Exception Ex)
            {
                return Ex.ToString();
            }


        }
        public Dictionary<string, object> AddUpdateDeleteData(string SqlQuery, Dictionary<string, object> InputParameters, Dictionary<string, SqlDbType> OutputParameters = null)
        {
            try
            {
                cmd = new SqlCommand(SqlQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add input parameters
                if (InputParameters != null)
                {
                    foreach (var SingleParam in InputParameters)
                    {
                        cmd.Parameters.AddWithValue(SingleParam.Key, SingleParam.Value ?? DBNull.Value);
                    }
                }

                // Add output parameters
                if (OutputParameters != null)
                {
                    foreach (var outParam in OutputParameters)
                    {
                        SqlParameter param = new SqlParameter(outParam.Key, outParam.Value)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(param);
                    }
                }

                cmd.ExecuteNonQuery();

                // Collect results (both output params and default status)
                Dictionary<string, object> results = new Dictionary<string, object>();

                // Add output parameters to dictionary
                if (OutputParameters != null)
                {
                    foreach (var outParam in OutputParameters)
                    {
                        results[outParam.Key] = cmd.Parameters[outParam.Key].Value;
                    }
                }
                else
                {
                    results["Status"] = "Success";
                }

                return results;

            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>
                {
                    { "Error", ex.Message }
                };
            }
        }

        public Dictionary<string , object> GetData(string SqlQuery, Dictionary<string, object> Parameters = null)
        {
            try
            {
                cmd = new SqlCommand(SqlQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Parameters != null)
                {
                    foreach (var SingleParam in Parameters)
                    {
                        cmd.Parameters.AddWithValue(SingleParam.Key, SingleParam.Value);
                    }
                }
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                Dictionary<string, object> Result = new Dictionary<string, object>();
                Result["Data"] = dt;
                return Result;
            }
            catch (Exception Ex)
            {
                return new Dictionary<string, object>
                {
                    { "Error", Ex.Message }
                };
            }
        }

        public Dictionary<string,object> GetData(string Sqlquery)
        {
            try
            {
                cmd = new SqlCommand(Sqlquery, con);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                Dictionary<string, object> Result = new Dictionary<string, object>();
                Result["Data"] = dt;
                return Result;
            }
            catch (Exception Ex)
            {
                return new Dictionary<string, object>
                {
                    { "Error", Ex.Message }
                };
            }
        }
        public void Dispose()
        {
            if (cmd != null)
            {
                cmd.Dispose();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
            if (da != null)
            {
                da.Dispose();
            }
            if (dt != null)
            {
                dt.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}