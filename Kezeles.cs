using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E72LET
{
    delegate void FeladatEmlekezteto(Egyszeri feladatNeve, int index);
    delegate void EgyszeriFeladatTeljesitve(Egyszeri feladatNeve);
    delegate void UjNap();
    internal class Kezeles
    {
        DateTime Maidatum;
        Naptar naptar = new Naptar();
        Prioritas prioritasi = new Prioritas();
        int napindex = 7;
        bool kilep = false;
        public event FeladatEmlekezteto Kovetkezo;
        public event EgyszeriFeladatTeljesitve FeladatElkeszult;
        public event UjNap UjNap;
        Szimulal szimulal = new Szimulal();
        Nap ma;

        public void EgyNap()
        {
            while (!kilep)
            {
                if (naptar.fej != null)
                {
                    ITeendo p = prioritasi.fej;
                    while (p != null)
                    {
                        try
                        {
                            if (p is Egyszeri && (p as Egyszeri).hatarido < Maidatum && p.Idotartam != 0)
                            {
                                throw new KifutottunkAzIdobolException(p as Egyszeri);
                            }
                        }
                        catch (KifutottunkAzIdobolException e)
                        {
                            Console.WriteLine(e.Message);
                            string uj = Console.ReadLine();
                            string[] ujSplitelt = uj.Split('.');
                            DateTime ujHatarido = new DateTime(Int32.Parse(ujSplitelt[0]), Int32.Parse(ujSplitelt[1]), Int32.Parse(ujSplitelt[2]));
                            (p as Egyszeri).hatarido = ujHatarido;
                        }

                        p = p.Kovetkezo;
                    }


                    ma = szimulal.NapiTeendok(Maidatum, naptar, napindex);


                    for (int i = 0; i < ma.orak.Length; i++)
                    {
                        if (ma.orak[i] is Egyszeri)
                        {
                            string valasz = "";
                            while (valasz != "I" && valasz != "N")
                            {
                                Kovetkezo?.Invoke(ma.orak[i] as Egyszeri, i);
                                valasz = Console.ReadLine();
                            }
                            if (valasz == "I")
                            {
                                (ma.orak[i] as Egyszeri).idotartam -= 1;
                            }

                            if ((ma.orak[i] as Egyszeri).Idotartam == 0)
                            {
                                FeladatElkeszult?.Invoke(ma.orak[i] as Egyszeri);
                            }
                        }
                    }
                    UjNap?.Invoke();
                }

                Maidatum = Maidatum.AddDays(1);
                napindex++;
                if (napindex == 8)
                {
                    napindex = 1;
                }
                Nap nap = new Nap(Maidatum);
                naptar.NapBeszuras(nap);
                TeendoKiosztas(nap);
            }




        }
        public void Letrehoz(
           )
        {


            string[] beolvasottM = File.ReadAllLines("mindennapi.txt");
            string[] nevM = new string[beolvasottM.Length];
            int[] kezdesM = new int[beolvasottM.Length];
            int[] vegM = new int[beolvasottM.Length];
            int[] prioritasM = new int[beolvasottM.Length];

            for (int i = 0; i < beolvasottM.Length; i++)
            {
                string[] egysor = beolvasottM[i].Split(';');

                nevM[i] = egysor[0];

                kezdesM[i] = int.Parse(egysor[1]);

                vegM[i] = int.Parse(egysor[2]);

            }

            for (int i = 0; i < beolvasottM.Length; i++)
            {
                ITeendo mindennapi = new Mindennapi(nevM[i], kezdesM[i], vegM[i]);

                prioritasi.PrioritasiSorBeszuras(mindennapi);

            }




            string[] beolvasottE = File.ReadAllLines("egyszeri.txt");
            string[] nevE = new string[beolvasottE.Length];
            int[] idotartamE = new int[beolvasottE.Length];
            DateTime[] hataridoE = new DateTime[beolvasottE.Length];
            int[] prioritasE = new int[beolvasottE.Length];

            for (int i = 0; i < beolvasottE.Length; i++)
            {
                string[] egysor = beolvasottE[i].Split(';');

                nevE[i] = egysor[0];

                hataridoE[i] = DateTime.Parse(egysor[1]);
                idotartamE[i] = int.Parse(egysor[2]);
                prioritasE[i] = int.Parse(egysor[3]);
            }

            for (int i = 0; i < beolvasottE.Length; i++)
            {
                ITeendo egyszeri = new Egyszeri(nevE[i], hataridoE[i], idotartamE[i], prioritasE[i]);

                prioritasi.PrioritasiSorBeszuras(egyszeri);
            }


            string[] beolvasottV = File.ReadAllLines("visszatero.txt");
            string[] nevV = new string[beolvasottV.Length];
            int[] napontaV = new int[beolvasottV.Length];
            int[] rendszeressegV = new int[beolvasottV.Length];


            for (int i = 0; i < beolvasottV.Length; i++)
            {
                string[] egysor = beolvasottV[i].Split(';');

                nevV[i] = egysor[0];

                napontaV[i] = int.Parse(egysor[1]);
                rendszeressegV[i] = int.Parse(egysor[2]);

            }

            for (int i = 0; i < beolvasottV.Length; i++)
            {
                ITeendo visszatero = new Visszatero(nevV[i], napontaV[i], rendszeressegV[i]);

                prioritasi.PrioritasiSorBeszuras(visszatero);
            }

            EgyNap();
        }


        public void TeendoKiosztas(Nap nap)
        {
            ITeendo p = prioritasi.fej;
            while (p != null)
            {
                if (p.Prioritas == 5)
                {
                    for (int i = 0; i < p.Idotartam; i++)
                    {
                        nap.orak[(p as Mindennapi).kezdes + i] = p;
                    }

                }
                else if (p.Prioritas == 4)
                {
                    if (napindex == 1)
                    {
                        (p as Visszatero).elvegzes_szama = 0;
                    }
                    if ((p as Visszatero).rendszeresseg != (p as Visszatero).elvegzes_szama)
                    {
                        for (int j = 0; j < p.Idotartam; j++)
                        {
                            int i = 0;
                            while (nap.orak[i] != null)
                            {
                                i++;
                            }
                            nap.orak[i] = p;
                        }

                    (p as Visszatero).elvegzes_szama += 1;
                    }
                }
                else
                {
                    int i = 0;
                    int j = 0;
                    while (i < p.Idotartam && j < 24)
                    {
                        if (nap.orak[j] == null)
                        {
                            nap.orak[j] = p;
                            i++;
                        }
                        j++;
                    }
                }
                p = p.Kovetkezo;
            }
        }

        public Kezeles(DateTime maidatum)
        {
            this.Maidatum = maidatum;
        }
    }
}
