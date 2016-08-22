using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoodschApp.Classes
{
    public class Ingredrient
    {
        public Product Product { get; set; }
        public int VerpakkingsProcent { get; set; }

        public Ingredrient(Product product, int verpakkingsProcent)
        {
            Product = product;
            VerpakkingsProcent = verpakkingsProcent;
        }
    }
}
