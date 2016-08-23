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

        /// <summary>
        /// Alle producten ophalen uit de database
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// De hoofdmethode waarmee alle gerechten worden toegevoegd aan het systeem. Deze haalt eerst de gerechten op en voegt daarna de ingredrienten erbij
        /// </summary>
        /// <returns></returns>
        public static List<Gerecht> GetAllGerechtenMetProducten()
        {
            List<Gerecht> gerechten = new List<Gerecht>();
            gerechten = GetAllGerechten();
            foreach (Gerecht g in gerechten)
            {
                g.VoegIngredrientenToe(GetIngredrientenVanGerecht(g, GetAllProducten()));
            }
            return gerechten;
        }

        /// <summary>
        /// Alle gerechten die in de database staan ophalen
        /// </summary>
        /// <returns></returns>
        public static List<Gerecht> GetAllGerechten()
        {
            try
            {
                List<Gerecht> tempGerechten = new List<Gerecht>();
                OracleCommand cmd = CreateOracleCommand("SELECT * FROM Gerecht");
                OracleDataReader reader = ExecuteQuery(cmd);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string naam = Convert.ToString(reader["Naam"]);
                    tempGerechten.Add(new Gerecht(id, naam));
                }
                return tempGerechten;
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

        /// <summary>
        /// haalt alle ingredrienten op van een gerecht, ook de producten zijn toegevoegd
        /// </summary>
        /// <param name="gerecht"></param>
        /// <param name="producten"></param>
        /// <returns>De lijst van ingredrient</returns>
        public static List<Ingredrient> GetIngredrientenVanGerecht(Gerecht gerecht, List<Product> producten)
        {
            try
            {
                List<Ingredrient> tempIngredrients = new List<Ingredrient>();
                OracleCommand cmd = CreateOracleCommand("SELECT * FROM Gerecht_product WHERE gerechtId = :gerechtId");
                cmd.Parameters.Add("gerechtId", gerecht.Id);
                OracleDataReader reader = ExecuteQuery(cmd);
                while (reader.Read())
                {
                    int productId = Convert.ToInt32(reader["productId"]);
                    int verpakkingsProcent = Convert.ToInt32(reader["verpakkingsProcent"]);
                    Product product = null;
                    foreach (Product p in producten)
                    {
                        if (p.Id == productId)
                        {
                            product = p;
                        }
                    }
                    tempIngredrients.Add(new Ingredrient(product, verpakkingsProcent));
                }
                return tempIngredrients;
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

        /// <summary>
        /// Alle winkels met daarbij alle producten die zij verkopen
        /// </summary>
        /// <returns></returns>
        public static List<Winkel> AlleWinkelsMetProducten()
        {
            List<Winkel> tempWinkels = new List<Winkel>();
            tempWinkels = GetAllWinkels();
            foreach (Winkel w in tempWinkels)
            {
                w.VoegProductentoe(GetProductenFromWinkel(w, Administratie.Producten));
            }
            return tempWinkels;
        }

        public static List<Winkel> GetAllWinkels()
        {
            try
            {
                List<Winkel> tempWinkels = new List<Winkel>();
                OracleCommand cmd = CreateOracleCommand("SELECT * FROM Winkel");
                OracleDataReader reader = ExecuteQuery(cmd);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string naam = Convert.ToString(reader["Naam"]);
                    tempWinkels.Add(new Winkel(id, naam));
                }
                return tempWinkels;
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

        public static List<WinkelOrde> GetProductenFromWinkel(Winkel winkel, List<Product> producten)
        {
            try
            { 
                List<WinkelOrde> tempWinkels = new List<WinkelOrde>();
                OracleCommand cmd = CreateOracleCommand("SELECT * FROM Winkel_product WHERE winkelId = :winkelId");
                cmd.Parameters.Add("winkelId", winkel.Id);
                OracleDataReader reader = ExecuteQuery(cmd);
                while (reader.Read())
                {
                    int productId = Convert.ToInt32(reader["productId"]);
                    int looproute = Convert.ToInt32(reader["looproute"]);
                    Product product = null;
                    foreach (Product p in producten)
                    {
                        if (p.Id == productId)
                        {
                            product = p;
                        }
                    }
                    tempWinkels.Add(new WinkelOrde(product, looproute));
                }
                return tempWinkels;
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

