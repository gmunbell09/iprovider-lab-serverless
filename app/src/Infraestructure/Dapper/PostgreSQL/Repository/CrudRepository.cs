using Core.Entity;
using Dapper;
using Infraestructure.Dapper.PostgreSQL.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infraestructure.Dapper.PostgreSQL.Repository
{
    public class CrudRepository: ICrudRepository
    {
        private IDbTransaction Transaction { get; }
        private IDbConnection Connection { get; }

        public CrudRepository(IDapperConnection context) 
        {
            Transaction = context.Transaction;
            Connection = context.Connection;
        }

        public List<Customer> ReadQuery()
        {
            var query = @"select companyid,name,ruc from public.companies limit 10;";

            return Connection.Query<Customer>(query, Transaction).AsList();


        }
    }
}
