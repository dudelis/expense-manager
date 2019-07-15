using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.Entities.Concrete;
using ExpenseManager.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.WebApp.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _service;
        ICurrencyService _currencyService;
        public AccountController(IAccountService service, ICurrencyService currencyService)
        {
            _service = service;
            _currencyService = currencyService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var accounts = _service.GetAll();
            var accountDtos = AccountDto.Convert(accounts);
            return View(accountDtos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var currencies = _currencyService.GetAll();
            ViewBag.ListOfCurrencies = currencies;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AccountDto account)
        {
            if (ModelState.IsValid)
            {
                _service.Create(new Account()
                {
                    Name = account.Name,
                    IconCode = account.IconCode,
                    CurrencyCode = account.CurrencyCode,
                    Balance = account.Balance,
                    BalanceDate = account.BalanceDate,
                    AccountTypeId = account.AccountTypeId,
                    IncludeInTotals = account.IncludeInTotals
                });
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}