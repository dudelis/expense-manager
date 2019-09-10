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
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeService accountTypeService;
        private readonly IMapper _mapper;

        public AccountTypeController(IAccountTypeService service, IMapper mapper)
        {
            accountTypeService = service;
            _mapper = mapper;
        }

        [HttpGet(Name = "Get AccountTypes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AccountTypeModel>))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Get()
        {
            var aTypes = await accountTypeService.GetListAsync();
            var dtos = _mapper.Map<List<AccountTypeModel>>(aTypes);
            var server = new GridServer<AccountTypeModel>(dtos, Request.Query, true, "AccountTypes")
                .AutoGenerateColumns()
                .Searchable(true, true);
            return Ok(server.ItemsToDisplay);
        }

        [HttpGet("{id:int}", Name = "GetAccountType")]
        [ProducesResponseType(200, Type = typeof(AccountTypeModel))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await accountTypeService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            var dto = _mapper.Map<AccountTypeModel>(entity);
            return Ok(dto);
        }
        [HttpPost(Name = "Create Account Type")]
        [ProducesResponseType(201, Type = typeof(AccountTypeModel))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Create([FromBody] AccountTypeModel dto)
        {
            var entity = _mapper.Map<AccountType>(dto);
            await accountTypeService.CreateAsync(entity);
            await accountTypeService.SaveChangesAsync();
            _mapper.Map(entity, dto);
            return CreatedAtRoute("GetAccountType", new { id = dto.Id }, dto);
        }
        [HttpPut("{id}", Name = "Update AccountType")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Update(int id, [FromBody] AccountTypeModel dto)
        {
            if (id != dto.Id)
                return BadRequest(ModelState);
            if (!await accountTypeService.ItemExistsAsync(id))
                return NotFound();
            var entity = _mapper.Map<AccountType>(dto);
            accountTypeService.Update(entity);
            await accountTypeService.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}", Name = "Delete AccountType")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await accountTypeService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            accountTypeService.Delete(entity);
            await accountTypeService.SaveChangesAsync();
            return NoContent();
        }
    }
}