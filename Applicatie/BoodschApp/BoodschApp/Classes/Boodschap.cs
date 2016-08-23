using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoodschApp.Classes
{
    public class Boodschap
    {
        public Product Product { get; set; }
        public int Aantal { get; set; }

        public Boodschap(Product product, int aantal)
        {
            Product = product;
            Aantal = aantal;
        }

        //methods

        public override string ToString()
        {
            return Product.Naam + " - " + Aantal;
        }
    }
}
