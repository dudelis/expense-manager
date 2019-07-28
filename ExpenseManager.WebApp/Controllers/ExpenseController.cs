using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.Entities.Concrete;
using ExpenseManager.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.WebApp.Controllers
{
    public class ExpenseController : Controller
    {
        private IExpenseService _expenseService;
        private IAccountService _accountService;
        private IExpenseCategoryService _categoryService;
        private ICurrencyService _currencyService;
        private IPayeeService _payeeService;
        public ExpenseController(IExpenseService expense,
            IAccountService account,
            IExpenseCategoryService category, 
            ICurrencyService currency, 
            IPayeeService payee)
        {
            _expenseService = expense;
            _accountService = account;
            _categoryService = category;
            _currencyService = currency;
            _payeeService = payee;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var expenses = _expenseService.GetAll();
                   
            return View(ExpenseViewModel.Convert(expenses));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var expense = new ExpenseViewModel()
            {
                ExpenseDate = DateTime.Now,
                ListOfAccounts = _accountService.GetAll(),
                ListOfCategories = _categoryService.GetAll(),
                ListOfCurrencies = _currencyService.GetAll(),
                ListOfPayees = _payeeService.GetAll()
            };
            ViewData["AspAction"] = "Create";
            ViewData["Title"] = "Create Expense";
            return View("Edit", expense);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ExpenseDate, Amount, Notes, PayFromAccountId, CategoryId, CurrencyCode, PayeeId")]ExpenseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ListOfAccounts = _accountService.GetAll();
                model.ListOfCategories = _categoryService.GetAll();
                model.ListOfCurrencies = _currencyService.GetAll();
                model.ListOfPayees = _payeeService.GetAll();
                ViewData["AspAction"] = "Create";
                ViewData["Title"] = "Create Expense";
                return View("Edit", model);
            }
            var expense = new Expense()
            {
                ExpenseDate = model.ExpenseDate,
                Amount = model.Amount,
                Notes= model.Notes,
                PayFromAccountId = model.PayFromAccountId,
                CategoryId = model.CategoryId,
                CurrencyCode = model.CurrencyCode,
                PayeeId = model.PayeeId
            };
            _expenseService.Create(expense);
            _expenseService.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var expense = _expenseService.GetById(Convert.ToInt32(id));
            if (expense == null)
                return NotFound();
            var model = new ExpenseViewModel(expense)
            {
                ListOfAccounts = _accountService.GetAll(),
                ListOfCategories = _categoryService.GetAll(),
                ListOfCurrencies = _currencyService.GetAll(),
                ListOfPayees = _payeeService.GetAll()
            };
            ViewData["AspAction"] = "Edit";
            ViewData["Title"] = "Edit Expense";
            return View("Edit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ExpenseViewModel model)
        {
            if (id != model.Id)
                return NotFound();
            if (!ModelState.IsValid)
            {
                model.ListOfAccounts = _accountService.GetAll();
                model.ListOfCategories = _categoryService.GetAll();
                model.ListOfCurrencies = _currencyService.GetAll();
                model.ListOfPayees = _payeeService.GetAll();
                ViewData["AspAction"] = "Edit";
                ViewData["Title"] = "Edit Expense";
                return View("Edit", model);
            }
            var expense = new Expense()
            {
                Id = model.Id,
                ExpenseDate = model.ExpenseDate,
                Amount = model.Amount,
                Notes = model.Notes,
                PayFromAccountId = model.PayFromAccountId,
                CategoryId = model.CategoryId,
                CurrencyCode = model.CurrencyCode,
                PayeeId = model.PayeeId
            };
            try
            {
                _expenseService.Update(expense);
                _expenseService.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_expenseService.ItemExists(id))
                    return NotFound();
                throw;
            }            
        }
    }
}