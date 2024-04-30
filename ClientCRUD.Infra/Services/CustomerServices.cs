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
        public async Task<List<Customer>> GetCustomers() //Done
        {
            return await _customerRepository.GetAll();
        }
        public async Task<Customer> GetCustomerById(string id) //Done
        {
            return await _customerRepository.GetById(id);
        }
        public async Task<bool> DeleteCustomerById(string id) //Done
        {
            if (string.IsNullOrEmpty(id) || _customerRepository.GetById(id) == null) return false;
            await _customerRepository.Delete(id);
            return true;
        }
        public async Task<Customer> InsertCustomer(Customer customer) //Done
        {
            await _customerRepository.Insert(customer);
            return await _customerRepository.GetById(customer.Id.ToString());
        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            await _customerRepository.Update(customer);
            return await _customerRepository.GetById(customer.Id.ToString());
        }

        public async Task<Customer> CompareOldNewCustomer(UpdateCustomer updtcustomer)
        {
            Customer customerfinal = await _customerRepository.GetById(updtcustomer.Id.ToString());
            if(customerfinal != null)
            {
                if (updtcustomer.Type != null && updtcustomer.Type != customerfinal.Type)
                    customerfinal.Type = updtcustomer.Type;
                if (updtcustomer.Name != null && updtcustomer.Name != customerfinal.Name)
                    customerfinal.Name = updtcustomer.Name;
                if (updtcustomer.Nickname != null && updtcustomer.Nickname != customerfinal.Nickname)
                    customerfinal.Nickname = updtcustomer.Nickname;
                if (updtcustomer.Description != null && updtcustomer.Description != customerfinal.Description)
                    customerfinal.Description = updtcustomer.Description;
                if (updtcustomer.PersonType != null && updtcustomer.PersonType != customerfinal.PersonType)
                    customerfinal.PersonType = updtcustomer.PersonType;
                if (updtcustomer.IdentityType != null && updtcustomer.IdentityType != customerfinal.IdentityType)
                    customerfinal.IdentityType = updtcustomer.IdentityType;
                if (updtcustomer.Identity != null && updtcustomer.Identity != customerfinal.Identity)
                    customerfinal.Identity = updtcustomer.Identity;
                if (updtcustomer.Birthdate != null && updtcustomer.Birthdate != customerfinal.Birthdate)
                    customerfinal.Birthdate = updtcustomer.Birthdate;
                if (updtcustomer.Addresses.Count() != 0 && !updtcustomer.Addresses.SequenceEqual(customerfinal.Addresses))
                    customerfinal.Addresses = updtcustomer.Addresses;
                if (updtcustomer.Phones.Count() != 0 && !updtcustomer.Phones.SequenceEqual(customerfinal.Phones))
                    customerfinal.Phones = updtcustomer.Phones;
                if (updtcustomer.Emails.Count() != 0 && !updtcustomer.Emails.SequenceEqual(customerfinal.Emails))
                    customerfinal.Emails = updtcustomer.Emails;
                if (updtcustomer.Avatar != null && updtcustomer.Avatar != customerfinal.Avatar)
                    customerfinal.Avatar = updtcustomer.Avatar;
                if (updtcustomer.Image != null && updtcustomer.Image != customerfinal.Image)
                    customerfinal.Image = updtcustomer.Image;
                if (updtcustomer.Color != null && updtcustomer.Color != customerfinal.Color)
                    customerfinal.Color = updtcustomer.Color;
                if (updtcustomer.ReferenceCode != null && updtcustomer.ReferenceCode != customerfinal.ReferenceCode)
                    customerfinal.ReferenceCode = updtcustomer.ReferenceCode;
                if (updtcustomer.Note != null && updtcustomer.Note != customerfinal.Note)
                    customerfinal.Note = updtcustomer.Note;

                //Lógica especiais
                if (updtcustomer.Enabled)
                    if (!customerfinal.Enabled)
                        customerfinal.Enabled = true;
                else if (!updtcustomer.Enabled)
                    if(customerfinal.Enabled)
                        customerfinal.Enabled = false;

                if (updtcustomer.Code != customerfinal.Code)
                    customerfinal.Code = updtcustomer.Code;

                return customerfinal;
            }

            return null;
        }
    }
}
