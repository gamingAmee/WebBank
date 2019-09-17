namespace BankClassLib
{
    class PayrollAccount : Account
    {
        public PayrollAccount(string name, int accountNumber)
        {
            this.Name = name;
            this.AccountNumber = accountNumber;
            this.AccountType = AccountType.PayrollAccount;
        }

        public override void AddInterest()
        {
            if (Balance > 0)
            {
                Balance *= 1.005;
            }
        }
    }
}
