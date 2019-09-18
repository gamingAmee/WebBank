using System;
using System.Collections.Generic;
using System.Text;

namespace BankClassLib
{
    public class BankRepository : IBank
    {
        public Bank bank;
        public List<Account> accounts;
        int accountnumberCounter = 0;
        public BankRepository()
        {
            accounts = new List<Account>();
            bank = new Bank("Eucbank", 100000);
        }

        public Bank GetBank()
        {
            return bank;
        }

        public int CreateAccount(string name, AccountType type)
        {
            switch (type)
            {
                case AccountType.PayrollAccount:
                    PayrollAccount payrollAccount = new PayrollAccount(name, ++accountnumberCounter);
                    accounts.Add(payrollAccount);
                    bank.accounts.Add(payrollAccount);
                    break;
                case AccountType.SavingAccount:
                    SavingsAccount savingsAccount = new SavingsAccount(name, ++accountnumberCounter);
                    accounts.Add(savingsAccount);
                    bank.accounts.Add(savingsAccount);
                    break;
                case AccountType.Overdraft:
                    Overdraft overdraft = new Overdraft(name, ++accountnumberCounter);
                    accounts.Add(overdraft);
                    bank.accounts.Add(overdraft);
                    break;
                default:
                    return 0;
            }
            return accountnumberCounter;
        }

        public double Deposit(int nr, double amount)
        {
            Account account = accounts.Find(k => k.AccountNumber == nr);
            account.Balance += amount;
            return account.Balance;
        }

        public double Withdraw(int nr, double amount)
        {
            Account kontoen = accounts.Find(k => k.AccountNumber == nr);
            kontoen.Balance -= amount;
            return kontoen.Balance;
        }

        public Account Balance(int nr)
        {
            Account account = accounts.Find(k => k.AccountNumber == nr);
            return account;
        }

        public void RenteTilskrivning()
        {
            foreach (Account account in accounts)
            {
                account.AddInterest();
            }
        }

        // Leverer en liste til Select kontrollen til valg af konto for Withdraw og Deposit
        public List<AccountListItem> AccountLookUpList()
        {
            List<AccountListItem> kontoList = new List<AccountListItem>();
            foreach (Account konto in accounts)
            {
                kontoList.Add(new AccountListItem
                {
                    AccountNumber = konto.AccountNumber,
                    Name = konto.Name
                });
            }
            return kontoList;
        }


        // Leverer en liste til at vise samtlige konti
        public List<AccountListItem> GetAccountList()
        {
            List<AccountListItem> kontoList = new List<AccountListItem>();
            foreach (Account item in accounts)
            {
                kontoList.Add(new AccountListItem
                {
                    AccountNumber = item.AccountNumber,
                    Name = item.Name,
                    Balance = item.Balance,
                    AccountType = item.AccountType
                });
            }
            return kontoList;
        }

    }
}
