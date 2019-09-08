using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.Entities.Concrete;
using ExpenseManager.Server.ActionFilters;
using ExpenseManager.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMapper _mapper;

        public CurrencyController(ICurrencyService service, IMapper mapper)
        {
            _currencyService = service;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetCurrencies")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CurrencyModel>))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Get()
        {
            var currencies = await _currencyService.GetListAsync();
            var dtos = _mapper.Map<List<CurrencyModel>>(currencies);
            return Ok(dtos);
        }

        [HttpGet("{id:int}", Name = "GetCurrency")]
        [ProducesResponseType(200, Type = typeof(CurrencyModel))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Get(int id)
        {
            var currency = await _currencyService.GetByIdAsync(id);
            if (currency == null)
                return NotFound();
            var dto = _mapper.Map<CurrencyModel>(currency);
            return Ok(dto);
        }
        [HttpPost(Name = "Create Currency")]
        [ProducesResponseType(201, Type = typeof(CurrencyModel))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Create([FromBody] CurrencyModel dto)
        {
            var currency = _mapper.Map<Currency>(dto);
            await _currencyService.CreateAsync(currency);
            await _currencyService.SaveChangesAsync();
            _mapper.Map(currency, dto);
            return CreatedAtRoute("GetCurrency", new { id = dto.Id }, dto);
        }
        [HttpPut("{id}", Name = "Update Currency")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Update(int id, [FromBody] CurrencyModel dto)
        {
            if (id != dto.Id) return BadRequest(ModelState);
            if (await _currencyService.ItemExistsAsync(id)) return NotFound();
            var currency = _mapper.Map<Currency>(dto);
            _currencyService.Update(currency);
            await _currencyService.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}", Name = "Delete Currency")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            var currency = await _currencyService.GetByIdAsync(id);
            if (currency == null)
                return NotFound();
            _currencyService.Delete(currency);
            await _currencyService.SaveChangesAsync();
            return NoContent();
        }
    }
}