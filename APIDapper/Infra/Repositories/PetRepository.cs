using APIDapper.Domain.Entities;
using APIDapper.Infra.Contracts;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections;
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

            return pet;

        }

        //GetAll
        public async Task<List<Pet>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Pet";           
            using var connection = _connectionFactory.Connection();
            var pets = connection.Query<Pet>(sql).ToList();

            //using var connection = _connectionFactory.Connection();
            //var pets = connection.GetAll<Pet>().ToList();

            return pets;
        }

        //UpdateById
        public async Task<bool> UpdateByIdAsync(Pet pet)
        {
            
            using var connection = _connectionFactory.Connection();
            var result = await connection.UpdateAsync(pet);

            return result;
        }

        //RemoveById
        public async Task<int> RemoveByIdAsync(Guid id)
        {
            const string sql = "DELETE  FROM Pet WHERE Id = @id";
            using var connection = _connectionFactory.Connection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@id", id);
          
            var affectedRows = connection.Execute(sql, parameters);

            //var result = connection.Execute(sql);

            //using var connection = _connectionFactory.Connection();
            //var result = connection.Delete(pet);

            return affectedRows;

        }


    }
}
