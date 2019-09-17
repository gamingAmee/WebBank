using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankClassLib;
namespace WebBankMVC.Models
{
    public class AccountVM
    {
        public List<AccountListItem> Accounts { get; set; }
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public double Balance { get; set; }
    }
}
