using ClientCRUD.Domain.Entities;
using ClientCRUD.Infra.Context;
using ClientCRUD.Infra.Repositores.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Infra.Repositores

{
    public class CustomerRepository : ICustomerRepository
    {

        public Customer Delete()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetByCode()
        {
            throw new NotImplementedException();
        }

        public Customer Insert()
        {
            throw new NotImplementedException();
        }

        public Customer Update()
        {
            throw new NotImplementedException();
        }
    }
}
