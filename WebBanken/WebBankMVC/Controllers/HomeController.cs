using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBankMVC.Models;
using BankClassLib;

namespace WebBankMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBank repo;


        public HomeController(IBank bankrepo)
        {
            repo = bankrepo;
        }

        public IActionResult Index()
        {
            return View(repo.GetBank());
        }

        [HttpPost]
        public IActionResult Create(CustomerVM customer)
        {
            customer.AccountNumber = repo.CreateAccount(customer.Name, customer.AccountType);
            return View("AccountConfirm", customer);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AccountList()
        {
            List<AccountListItem> accountLists;
            accountLists = repo.GetAccountList();
            return View(accountLists);
        }

        public IActionResult Deposit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Deposit(int id, AccountVM account)
        {
            account.AccountNumber = id;
            repo.Deposit(account.AccountNumber, account.Balance);

            return RedirectToAction("AccountList", account);
        }

        public IActionResult WithDraw()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WithDraw(int id, AccountVM account)
        {
            account.AccountNumber = id;
            repo.Withdraw(account.AccountNumber, account.Balance);

            return RedirectToAction("AccountList", account);
        }

        public IActionResult Rate()
        {
            repo.RenteTilskrivning();
            return RedirectToAction("AccountList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
