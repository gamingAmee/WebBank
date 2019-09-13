using System;
using System.Collections.Generic;

namespace BankClassLib
{
    public class Bank : IBank
    {
        public string BankNavn { get; }
        public double Beholdning { get; }
        int kontonummerTæller;
        List<Konto> konti;

        public Bank(string banknavn, double beholdning)
        {
            BankNavn = banknavn;
            Beholdning = beholdning;
            konti = new List<Konto>();
        }

        public int OpretKonto(string navn, KontoType type)
        {
            switch (type)
            {
                case KontoType.Lønkonto:
                    konti.Add(new LoenKonto(navn, ++kontonummerTæller));
                    break;
                case KontoType.Opsparingskonto:
                    konti.Add(new OpsparingsKonto(navn, ++kontonummerTæller));
                    break;
                case KontoType.Kassekredit:
                    konti.Add(new Kassekredit(navn, ++kontonummerTæller));
                    break;
                default:
                    return 0;
            }
            return kontonummerTæller;
        }

        public double Indsæt(int nr, double beløb)
        {
            Konto kontoen = konti.Find(k => k.KontoNummer == nr);
            kontoen.Saldo += beløb;
            return kontoen.Saldo;
        }

        public double Hæv(int nr, double beløb)
        {
            Konto kontoen = konti.Find(k => k.KontoNummer == nr);
            kontoen.Saldo -= beløb;
            return kontoen.Saldo;
        }

        public Konto Saldo(int nr)
        {
            Konto kontoen = konti.Find(k => k.KontoNummer == nr);
            return kontoen;
        }

        public void RenteTilskrivning()
        {
            foreach (Konto kontoen in konti)
            {
                kontoen.TilskrivRente();
            }
        }

        // Leverer en liste til Select kontrollen til valg af konto for Hæv og Indsæt
        public List<KontoListItem> KontoLookUpList()
        {
            List<KontoListItem> kontoList = new List<KontoListItem>();
            foreach (Konto konto in konti)
            {
                kontoList.Add(new KontoListItem
                {
                    KontoNummer = konto.KontoNummer,
                    Navn = konto.Navn
                });
            }
            return kontoList;
        }

        // Leverer en liste til at vise samtlige konti
        public List<KontoListItem> HentKontoList()
        {
            List<KontoListItem> kontoList = new List<KontoListItem>();
            foreach (Konto konto in konti)
            {
                kontoList.Add(new KontoListItem
                {
                    KontoNummer = konto.KontoNummer,
                    Navn = konto.Navn,
                    Saldo = konto.Saldo,
                    Kontotype = konto.Kontotype
                });
            }
            return kontoList;
        }
    }
}
