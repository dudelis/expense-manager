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
    public class CurrencyController : Controller
    {
        private readonly ICurrencyService _service;
        public CurrencyController(ICurrencyService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var currencies = _service.GetAll();
            var currencyDtos = CurrencyDto.Convert(currencies);
            return View(currencyDtos);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(string id)
        {
            if (id == null)
                return NotFound();
            var currency = _service.GetById(id);
            if (currency == null)
                return NotFound();
            return View(new CurrencyDto(currency));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Code, Name")] CurrencyDto currency)
        {
            if (ModelState.IsValid)
            {
                _service.Create(new Currency()
                {
                    Code = currency.Code,
                    Name = currency.Name
                });
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Edit(string id)
        {
            if (id == null)
                return NotFound();

            var currency = _service.GetById(id);
            if (currency == null)
                return NotFound();
            return View(new CurrencyDto(currency));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Code, Name")] CurrencyDto currency)
        {
            if (id != currency.Code)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(new Currency() {
                        Code = currency.Code,
                        Name = currency.Name
                    });
                    _service.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.ItemExists(id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(currency);
        }
    }
}