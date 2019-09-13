namespace BankClassLib
{
    class OpsparingsKonto : Konto
    {
        public OpsparingsKonto(string navn, int kontoNummer)
        {
            this.Navn = navn;
            this.KontoNummer = kontoNummer;
            this.Kontotype = KontoType.Opsparingskonto;
        }

        public override void TilskrivRente()
        {
            if (Saldo > 100000)
                Saldo *= 1.03;
            else
            {
                if (Saldo > 50000)
                    Saldo *= 1.02;
                else
                {
                    if (Saldo > 0)
                        Saldo *= 1.01;
                }
            }
        }
    }
}
