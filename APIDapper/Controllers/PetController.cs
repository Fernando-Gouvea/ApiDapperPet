using APIDapper.Domain.Entities;
using APIDapper.Infra.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDapper.Domain.Fixed;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var pet = await _repository.GetByIdAsync(id);

            return Ok(pet);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var pet = await _repository.GetAllAsync();

            return Ok(pet);

        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateByIdAsync(Guid id)
        {
            Pet pet = await _repository.GetByIdAsync(id);
            pet.Name = "Cachorro";
            pet.Type = TypePet.Dog;

            var result = await _repository.UpdateByIdAsync(pet);

            return Ok(result);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveByIdAsync(Guid id)
        {
            //Pet pet = await _repository.GetByIdAsync(id);
            var result = await _repository.RemoveByIdAsync(id);

            return Ok(result);

        }


    }
}
