using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET
{
    internal class Nap
    {
        public Nap Kovetkezo { get; set; }

        public ITeendo[] orak = new ITeendo[24];
        public DateTime datum { get; set; }
        public Nap(DateTime datum)
        {
            this.datum = datum;
        }
    }
}
