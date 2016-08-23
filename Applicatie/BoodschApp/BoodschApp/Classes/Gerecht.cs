using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoodschApp.Classes
{
    public class Gerecht
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<Ingredrient> Ingredrienten { get; set; }

        public Gerecht(int id, string naam)
        {
            Id = id;
            Naam = naam;
            Ingredrienten = new List<Ingredrient>();
        }

        //methods

        /// <summary>
        /// Voegt een ingredrient toe aan het gerecht
        /// </summary>
        /// <param name="ingredrient"></param>
        public void VoegIngredrientToe(Ingredrient ingredrient)
        {
            Ingredrienten.Add(ingredrient);
        }

        public void VoegIngredrientenToe(List<Ingredrient> inv)
        {
            foreach (Ingredrient i in inv)
            {
                Ingredrienten.Add(i);
            }
        }
        /// <summary>
        /// Word gebruikt om het object te laten zien in tekst
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Naam;
        }
    }
}
