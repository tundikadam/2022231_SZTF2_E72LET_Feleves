using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET
{
    internal class Visszatero:ITeendo
    {
        public int Prioritas
        {
            get
            {
                return 4;
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
        public int rendszeresseg { get; set; }
        public int elvegzes_szama = 0;

        public Visszatero(string nev, int rendszeresseg, int idotartam)
        {
            this.nev = nev;
            this.rendszeresseg = rendszeresseg;
            this.idotartam = idotartam;
        }

        public ITeendo Kovetkezo { get; set; }
    }
}
