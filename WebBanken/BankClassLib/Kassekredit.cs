using System;
using System.Collections.Generic;
using System.Text;

namespace BankClassLib
{
    class Kassekredit : Konto
    {
        public Kassekredit(string navn, int kontoNummer)
        {
            this.Navn = navn;
            this.KontoNummer = kontoNummer;
            this.Kontotype = KontoType.Kassekredit;
        }
        public override void TilskrivRente()
        {
            if (Saldo > 0)
                Saldo *= 1.005;
            else
                Saldo *= 0.95;
        }
    }
}
