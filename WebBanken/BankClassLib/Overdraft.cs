using System;
using System.Collections.Generic;
using System.Text;

namespace BankClassLib
{
    class Overdraft : Account
    {
        public Overdraft(string name, int kontoNummer)
        {
            this.Name = name;
            this.AccountNumber = kontoNummer;
            this.AccountType = AccountType.Overdraft;
        }
        public override void AddInterest()
        {
            if (Balance > 0)
                Balance *= 1.005;
            else
                Balance *= 0.95;
        }
    }
}
