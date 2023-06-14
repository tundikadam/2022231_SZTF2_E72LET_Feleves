using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET
{
    internal class Egyszeri:ITeendo
    {
        public int Prioritas
        {
            get
            {
                return prioritas;
            }
        }
        public int Idotartam
        {
            get
            {
                return idotartam;
            }
            set {; }
        }

        public int idotartam;
        public string nev { get; }
        public DateTime hatarido;
        int prioritas;

        public Egyszeri(string nev, DateTime hatarido, int idotartam, int prioritas)
        {
            this.nev = nev;
            this.hatarido = hatarido;
            this.idotartam = idotartam;
            this.prioritas = prioritas;

        }

        public ITeendo Kovetkezo { get; set; }
    }
}
