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

        public Gerecht(int id, List<Ingredrient> ingredrienten)
        {
            Id = id;
            Ingredrienten = ingredrienten;
        }
    }
}
