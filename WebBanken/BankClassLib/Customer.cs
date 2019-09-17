using System;
using System.Collections.Generic;
using System.Text;

namespace BankClassLib
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Account> Accounts { get; set; }

        public Customer()
        {
            Accounts = new List<Account>();
        }
    }
}
