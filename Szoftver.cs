using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szoftverek
{
    class Szoftver
    {
        //azonosító|név és verziószám|licenc típus|operációs rendszerek|kategória|felhasználói értékelés|nettó ár|adókulcs
        public int Azonosito { get; set; }
        public string NevEsVerzioszam { get; set; }
        public string LicencTipus { get; set; }
        public string OpRendszerek { get; set; }
        public string Kategoria { get; set; }
        public double Ertekeles { get; set; }
        public double NettoAr { get; set; }
        public int Adokulcs { get; set; }

        public Szoftver(string sor)
        {
            string[] adatok = sor.Split('|');
            Azonosito = Convert.ToInt32(adatok[0]);
            NevEsVerzioszam = adatok[1];
            LicencTipus = adatok[2];
            OpRendszerek = adatok[3];
            Kategoria = adatok[4];
            Ertekeles = Convert.ToDouble(adatok[5]);
            NettoAr = Convert.ToDouble(adatok[6]);
            Adokulcs = Convert.ToInt32(adatok[7]);
        }

        public double BruttoAr()
        {
            return NettoAr + (NettoAr * (Adokulcs / 100));
        }

        public override string ToString()
        {
            return $"Azonosito: {Azonosito}, NevEsVerzioszam: {NevEsVerzioszam}, LicencTipus: {LicencTipus}, OpRendszerek: {OpRendszerek}, Kategoria: {Kategoria}, Ertekeles: {Ertekeles}, NettoAr: {NettoAr}, Adokulcs: {Adokulcs};";
        }
    }
}
