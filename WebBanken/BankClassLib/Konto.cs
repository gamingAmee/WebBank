namespace BankClassLib
{
    // Skabelon-klasse til nedarv
    public abstract class Konto
    {
        public string Navn { get; set; }
        public int KontoNummer { get; set; }
        double saldo;
        public KontoType Kontotype { get; set; }

        public double Saldo
        {
            get
            {
                return saldo;
            }
            set
            {
                saldo = value;
                if (saldo < 0)
                {
                    throw new Overtr�kException(string.Format("Overtr�k p� {0:c}", saldo));
                }
            }
        }

        // Skabelon-metode til nedarv
        public abstract void TilskrivRente();
    }
}

