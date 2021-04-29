using APIDapper.Infra.Contracts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APIDapper.Infra.Factories
{
    public class SqlConnectionFactory : ISqlConnection
    {
        public IDbConnection Connection() => new SqlConnection("Data Source=FER-FIVEPC\\SQLEXPRESS;Initial Catalog=clienteDB;Integrated Security=True;");

       
    }
}
