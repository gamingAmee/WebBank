namespace BankClassLib
{
    class LoenKonto : Konto
    {
        public LoenKonto(string navn, int kontoNummer)
        {
            this.Navn = navn;
            this.KontoNummer = kontoNummer;
            this.Kontotype = KontoType.Lønkonto;
        }

        public override void TilskrivRente()
        {
            if (Saldo > 0)
            {
                Saldo *= 1.005;
            }
        }
    }
}
