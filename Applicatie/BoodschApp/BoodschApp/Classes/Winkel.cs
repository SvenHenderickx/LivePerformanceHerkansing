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
        public List<Product> Producten { get; set; }

        public Winkel(int id, string naam, List<Product> producten)
        {
            Id = id;
            Naam = naam;
            Producten = producten;
        }

        public Winkel(int id, string naam)
        {
            Id = id;
            Naam = naam;
            Producten = new List<Product>();
        }
    }
}
