namespace BankClassLib
{
    // Skabelon-klasse til nedarv
    public abstract class Account
    {
        public string Name { get; set; }
        public int AccountNumber { get; set; }
        double balance;
        public AccountType AccountType { get; set; }

        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
                if (balance < 0)
                {
                    throw new OverdraftException(string.Format("Overtræk på {0:c}", balance));
                }
            }
        }

        // Skabelon-metode til nedarv
        public abstract void AddInterest();
    }
}

