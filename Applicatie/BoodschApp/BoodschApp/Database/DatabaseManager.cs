using BoodschApp.Classes;

namespace BoodschApp
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Oracle.DataAccess;
    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;

    public static class DatabaseManager
    {
        /// <summary>
        /// Database connection; uses Connectionstring
        /// </summary>
        private static OracleConnection _Connection = new OracleConnection(_ConnectionString);
        /// <summary>
        /// Temp data for connecting to the database; [Username], [Password], [server-IP]
        /// </summary>
        private const string _ConnectionId = "dbi318943",

            _ConnectionPassword = "password",

            _ConnectionAddress = "//fhictora01.fhict.local:1521/fhictora";


        private static string _ConnectionString
        {
            /// <summary>
            /// Data used to create the database connection 
            /// </summary>
            get
            {
                return string.Format("Data Source={0};Persist Security Info=True;User Id={1};Password={2}", _ConnectionAddress, _ConnectionId, _ConnectionPassword);
            }
        }


        /// <summary>
        /// Creates the command with sql query and database connection information
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private static OracleCommand CreateOracleCommand(string sql)
        {
            OracleCommand command = new OracleCommand(sql, _Connection);
            command.CommandType = System.Data.CommandType.Text;

            return command;
        }

        /// <summary>
        ///  Opens the connection with the database, returns the reader
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private static OracleDataReader ExecuteQuery(OracleCommand command)
        {
            try
            {
                if (_Connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        _Connection.Open();
                    }
                    catch (OracleException exc)
                    {
                        Debug.WriteLine("Database connection failed!\n" + exc.Message);
                        throw;
                    }
                }

                OracleDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch (OracleException)
            {
                return null;
            }
        }

        /// <summary>
        /// Opens the connection with the database and inserts the given information, returns true if insert worked
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private static bool ExecuteNonQuery(OracleCommand command)
        {
            try
            {
                if (_Connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        _Connection.Open();
                    }
                    catch (OracleException exc)
                    {
                        Debug.WriteLine("Database connection failed!\n" + exc.Message);
                        throw;
                    }
                }

                command.ExecuteNonQuery();
                return true;
            }
            catch (OracleException)
            {
                return false;
            }
        }

        public static void TestConnection()
        {
            using (OracleConnection con = _Connection)
            {
                try
                {
                    con.Open();
                    con.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public static List<Product> GetAllProducten()
        {
                try
                {
                    List<Product> tempProducten = new List<Product>();
                    OracleCommand cmd = CreateOracleCommand("SELECT * FROM Product");
                    OracleDataReader reader = ExecuteQuery(cmd);
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        string naam = Convert.ToString(reader["Naam"]);
                        string hoeveelheid = Convert.ToString(reader["Hoeveelheid"]);
                        tempProducten.Add(new Product(id, naam, hoeveelheid));
                    }
                    return tempProducten;
                }
                catch (OracleException e)
                {

                    throw e;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    _Connection.Close();
                }
        }
    }
}

