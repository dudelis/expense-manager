using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.Entities.Concrete;
using ExpenseManager.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.WebApp.Controllers
{
    [Authorize]
    public class AccountTypeController : Controller
    {
        private readonly IAccountTypeService _accountTypeService;
        private readonly IMapper _mapper;

        public AccountTypeController(IAccountTypeService service, IMapper mapper)
        {
            this._accountTypeService = service;
            this._mapper = mapper;
        }

        public IActionResult Index()
        {
            var accountTypes = _accountTypeService.GetAll();
            var accountTypeViewModels = _mapper.Map<List<AccountType>, List<AccountTypeViewModel>>(accountTypes);
            //var typesDto = AccountTypeViewModel.Convert(types);
            return View(accountTypeViewModels);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")] AccountTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var accountType = _mapper.Map<AccountType>(model);
                _accountTypeService.Create(accountType);
                _accountTypeService.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
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