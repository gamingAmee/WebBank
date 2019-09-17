using System;
using System.Collections.Generic;

namespace BankClassLib
{
    public class Bank
    {
        public string BankName { get; }
        public double Deposits { get; }
        int accountnumberCounter;
        public List<Account> accounts;

        public Bank(string bankname, double deposits)
        {
            BankName = bankname;
            Deposits = deposits;
            accounts = new List<Account>();
        }

    }
}
