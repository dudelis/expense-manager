using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.Entities.Concrete;
using ExpenseManager.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.WebApp.Controllers
{
    //[Authorize]
    //public class AccountController : Controller
    //{
    //    IAccountService _accountService;
    //    ICurrencyService _currencyService;
    //    IAccountTypeService _accountTypeService;
    //    public AccountController(IAccountService service, ICurrencyService currencyService, IAccountTypeService accountTypeService)
    //    {
    //        _accountService = service;
    //        _currencyService = currencyService;
    //        _accountTypeService = accountTypeService;
    //    }
    //    [HttpGet]
    //    public IActionResult Index()
    //    {
    //        var accounts = _accountService.GetAll();
    //        var accountDtos = AccountViewModel.Convert(accounts);
    //        return View(accountDtos);
    //    }
    //    [HttpGet]
    //    public IActionResult Create()
    //    {
    //        var account = new AccountViewModel() {
    //            BalanceDate = DateTime.Now,
    //            ListOfCurrencies = _currencyService.GetAll(),
    //            ListOfAccountTypes = _accountTypeService.GetAll()
    //        };
    //        return View(account);
    //    }
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Create(AccountViewModel account)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _accountService.Create(new Account()
    //            {
    //                Name = account.Name,
    //                IconCode = account.IconCode,
    //                CurrencyCode = account.CurrencyCode,
    //                Balance = account.Balance,
    //                BalanceDate = account.BalanceDate,
    //                AccountTypeId = Convert.ToInt32(account.AccountTypeId),
    //                IncludeInTotals = account.IncludeInTotals
    //            });
    //            _accountService.SaveChanges();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        account.ListOfAccountTypes = _accountTypeService.GetAll();
    //        account.ListOfCurrencies = _currencyService.GetAll();

    //        return View(account);
    //    }
    //    [HttpGet]
    //    public IActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //            return NotFound();
    //        var account = _accountService.GetById(Convert.ToInt32(id));
    //        if (account == null)
    //            return NotFound();
    //        var accountModel = new AccountViewModel(account)
    //        {
    //            ListOfAccountTypes = _accountTypeService.GetAll(),
    //            ListOfCurrencies = _currencyService.GetAll()
    //        };
    //        return View(accountModel);
            
    //    }
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Edit(int id, AccountViewModel accountModel)
    //    {
    //        if (id != accountModel.Id)
    //            return NotFound();
    //        if (!ModelState.IsValid)
    //        {
    //            accountModel.ListOfAccountTypes = _accountTypeService.GetAll();
    //            accountModel.ListOfCurrencies = _currencyService.GetAll();

    //            return View(accountModel);
    //        }
    //        try
    //        {
    //            var account = new Account()
    //            {
    //                Id = accountModel.Id,
    //                Name = accountModel.Name,
    //                IconCode = accountModel.IconCode,
    //                CurrencyCode = accountModel.CurrencyCode,
    //                Balance = accountModel.Balance,
    //                BalanceDate = accountModel.BalanceDate,
    //                AccountTypeId = Convert.ToInt32(accountModel.AccountTypeId),
    //                IncludeInTotals = accountModel.IncludeInTotals
    //            };
    //            _accountService.Update(account);
    //            _accountService.SaveChanges();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!_accountService.ItemExists(id))
    //                return NotFound();
    //            throw;
    //        }            
    //    }
    //}
}