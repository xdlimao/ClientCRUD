using ClientCRUD.Domain.Entities;
using ClientCRUD.Domain.Services;
using ClientCRUD.Infra.Repositories;
using ClientCRUD.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Infra.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly CustomerRepository _customerRepository;
        public CustomerServices(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public List<Customer> GetCustomers() //Done
        {
            return _customerRepository.GetAll();
        }
        public Customer GetCustomerById(string id) //Done
        {
            var document = _customerRepository.GetById(id);
            return document;
        }
        public bool DeleteCustomerById(string id) //Done
        {
            if (string.IsNullOrEmpty(id) || _customerRepository.GetById(id) == null) return false;
            _customerRepository.Delete(id);
            return true;
        }
        public Customer InsertCustomer(Customer customer) //Done
        {
            _customerRepository.Insert(customer);
            return _customerRepository.GetById(customer.Id.ToString());
        }
        public Customer UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        //public Customer CompareOldNewCustomer(UpdateCustomer updtcustomer)
        //{
        //    Customer customerfinal = _customerRepository.GetById(updtcustomer.Id.ToString());
        //    if (updtcustomer.Id != null && updtcustomer.Id != customerfinal.Id)
        //        customerfinal.Id = updtcustomer.Id;
        //    if (updtcustomer.Code != null && updtcustomer.Code != customerfinal.Code)
        //        customerfinal.Code = updtcustomer.Code;
        //    if (updtcustomer.Type != null && updtcustomer.Type != customerfinal.Type)
        //        customerfinal.Type = updtcustomer.Type;
        //    if (updtcustomer.Name != null && updtcustomer.Name != customerfinal.Name)
        //        customerfinal.Name = updtcustomer.Name;
        //    if (updtcustomer.Nickname != null && updtcustomer.Nickname != customerfinal.Nickname)
        //        customerfinal.Nickname = updtcustomer.Nickname;
        //    if (updtcustomer.Description != null && updtcustomer.Description != customerfinal.Description)
        //        customerfinal.Description = updtcustomer.Description;
        //    if (updtcustomer.PersonType != null && updtcustomer.PersonType != customerfinal.PersonType)
        //        customerfinal.PersonType = updtcustomer.PersonType;
        //    if (updtcustomer.IdentityType != null && updtcustomer.IdentityType != customerfinal.IdentityType)
        //        customerfinal.IdentityType = updtcustomer.IdentityType;
        //    if (updtcustomer.Identity != null && updtcustomer.Identity != customerfinal.Identity)
        //        customerfinal.Identity = updtcustomer.Identity;
        //    if (updtcustomer.Birthdate != null && updtcustomer.Birthdate != customerfinal.Birthdate)
        //        customerfinal.Birthdate = updtcustomer.Birthdate;
        //    if (updtcustomer.Enabled != null || updtcustomer.Enabled != customerfinal.Enabled)
        //        customerfinal.Enabled = updtcustomer.Enabled;
        //    if (updtcustomer.Addresses != null && !updtcustomer.Addresses.SequenceEqual(customerfinal.Addresses))
        //        customerfinal.Addresses = updtcustomer.Addresses;
        //    if (updtcustomer.Phones != null && !updtcustomer.Phones.SequenceEqual(customerfinal.Phones))
        //        customerfinal.Phones = updtcustomer.Phones;
        //    if (updtcustomer.Emails != null && !updtcustomer.Emails.SequenceEqual(customerfinal.Emails))
        //        customerfinal.Emails = updtcustomer.Emails;
        //    if (updtcustomer.Avatar != null && updtcustomer.Avatar != customerfinal.Avatar)
        //        customerfinal.Avatar = updtcustomer.Avatar;
        //    if (updtcustomer.Image != null && updtcustomer.Image != customerfinal.Image)
        //        customerfinal.Image = updtcustomer.Image;
        //    if (updtcustomer.Color != null && updtcustomer.Color != customerfinal.Color)
        //        customerfinal.Color = updtcustomer.Color;
        //    if (updtcustomer.ReferenceCode != null && updtcustomer.ReferenceCode != customerfinal.ReferenceCode)
        //        customerfinal.ReferenceCode = updtcustomer.ReferenceCode;
        //    if (updtcustomer.Note != null && updtcustomer.Note != customerfinal.Note)
        //        customerfinal.Note = updtcustomer.Note;

        //    return customerfinal;
        //}
    }
}
