using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoodschApp.Classes
{
    public class Product
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime Houdbaarheid { get; set; }
        public string Hoeveelheid { get; set; }

        public Product(int id, string naam, string hoeveelheid)
        {
            Id = id;
            Naam = naam;
            Hoeveelheid = hoeveelheid;
        }

        public override string ToString()
        {
            return Naam + " - " + Hoeveelheid.ToString();
        }
    }
}
