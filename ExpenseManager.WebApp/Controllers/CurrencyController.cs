using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}