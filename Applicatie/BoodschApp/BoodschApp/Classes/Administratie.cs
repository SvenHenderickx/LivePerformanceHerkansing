﻿using System;
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
        public static void StartUp()
        {
            Boodschappenlijst = new Boodschappenlijst();
            Winkels = new List<Winkel>();
            Gerechten = new List<Gerecht>();
            Producten = new List<Product>();

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
        /// Geeft een overzicht van de combinaties van gerechten die samen het minste resten over laten
        /// </summary>
        public static List<string> SorterenWeinigRestjes()
        {
            return null;
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
    }
}
