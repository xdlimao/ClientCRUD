using ClientCRUD.Domain.Entities;
using ClientCRUD.Domain.RequestTemplate;
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
        //public Customer GetByCode(string id);
        //public void Insert(string namer);
        //public void Update(string oldName, string newName);
        //public void Delete(string id);
    }
}
