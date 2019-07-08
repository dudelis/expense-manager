using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.WebApp.Controllers
{
    public class TestController : Controller
    {
        public string Index()
        {
            return "This is the Index controller";
        }
    }
}