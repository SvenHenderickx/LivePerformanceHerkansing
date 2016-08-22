using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoodschApp.Classes
{
    public static class Administratie
    {
        public static Boodschappenlijst Boodschappenlijst { get; set; }
        public static List<Winkel> Winkels { get; set; }
        public static List<Gerecht> Gerechten { get; set; }
        public static List<Product> Producten { get; set; }

        //Methods

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
        /// Geeft een overzicht van de combinaties van gerechten die samen het minste resten over laten
        /// </summary>
        public static List<string> SorterenWeinigRestjes()
        {
            return null;
        }

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
    }
}
