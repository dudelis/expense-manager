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
            var currencyDtos = CurrencyViewModel.Convert(currencies);

            return View(currencyDtos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CurrencyViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Name")] CurrencyViewModel currency)
        {
            if (ModelState.IsValid)
            {
                _service.Create(new Currency()
                {
                    Id = currency.Id,
                    Name = currency.Name
                });
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(currency);
        }
        public IActionResult Edit(string id)
        {
            if (id == null)
                return NotFound();

            var currency = _service.GetById(id);
            if (currency == null)
                return NotFound();

            return View(new CurrencyViewModel(currency));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Id, Name")] CurrencyViewModel currency)
        {
            if (id != currency.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(new Currency() {
                        Id = currency.Id,
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