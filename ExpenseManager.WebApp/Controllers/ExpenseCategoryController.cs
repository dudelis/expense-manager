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
    public class ExpenseCategoryController : Controller
    {
        private IExpenseCategoryService _service;
        public ExpenseCategoryController(IExpenseCategoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var categories = _service.GetAll();
            return View(ExpenseCategoryViewModel.Convert(categories));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ExpenseCategoryViewModel
            {
                ListOfExpenseCategories = _service.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseCategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                category.ListOfExpenseCategories = _service.GetAll();

                return View(category);
            }
            _service.Create(new ExpenseCategory() {
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId
            });
            _service.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var category = _service.GetById(Convert.ToInt32(id));
            var model = new ExpenseCategoryViewModel(category)
            {
                ListOfExpenseCategories = _service.GetAll()
            };
            return View( model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Name, ParentCategoryId")]ExpenseCategoryViewModel model)
        {
            if (id != model.Id)
                return NotFound();
            if (!ModelState.IsValid)
            {
                model.ListOfExpenseCategories = _service.GetAll();
                return View(model);
            }
            try
            {
                _service.Update(new ExpenseCategory() {
                    Id = model.Id,
                    Name = model.Name,
                    ParentCategoryId = model.ParentCategoryId
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