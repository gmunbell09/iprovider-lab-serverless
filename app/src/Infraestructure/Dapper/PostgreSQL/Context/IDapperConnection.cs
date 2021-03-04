using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infraestructure.Dapper.PostgreSQL.Context
{
    public interface IDapperConnection: IDisposable
    {
        IDbConnection Connection { get; }

        IDbTransaction Transaction { get; set; }

        IDbConnection CreateConnection();

    }
}
