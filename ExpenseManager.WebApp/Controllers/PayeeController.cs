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
    public class PayeeController : Controller
    {
        IPayeeService _service;
        public PayeeController(IPayeeService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var payees = _service.GetAll();
            return View(PayeeDto.Convert(payees));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,AccountNumber,PhoneNumber,WebSite,Notes")]PayeeDto payee)
        {
            if (ModelState.IsValid)
            {
                _service.Create(new Payee()
                {
                    Name = payee.Name,
                    AccountNumber = payee.AccountNumber,
                    PhoneNumber = payee.PhoneNumber,
                    WebSite = payee.WebSite,
                    Notes = payee.Notes
                });
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var payee = _service.GetById(Convert.ToInt32(id));
            if (payee == null)
                return NotFound();
            return View(new PayeeDto(payee));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PayeeDto payee)
        {
            if (id != payee.Id)
                return NotFound();
            if (!ModelState.IsValid)
                return View(payee);
            try
            {
                _service.Update(new Payee()
                {
                    Id = payee.Id,
                    Name = payee.Name,
                    AccountNumber = payee.AccountNumber,
                    PhoneNumber = payee.PhoneNumber,
                    WebSite = payee.WebSite,
                    Notes = payee.Notes
                });
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.ItemExists(id))
                    return NotFound();
                throw;
            }
        }
    }
}