﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankClassLib;
using System.ComponentModel.DataAnnotations;

namespace WebBankMVC.Models
{
    public class CustomerVM
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "AccountType")]
        public AccountType AccountType { get; set; }

        public enum AccountTypes { PayrollAccount, SavingAccount, Overdraft }
        public int AccountNumber { get; set; }
    }
}
