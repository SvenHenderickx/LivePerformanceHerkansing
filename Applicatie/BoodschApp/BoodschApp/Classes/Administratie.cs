using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoodschApp.Classes
{
    public static class Administratie
    {
        public static Boodschappenlijst Boodschappenlijst { get; set; }
        public static List<Winkel> Winkels { get; set; }
        public static List<Gerecht> Gerechten { get; set; }
        public static List<Product> Producten { get; set; }

        //Methods
        public static void StartUp()
        {
            Winkels = new List<Winkel>();
            Gerechten = new List<Gerecht>();
            Producten = new List<Product>();
            ProductenDatabase();
            BoodschappenlijstDatabase();
            GerechtenDatabase();
            WinkelsDatabase();
        }

        /// <summary>
        /// Voegt gerecht toe aan de lijst van gerechten
        /// </summary>
        /// <param name="gerecht"></param>
        public static void GerechtToevoegen(Gerecht gerecht)
        {
            //
        }

        /// <summary>
        /// Voegt een winkel toe aan de lijst van winkels
        /// </summary>
        /// <param name="winkel"></param>
        public static void WinkelToevoegen(Winkel winkel)
        {
            //
        }

        /// <summary>
        /// Voegt een product toe aan de lijst van producten
        /// </summary>
        /// <param name="product"></param>
        public static void ProductToevoegen(Product product)
        {
            //
        }

        /// <summary>
        /// Sorteerd de combinaties van gerechten
        /// </summary>
        /// <returns></returns>
        public static List<ZuinigeGerechten> SorterenZuinigheid()
        {
            List<ZuinigeGerechten> tempZuinig = new List<ZuinigeGerechten>();
            tempZuinig = GetZuinigeGerechten();
            foreach (ZuinigeGerechten zg in tempZuinig)
            {
                List<ZuinigheidIngredrient> alleIngredrienten = new List<ZuinigheidIngredrient>();
                int count = 0;
                foreach (Gerecht g in zg.Gerechten)
                {
                    
                    foreach (Ingredrient i in g.Ingredrienten)
                    {
                        ZuinigheidIngredrient temp = new ZuinigheidIngredrient();
                        temp.ingredrient = i;
                        temp.id = count;
                        temp.perGerecht = 0;
                        temp.samen = 0;
                        temp.vermindering = 0;
                        alleIngredrienten.Add(temp);
                        
                    }
                    count++;
                }
                foreach (ZuinigheidIngredrient zi in alleIngredrienten)
                {
                    foreach (ZuinigheidIngredrient zig in alleIngredrienten)
                    {
                        if (zi.id != zig.id && zi.ingredrient.Product.Id == zig.ingredrient.Product.Id)
                        {
                            zi.perGerecht += 100 - zi.ingredrient.VerpakkingsProcent;
                            zi.samen = zi.samen + zi.ingredrient.VerpakkingsProcent + zig.ingredrient.VerpakkingsProcent;
                        }
                    }
                }
                int verminderingTotaal = 0;

                foreach (ZuinigheidIngredrient zi in alleIngredrienten)
                {
                    verminderingTotaal += zi.perGerecht - zi.samen;
                }
                zg.Vermindering = verminderingTotaal;
            }
            tempZuinig.Sort();
            return tempZuinig;
        }

        /// <summary>
        /// Geeft een overzicht van de combinaties van gerechten die samen het minste resten over laten
        /// </summary>
        public static List<ZuinigeGerechten> GetZuinigeGerechten()
        {
            List<ZuinigeGerechten> zuinigeGerechten = new List<ZuinigeGerechten>();
            ZuinigeGerechten nieuweZuinige = new ZuinigeGerechten();
            foreach (Gerecht g in Gerechten)
            {
                foreach (Gerecht ge in Gerechten)
                {
                    foreach (Gerecht ger in Gerechten)
                    {
                        foreach (Gerecht gere in Gerechten)
                        {
                            List<Gerecht> temp = new List<Gerecht>();
                            temp.Add(g);
                            temp.Add(ge);
                            temp.Add(ger);
                            temp.Add(gere);
                            int checkDouble = 0;
                            foreach (Gerecht _ger in temp)
                            {
                                if (_ger.Naam == g.Naam)
                                {
                                    checkDouble++;
                                }
                            }
                            foreach (Gerecht _ger in temp)
                            {
                                if (_ger.Naam == ge.Naam)
                                {
                                    checkDouble++;
                                }
                            }
                            foreach (Gerecht _ger in temp)
                            {
                                if (_ger.Naam == ger.Naam)
                                {
                                    checkDouble++;
                                }
                            }
                            foreach (Gerecht _ger in temp)
                            {
                                if (_ger.Naam == gere.Naam)
                                {
                                    checkDouble++;
                                }
                            }
                            if (checkDouble == 4 && CheckGeweest(zuinigeGerechten, new ZuinigeGerechten(temp)))
                            {
                                zuinigeGerechten.Add(new ZuinigeGerechten(temp));
                            }
                        }
                    }
                }
            }
            return zuinigeGerechten;
        }

        /// <summary>
        /// Kijkt in alle combinaties van gerechten of de combinatie al bestaat. DUS VERSCHILLENDE VOLGORDE IS HETZELFDE
        /// </summary>
        /// <param name="zuinigeGerechten"></param>
        /// <param name="nieuwe"></param>
        /// <returns></returns>
        public static bool CheckGeweest(List<ZuinigeGerechten> zuinigeGerechten, ZuinigeGerechten nieuwe)
        {
            foreach (ZuinigeGerechten zg in zuinigeGerechten)
            {
                int check = 0;
                foreach (Gerecht g in zg.Gerechten)
                {
                    if (nieuwe.Gerechten.Contains(g))
                    {
                        check++;
                    }
                }
                if (check == 4)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Haalt alle producten uit de database en zet ze in de producten lijst
        /// </summary>
        public static void ProductenDatabase()
        {
            try
            {
                Producten = DatabaseManager.GetAllProducten();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// haalt alle gerechten uit de database en zet ze in de gerechten lijst
        /// </summary>
        public static void GerechtenDatabase()
        {
            try
            {
                Gerechten = DatabaseManager.GetAllGerechtenMetProducten();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// haalt alle winkels van de database
        /// </summary>
        public static void WinkelsDatabase()
        {
            try
            {
                Winkels = DatabaseManager.AlleWinkelsMetProducten();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Haalt de boodschappenlijst van de database
        /// </summary>
        public static void BoodschappenlijstDatabase()
        {
            try
            {
                Boodschappenlijst = new Boodschappenlijst();
                Boodschappenlijst.VoegBoodschappenToe(DatabaseManager.GetAllBoodschappen(Producten));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
