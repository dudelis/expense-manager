using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.Entities.Concrete;
using ExpenseManager.Server.ActionFilters;
using ExpenseManager.Shared.Models;
using GridMvc.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseCategoryController : ControllerBase
    {
        private readonly IExpenseCategoryService _expenseCategoryService;
        private readonly IMapper _mapper;

        public ExpenseCategoryController(IExpenseCategoryService service, IMapper mapper)
        {
            _expenseCategoryService = service;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetExpenseCategoriesGrid")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Get()
        {
            var items = await _expenseCategoryService.GetListAsync();
            var dtos = _mapper.Map<List<ExpenseCategoryModel>>(items);
            var server = new GridServer<ExpenseCategoryModel>(dtos, Request.Query, true, "ExpenseCategories")
                .AutoGenerateColumns()
                .WithPaging(10)
                .Sortable(true)
                .Searchable(true, true);
            return Ok(server.ItemsToDisplay);
        }

        [HttpGet("{id:int}", Name = "GetExpenseCategory")]
        [ProducesResponseType(200, Type = typeof(ExpenseCategoryModel))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _expenseCategoryService.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            var dto = _mapper.Map<ExpenseCategoryModel>(item);
            return Ok(dto);
        }
        [HttpPost(Name = "Create ExpenseCategory")]
        [ProducesResponseType(201, Type = typeof(ExpenseCategoryModel))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Create([FromBody] ExpenseCategoryModel dto)
        {
            var item = _mapper.Map<Entities.Concrete.ExpenseCategory>(dto);
            await _expenseCategoryService.CreateAsync(item);
            await _expenseCategoryService.SaveChangesAsync();
            _mapper.Map(item, dto);
            return CreatedAtRoute("GetExpenseCategory", new { id = dto.Id }, dto);
        }
        [HttpPut("{id}", Name = "Update ExpenseCategory")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Update(int id, [FromBody] ExpenseCategoryModel dto)
        {
            if (id != dto.Id) return BadRequest(ModelState);
            if (!await _expenseCategoryService.ItemExistsAsync(id)) return NotFound();
            var item = _mapper.Map<ExpenseCategory>(dto);
            _expenseCategoryService.Update(item);
            await _expenseCategoryService.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}", Name = "Delete ExpenseCategory")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _expenseCategoryService.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            _expenseCategoryService.Delete(item);
            await _expenseCategoryService.SaveChangesAsync();
            return NoContent();
        }
    }
}