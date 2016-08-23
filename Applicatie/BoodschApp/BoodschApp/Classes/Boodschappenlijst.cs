using System;
using System.Collections.Generic;
using System.IO;
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
                DatabaseManager.BoodschapToevoegen(boodschap);
            }
            else
            {
                throw new BoodschapException("Kan dat aantal niet toevoegen.");
            }
        }

        /// <summary>
        /// Voegt alle boodschappen toe aan de boodschappenlijst
        /// </summary>
        /// <param name="inv"></param>
        public void VoegBoodschappenToe(List<Boodschap> inv)
        {
            foreach (Boodschap b in inv)
            {
                Boodschappen.Add(b);
            }
        }

        /// <summary>
        /// Voegt een gerecht toe, dit betekend alle producten van een gerecht
        /// </summary>
        /// <param name="gerecht"></param>
        public void VoegGerechtToe(Gerecht gerecht)
        {
            List<Ingredrient> tempIngredrients = new List<Ingredrient>();
            foreach (Boodschap b in Boodschappen)
            {
                foreach (Ingredrient g in gerecht.Ingredrienten)
                {
                    if (g.Product.Id == b.Product.Id)
                    {
                        b.Aantal++;
                        DatabaseManager.BoodschappenAantalAanpassen(b);
                        tempIngredrients.Add(g);
                    }
                }
            }
            if (Boodschappen.Count == 0)
            {
                foreach (Ingredrient i in gerecht.Ingredrienten)
                {
                    Boodschappen.Add(new Boodschap(i.Product, 1));
                    DatabaseManager.BoodschapToevoegen(new Boodschap(i.Product, 1));
                }
            }
            else
            {
                foreach (Ingredrient i in gerecht.Ingredrienten)
                {
                    if (!tempIngredrients.Contains(i))
                    {
                        Boodschappen.Add(new Boodschap(i.Product, 1));
                        DatabaseManager.BoodschapToevoegen(new Boodschap(i.Product, 1));
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
            List<Boodschap> tempBoodschappen = new List<Boodschap>();
            if (Boodschappen.Count == 0)
            {
                throw new BoodschapException("Boodscappenlijst is leeg.");
            }
            winkel.Producten.Sort();
            foreach (WinkelOrde wo in winkel.Producten)
            {
                foreach (Boodschap b in Boodschappen)
                {
                    if (b.Product.Id == wo.Product.Id)
                    {
                        if (!tempBoodschappen.Contains(b))
                        {
                            tempBoodschappen.Add(b);
                        }
                    }
                }
            }
            Boodschappen = tempBoodschappen;
        }

        /// <summary>
        /// Exporteert het gehele lijstje naar een tekstbestand
        /// </summary>
        /// <param name="path"></param>
        /// <returns>geeft aan of het is geslaagd</returns>
        public void Exporteer(string path)
        {
            using (StreamWriter stream = new StreamWriter(path + "/boodschappenlijst.txt"))
            {
                if (Boodschappen.Count == 0)
                {
                    throw new BoodschapException("Boodschappenlijst is leeg.");
                }
                else
                {
                    foreach (Boodschap b in Boodschappen)
                    {
                        stream.WriteLine(b.Aantal + "\t" + b.Product.Naam);
                    }
                }
            }
        }

        /// <summary>
        /// Alle boodschappen uit de lijst halen
        /// </summary>
        public void VerwijderBoodschappen()
        {
            DatabaseManager.BoodschappenVerwijderen();
        }
    }
}
