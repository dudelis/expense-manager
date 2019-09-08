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
    public class UserSettingsController : ControllerBase
    {
        private readonly IUserSettingsService _userSettingsService;
        private readonly IMapper _mapper;

        public UserSettingsController(IUserSettingsService service, IMapper mapper)
        {
            _userSettingsService = service;
            _mapper = mapper;
        }

        [HttpGet(Name = "Get UserSettings")]
        [ProducesResponseType(200, Type = typeof(UserSettingsModel))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Get()
        {
            var user = HttpContext.User.Identity.Name;
            var userSettings = await _userSettingsService.GetAsync(x => x.UserId == user);

            var dto = _mapper.Map<UserSettingsModel>(userSettings);
            return Ok(dto);
        }
        [HttpGet("{Id}", Name = "Get UserSettings By Id")]
        [ProducesResponseType(200, Type = typeof(UserSettingsModel))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Get(int id)
        {
            var userSettings = await _userSettingsService.GetAsync(x => x.Id == id);

            var dto = _mapper.Map<UserSettingsModel>(userSettings);
            return Ok(dto);
        }


        [HttpPut("{id}", Name = "Update UserSettings")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Update(int id, [FromBody] UserSettingsModel dto)
        {
            if (id != dto.Id)
                return BadRequest(ModelState);
            if (!await _userSettingsService.ItemExistsAsync(id))
                return NotFound();
            var userSettings = _mapper.Map<UserSettings>(dto);
            _userSettingsService.Update(userSettings);
            await _userSettingsService.SaveChangesAsync();
            return NoContent();
        }
    }
}