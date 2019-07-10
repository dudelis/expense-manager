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
        
    }
}