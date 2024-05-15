using ClientCRUD.Domain.Entities;
using ClientCRUD.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Domain.Services
{
    public interface ICustomerServices
    {
        public Task<List<Customer>> GetCustomers(); //Done
        public Task<Customer> GetCustomerById(string id); //Done
        public Task<bool> DeleteCustomerById(string id); //Done
        public Task<Customer> InsertCustomer(Customer customer); //Done
        public Task<Customer> UpdateCustomer(Customer customer);
        public Task<Customer> CompareOldNewCustomer(CustomerUpdate updtcustomer); //Done
    }
}
