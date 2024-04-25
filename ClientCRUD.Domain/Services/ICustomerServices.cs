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
        public List<Customer> GetCustomers(); //Done
        public Customer GetCustomerById(string id); //Done
        public bool DeleteCustomerById(string id); //Done
        public Customer InsertCustomer(Customer customer); //Done
        public Customer UpdateCustomer(Customer customer);
        public Customer CompareOldNewCustomer(UpdateCustomer updtcustomer); //Done
    }
}
