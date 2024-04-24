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
        public List<Customer> GetAll(); //Done
        public Customer GetById(string id); //Done
        public void Insert(Customer customer); //Done
        public void Update(Customer customer); //Done
        public void Delete(string id); //Done
    }
}
