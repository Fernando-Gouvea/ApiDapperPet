using APIDapper.Domain.Entities;
using APIDapper.Infra.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDapper.Controllers
{
    [Route(template: "/api/pets")]

    public class PetController : Controller
    {
        private readonly IPetRepository _repository;

        public PetController(IPetRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Pet pet)
        {
            await _repository.AddAsync(pet);

            return Created(uri: $"/api/pets/{pet.Id}", pet);

        }

        [HttpGet(template: "id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var pet = await _repository.GetByIdAsync(id);

            return Ok(pet);

        }

      
    }
}
