using ClientCRUD.Domain.Entities;
using ClientCRUD.Domain.RequestTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Infra.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAll();
        public Customer GetByCode(string name);
        public Customer Insert();
        public Customer Update();
        public void Delete(string name);
    }
}
