using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET
{
    internal class Szimulal
    {
        public string NapRaHivatkozas(int nap)
        {
            if (nap == 1)
            {
                return "Hétfő";
            }
            else if (nap == 2)
            {
                return "Kedd";
            }
            else if (nap == 3)
            {
                return "Szerda";
            }
            else if (nap == 4)
            {
                return "Csütörtök";
            }
            else if (nap == 5)
            {
                return "Péntek";
            }
            else if (nap == 6)
            {
                return "Szombat";
            }
            else
            {
                return "Vasárnap";
            }
        }
        public static string OraraHivatkozas(int index)
        {
            if (index == 0)
            {
                return "0:00";
            }
            else if (index == 1)
            {
                return "1:00";
            }
            else if (index == 2)
            {
                return "2:00";
            }
            else if (index == 3)
            {
                return "3:00";
            }
            else if (index == 4)
            {
                return "4:00";
            }
            else if (index == 5)
            {
                return "5:00";
            }
            else if (index == 6)
            {
                return "6:00";
            }
            else if (index == 7)
            {
                return "7:00";
            }
            else if (index == 8)
            {
                return "8:00";
            }
            else if (index == 9)
            {
                return "9:00";
            }
            else if (index == 10)
            {
                return "10:00";
            }
            else if (index == 11)
            {
                return "11:00";
            }
            else if (index == 12)
            {
                return "12:00";
            }
            else if (index == 13)
            {
                return "13:00";
            }
            else if (index == 14)
            {
                return "14:00";
            }
            else if (index == 15)
            {
                return "15:00";
            }
            else if (index == 16)
            {
                return "16:00";
            }
            else if (index == 17)
            {
                return "17:00";
            }
            else if (index == 18)
            {
                return "18:00";
            }
            else if (index == 19)
            {
                return "19:00";
            }
            else if (index == 20)
            {
                return "20:00";
            }
            else if (index == 21)
            {
                return "21:00";
            }
            else if (index == 22)
            {
                return "22:00";
            }


            else
            {
                return "23:00";
            }
        }

        public static void EgyszeriElvegezve(Egyszeri egyszeri)
        {
            Console.WriteLine("A " + (egyszeri as Egyszeri).nev + " nevű feladat elkészült.");
        }
        public static void Emlekeztet(Egyszeri egyszeri, int index)
        {
            Console.WriteLine();
            Console.WriteLine(" Következő feladat " + OraraHivatkozas(index) + " órakor: " + (egyszeri as Egyszeri).nev);
            Console.WriteLine("Megcsináltad? (I/N)");
        }

        public static void Masnap()
        {
            Console.WriteLine("");
            Console.WriteLine("Napot váltottunk!");
            Console.ReadLine();
        }
        public Nap NapiTeendok(DateTime datum, Naptar naptar, int nap)
        {
            Console.WriteLine(datum.ToShortDateString() + " " + NapRaHivatkozas(nap));
            Console.WriteLine("Mai napi teendők:");
            Nap p = naptar.fej;
            ;
            while (p.datum != datum)
            {
                p = p.Kovetkezo;
            }
            for (int i = 0; i < p.orak.Length; i++)
            {
                if (p.orak[i] == null)
                {
                    Console.WriteLine(OraraHivatkozas(i) + " -");
                }
                else if (p.orak[i] is Visszatero)
                {
                    Console.WriteLine(OraraHivatkozas(i) + " " + (p.orak[i] as Visszatero).nev);
                }
                else if (p.orak[i] is Mindennapi)
                {
                    Console.WriteLine(OraraHivatkozas(i) + " " + (p.orak[i] as Mindennapi).nev);
                }
                else if (p.orak[i] is Egyszeri)
                {
                    Console.WriteLine(OraraHivatkozas(i) + " " + (p.orak[i] as Egyszeri).nev);
                }
            }
            return p;
        }
    }
}
