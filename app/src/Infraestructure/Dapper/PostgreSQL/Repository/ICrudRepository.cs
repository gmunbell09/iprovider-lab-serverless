using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Dapper.PostgreSQL.Repository
{
    public interface ICrudRepository
    {
        List<Customer> ReadQuery();

    }
}
