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
            customer = new CustomerVM();
            customer.AccountNumber = repo.CreateAccount(customer.Name, customer.AccountType);
            return View("AccountConfirm", customer);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deposit(AccountVM account)
        {
            account = new AccountVM();
            account.Accounts = repo.GetAccountList();
            return View(account);
        }

        [HttpGet]
        public IActionResult Deposit()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
