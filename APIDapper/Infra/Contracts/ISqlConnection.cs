using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APIDapper.Infra.Contracts
{
    public interface ISqlConnection
    {
        IDbConnection Connection();

    }

       
}
