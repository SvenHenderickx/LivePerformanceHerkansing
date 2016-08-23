using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoodschApp.Classes
{
    public class Winkel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<WinkelOrde> Producten { get; set; }

        public Winkel(int id, string naam)
        {
            Id = id;
            Naam = naam;
            Producten = new List<WinkelOrde>();
        }

        //methods
        /// <summary>
        /// Voegt een lijst van producten toe die geordend zijn
        /// </summary>
        /// <param name="producten"></param>
        public void VoegProductentoe(List<WinkelOrde> producten)
        {
            foreach (WinkelOrde wo in producten)
            {
                Producten.Add(wo);
            }
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}
