using AutoMapper;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.Server.ActionFilters;
using ExpenseManager.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;

        public ProfileController(IProfileService service, IMapper mapper)
        {
            _profileService = service;
            _mapper = mapper;
        }

        [HttpGet(Name = "Get Profiles")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProfileModel>))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Get()
        {
            var profiles = await _profileService.GetListAsync();
            var dtos = _mapper.Map<List<ProfileModel>>(profiles);
            return Ok(dtos);
        }


        [HttpPut("{id}", Name = "Update Profile")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProfileModel dto)
        {
            if (id != dto.Id)
                return BadRequest(ModelState);
            if (!await _profileService.ItemExistsAsync(id))
                return NotFound();
            var profile = _mapper.Map<Entities.Concrete.Profile>(dto);
            _profileService.Update(profile);
            await _profileService.SaveChangesAsync();
            return NoContent();
        }
    }
}