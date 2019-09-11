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
    public class PayeeController : ControllerBase
    {
        private readonly IPayeeService _payeeService;
        private readonly IMapper _mapper;

        public PayeeController(IPayeeService service, IMapper mapper)
        {
            _payeeService = service;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPayees")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PayeeModel>))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Get()
        {
            var items = await _payeeService.GetListAsync();
            var dtos = _mapper.Map<List<PayeeModel>>(items);
            var server = new GridServer<PayeeModel>(dtos, Request.Query, true, "Payees")
                .AutoGenerateColumns()
                .WithPaging(10)
                .Sortable(true)
                .Searchable(true, true);
            return Ok(server.ItemsToDisplay);
        }

        [HttpGet("{id:int}", Name = "GetPayee")]
        [ProducesResponseType(200, Type = typeof(PayeeModel))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _payeeService.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            var dto = _mapper.Map<PayeeModel>(item);
            return Ok(dto);
        }
        [HttpPost(Name = "Create Payee")]
        [ProducesResponseType(201, Type = typeof(PayeeModel))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Create([FromBody] PayeeModel dto)
        {
            var item = _mapper.Map<Payee>(dto);
            await _payeeService.CreateAsync(item);
            await _payeeService.SaveChangesAsync();
            _mapper.Map(item, dto);
            return CreatedAtRoute("GetPayee", new { id = dto.Id }, dto);
        }
        [HttpPut("{id}", Name = "Update Payee")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Update(int id, [FromBody] PayeeModel dto)
        {
            if (id != dto.Id) return BadRequest(ModelState);
            if (!await _payeeService.ItemExistsAsync(id)) return NotFound();
            var item = _mapper.Map<Payee>(dto);
            _payeeService.Update(item);
            await _payeeService.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}", Name = "Delete Payee")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _payeeService.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            _payeeService.Delete(item);
            await _payeeService.SaveChangesAsync();
            return NoContent();
        }
    }
}