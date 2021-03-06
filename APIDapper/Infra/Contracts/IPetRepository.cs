using APIDapper.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDapper.Infra.Contracts
{
    public interface IPetRepository
    {
        Task AddAsync(Pet pet);
        Task<Pet> GetByIdAsync(Guid id);

        Task<List<Pet>> GetAllAsync();

        Task<bool> UpdateByIdAsync(Pet pet);

        Task<int> RemoveByIdAsync(Guid id);

    }
}
