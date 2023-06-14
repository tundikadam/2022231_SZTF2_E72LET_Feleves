using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET
{
    internal class Mindennapi:ITeendo
    {
        public int Prioritas
        {
            get
            {
                return 5;
            }
        }
        public int Idotartam
        {
            get
            {
                return idotartam;
            }
        }

        int idotartam;
        public string nev { get; set; }
        public int kezdes { get; set; }

        public Mindennapi(string nev, int idotartam, int kezdes)
        {
            this.idotartam = idotartam;
            this.nev = nev;
            this.kezdes = kezdes;
        }

        public ITeendo Kovetkezo { get; set; }
    }
}
