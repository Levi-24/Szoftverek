using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Szoftverek
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Szoftver> szoftverek = new();
            using (StreamReader sr = new(@"..\..\..\src\szoftverek.txt", Encoding.UTF8))
            {
                _ = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    szoftverek.Add(new Szoftver(sr.ReadLine()));
                }
            }

            Console.WriteLine("7.Feladat:");
            List<Szoftver> antivirusok = Feladat7(szoftverek);
            Console.WriteLine($"\t{antivirusok.Count}");

            Console.WriteLine("8.Feladat:");
            List<Szoftver> majdnemLegjobb = new();
            double legjobbErtekeles = szoftverek.Max(x => x.Ertekeles);
            Feladat8(szoftverek, legjobbErtekeles, majdnemLegjobb);

            foreach (var szoftver in majdnemLegjobb)
            {
                Console.WriteLine($"\t{szoftver}");
            }
            Console.WriteLine($"\t{majdnemLegjobb.Count}");
            Console.WriteLine($"\t{legjobbErtekeles}");

            Console.WriteLine("10.Feladat:");
            Console.WriteLine($"\t{Feladat10(szoftverek)}");

            Console.WriteLine("11.Feladat:");
            List<string> kategoriak = Feladat11(szoftverek);
            if (kategoriak.Count == 0)
            {
                Console.WriteLine("\tNincs ilyen szotfver");
            }
            else
            {
                foreach (var kategoria in kategoriak)
                {
                    Console.WriteLine($"\t{kategoria}");
                }
            }

            Console.WriteLine("12.Feladat:");
            List<int> azonositok = Feladat12(szoftverek);
            string feladat12 = string.Join(", ", azonositok);
            if (feladat12 != "")
            {
                Console.WriteLine($"\t{feladat12}");
            }
            else
            {
                Console.WriteLine("\tNincs ilyen szoftver");
            }

            using (StreamWriter writer = new(@"..\..\..\src\elso_10_fizetos_szoftver", false))
            {
                List<Szoftver> tizFizetos = new();
                tizFizetos.AddRange(szoftverek.Where(x => x.LicencTipus == "fizetős").Take(10));
                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine(tizFizetos[i]);
                }   
            }

        }

        static List<Szoftver> Feladat7(List<Szoftver> szoftverek)
        {
            List<Szoftver> megfelelo = new();
            foreach (var szoftver in szoftverek)
            {
                if (szoftver.Ertekeles > 8.5 && szoftver.Kategoria == "antivírus")
                {
                    megfelelo.Add(szoftver);
                }
            }
            return megfelelo;
        }
        static void Feladat8(List<Szoftver> szoftverek, double legjobbErtekeles, List<Szoftver> majdnemLegjobb)
        {
            majdnemLegjobb.AddRange(szoftverek.Where(x => x.Ertekeles == legjobbErtekeles - 0.1));
        }
        static double Feladat10(List<Szoftver> szoftverek)
        {
            int megfelel = szoftverek.Count(s => s.NevEsVerzioszam.StartsWith("Adobe"));
            double megfelelOsszeg = 0;
            foreach (var szoftver in szoftverek)
            {
                if (szoftver.NevEsVerzioszam.StartsWith("Adobe"))
                {
                    megfelelOsszeg += szoftver.BruttoAr();
                }
            }
            double bruttoAtlag = megfelelOsszeg / megfelel;
            return bruttoAtlag;
        }
        static List<string> Feladat11(List<Szoftver> szoftverek)
        {
            List<string> kategoriak = new();
            foreach (var szoftver in szoftverek)
            {
                if (szoftver.OpRendszerek.Contains(',') && !kategoriak.Contains(szoftver.Kategoria))
                {
                    kategoriak.Add(szoftver.Kategoria);
                }
            }
            kategoriak.Sort();
            return kategoriak;
        }   
        static List<int> Feladat12(List<Szoftver> szoftverek)
        {
            List<int> azonositok = new();
            foreach (var szoftver in szoftverek)
            {
                if (szoftver.NettoAr > 500 && szoftver.Ertekeles < 9)
                {
                    azonositok.Add(szoftver.Azonosito);
                }
            }
            return azonositok;
        }
    }
}
