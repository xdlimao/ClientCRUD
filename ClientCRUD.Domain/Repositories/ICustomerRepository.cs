using ClientCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Domain.Repositories
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAll(); //Done
        public Task<List<Customer>> GetAllWithLimitAndSkip(int limit, int skip);
        public Task<Customer> GetById(string id); //Done
        public Task Insert(Customer customer); //Done
        public Task Update(Customer customer); //Done
        public Task Delete(string id); //Done
    }
}
