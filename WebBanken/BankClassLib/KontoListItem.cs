namespace BankClassLib
{
    public class KontoListItem
    {
        public int KontoNummer { get; set; }
        public string Navn { get; set; }
        public double Saldo { get; set; }
        public KontoType Kontotype { get; set; }
    }
}
