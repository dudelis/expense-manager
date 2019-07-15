﻿using System;
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
        private readonly IAccountTypeService _service;

        public AccountTypeController(IAccountTypeService service)
        {
            this._service = service;
        }

        //GET: AccountTypes
        public IActionResult Index()
        {
            var types = _service.GetAll();
            var typesDto = AccountTypeDto.Convert(types);
            return View(typesDto);
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
            return View(new AccountTypeDto(accountType));
        }
        //GET: AccountType/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")] AccountTypeDto accountType)
        {
            if (ModelState.IsValid)
            {
                _service.Create(new AccountType() {
                    Name = accountType.Name
                });
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountType = _service.GetById(Convert.ToInt32(id));
            if (accountType == null)
            {
                return NotFound();
            }
            return View(new AccountTypeDto(accountType));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Name")] AccountTypeDto type)
        {
            if (id != type.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(new AccountType() { Id=type.Id, Name = type.Name });
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
            return View(type);
        }
    }
}