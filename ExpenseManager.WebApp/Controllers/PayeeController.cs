using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.WebApp.Controllers
{
    public class PayeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            Payee payee = new Payee()
            {
                Id = 1,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                Name = "Metro",
                AccountNumber = "111222333",
                PhoneNumber = "999-000-111",
                WebSite = "https://metro.de",
                Notes = "Some notes"
            };
            return View(payee);
        }
    }
}