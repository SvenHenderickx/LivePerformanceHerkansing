using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoodschApp.Classes
{
    public class Boodschappenlijst
    {
        public List<Boodschap> Boodschappen { get; set; }

        public Boodschappenlijst(List<Boodschap> boodschappen)
        {
            Boodschappen = boodschappen;
        }

        //methods

        /// <summary>
        /// Voegt een product toe aan de lijst
        /// </summary>
        /// <param name="product"></param>
        /// <returns>False als niet is toegevoegd anders true</returns>
        public bool VoegProductToe(Product product)
        {
            return false;
        }

        /// <summary>
        /// Sorteert het boodschappenlijstje op basis van de looproute
        /// </summary>
        /// <param name="winkel"></param>
        public void SorteerLoopRoute(Winkel winkel)
        {
            //implement
        }

        /// <summary>
        /// Exporteert het gehele lijstje naar een tekstbestand
        /// </summary>
        /// <param name="path"></param>
        /// <returns>geeft aan of het is geslaagd</returns>
        public bool Exporteer(string path)
        {
            return false;
        }
    }
}
