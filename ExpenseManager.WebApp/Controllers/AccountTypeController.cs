using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.WebApp.Controllers
{
    public class AccountTypeController : Controller
    {
        private readonly IAccountTypeService _service;

        public AccountTypeController(IAccountTypeService service)
        {
            this._service = service;
        }

        //GET: AccountTypes
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }
        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var accountType = this._service.GetById(Convert.ToInt32(id));

            if (accountType == null)
            {
                return NotFound();
            }
            return View(accountType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Name")] AccountType accountType)
        {
            if (id != accountType.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(accountType);
                    _service.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.ItemExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            return View(accountType);
        }
    }
}