using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankClassLib
{
    public interface IBank
    {
        Bank GetBank();
        int CreateAccount(string name, AccountType type);
        double Deposit(int nr, double amount);
        double Withdraw(int nr, double amount);
        Account Balance(int nr);
        void RenteTilskrivning();
        List<AccountListItem> AccountLookUpList();
        List<AccountListItem> GetAccountList();
    }
}
