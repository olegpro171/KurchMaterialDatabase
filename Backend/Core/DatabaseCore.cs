using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Exceptions;
using Npgsql;


namespace Backend.Core
{
    public class DatabaseCore
    {
        // Npgsql
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private ConnectionData? connectionData;
        public ConnectionData ConnectionData { set { connectionData = value; } }
        private NpgsqlDataReader? reader;
        public bool isConnected { get { return conn.State == ConnectionState.Open; } }

        // Data Table
        private DataTable dataTable;
        public DataTable ResponceTable { get { return dataTable.Copy(); } }

        // Constructor
        public DatabaseCore()
        {
            conn = new NpgsqlConnection();
            cmd = new NpgsqlCommand();
            dataTable = new DataTable();
        }

        // Methods
        public void OpenConnection()
        {
            if (connectionData == null)
            {
                throw new ArgumentNullException("Connection data was not provided");
            }

            if (conn.State != ConnectionState.Open)
            {
                conn.ConnectionString = connectionData.ToString();
                conn.Open();
                cmd.Parameters.Clear();
            }
        }

        public void CloseConnection()
        {
            if (conn.State != ConnectionState.Closed)
            {
                cmd.Parameters.Clear();
                conn.Close();
            }
        }

        public bool ExecuteSQL(string sql)
        {
            cmd.Connection = conn;
            cmd.CommandText = sql;

            try
            {
                // Check if the command is a SELECT statement
                if (cmd.CommandText.Trim().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                {
                    reader = cmd.ExecuteReader();
                    dataTable.Reset();
                    dataTable.Load(reader);
                    return true; // Success
                }
                else
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true; // Success
                    }
                    else
                    {
                        return false; // Failure (no rows affected)
                    }
                }
            }
            catch (PostgresException ex)
            {
                if (ex.Message.StartsWith("42703:"))
                {
                    throw new WrongColumnNameException($"Table does not contain specified column.\nQuery :\"{sql}\".", ex);
                }
                else 
                { 
                    throw;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public void AddParamWithValue(string name, object value)
        {
            cmd.Parameters.AddWithValue(name, value ?? DBNull.Value);
        }

        public void ClearParams()
        {
            cmd.Parameters.Clear();
        }
    }
}
