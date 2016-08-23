using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoodschApp.Exceptions;

namespace BoodschApp.Classes
{
    public class Boodschappenlijst
    {
        public List<Boodschap> Boodschappen { get; set; }

        public Boodschappenlijst(List<Boodschap> boodschappen)
        {
            Boodschappen = boodschappen;
        }

        public Boodschappenlijst()
        {
            Boodschappen = new List<Boodschap>();
        }

        //methods

        /// <summary>
        /// Voegt een product toe aan de lijst
        /// </summary>
        /// <param name="product"></param>
        public void VoegBoodschapToe(Boodschap boodschap)
        {
            foreach (Boodschap b in Boodschappen)
            {
                if (b.Product.Id == boodschap.Product.Id)
                {
                    throw new BoodschapException("Boodschap is al toegevoegd.");
                }
            }
            if (boodschap.Aantal >= 1)
            {
                Boodschappen.Add(boodschap);
            }
            else
            {
                throw new BoodschapException("Kan dat aantal niet toevoegen.");
            }
        }

        public void VoegGerechtToe(Gerecht gerecht)
        {
            foreach (Boodschap b in Boodschappen)
            {
                foreach (Ingredrient g in gerecht.Ingredrienten)
                {
                    if (b.Product.Id == g.Product.Id)
                    {
                        b.Aantal++;
                    }
                    else
                    {
                        Boodschappen.Add(new Boodschap(g.Product, 1));
                    }
                }
            }
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
