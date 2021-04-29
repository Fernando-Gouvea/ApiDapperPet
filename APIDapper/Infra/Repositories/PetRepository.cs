using APIDapper.Domain.Entities;
using APIDapper.Infra.Contracts;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APIDapper.Infra.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ISqlConnection _connectionFactory;

        public PetRepository(ISqlConnection connetion)
        {
            _connectionFactory = connetion;
        }

        //Add
        public async Task AddAsync(Pet pet)
        {
            using var connection = _connectionFactory.Connection();
            connection.Open();
            await connection.InsertAsync(pet);

        }

        //GetById
        public async Task<Pet> GetByIdAsync(Guid id)
        {
            const string sql = "SELECT * FROM Pet WHERE Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add(name: "@id", id);
            using var connection = _connectionFactory.Connection();
            var pet = await connection.QuerySingleOrDefaultAsync<Pet>
                     (sql, parameters, commandType: CommandType.Text);

            return null;

        }

        
    }
}
