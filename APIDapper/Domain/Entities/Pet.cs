using APIDapper.Domain.Fixed;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDapper.Domain.Entities
{
    [Table(tableName:"[dbo].[Pet]")]
    public class Pet
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TypePet Type { get; set; }
    }
}
