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
    public class AccountTypeController : Controller
    {
        private readonly IAccountTypeService _accountTypeService;

        public AccountTypeController(IAccountTypeService service)
        {
            this._accountTypeService = service;
        }

        public IActionResult Index()
        {
            var types = _accountTypeService.GetAll();
            var typesDto = AccountTypeViewModel.Convert(types);
            return View(typesDto);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")] AccountTypeViewModel accountType)
        {
            if (ModelState.IsValid)
            {
                _accountTypeService.Create(new AccountType() {Name = accountType.Name});
                _accountTypeService.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            
            var accountType = _accountTypeService.GetById(Convert.ToInt32(id));
            if (accountType == null)
                return NotFound();
            
            return View(new AccountTypeViewModel(accountType));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Name")] AccountTypeViewModel type)
        {
            if (id != type.Id)
                return NotFound();
            if (!ModelState.IsValid)
                return View(type);           
            try
            {
                _accountTypeService.Update(new AccountType() { Id=type.Id, Name = type.Name });
                _accountTypeService.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_accountTypeService.ItemExists(id))
                    return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));            
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyNameUnique (string name)
        {
            if (_accountTypeService.ItemExists(name))
            {
                return Json($"Account type with name {name} already exists!");
            }
            return Json(true);
        }
    }
}