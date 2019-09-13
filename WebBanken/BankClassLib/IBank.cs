using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankClassLib
{
    public interface IBank
    {
        double Beholdning { get; }
        string BankNavn { get; }
        int OpretKonto(string navn, KontoType type);
        double Indsæt(int nr, double beløb);
        double Hæv(int nr, double beløb);
        Konto Saldo(int nr);
        void RenteTilskrivning();
        List<KontoListItem> KontoLookUpList();
        List<KontoListItem> HentKontoList();
    }
}
