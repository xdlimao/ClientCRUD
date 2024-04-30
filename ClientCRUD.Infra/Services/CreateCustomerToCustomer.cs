using ClientCRUD.Domain.Entities;
using ClientCRUD.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Infra.Services
{
    public class CreateCustomerToCustomer
    {
        public static Customer Convert(CreateCustomer newcustomer)
        {
            return new Customer()
            {
                Id = Guid.NewGuid(),
                Code = newcustomer.Code,
                Name = newcustomer.Name,
                Type = newcustomer.Type,
                Nickname = newcustomer.Nickname,
                Description = newcustomer.Description,
                PersonType = newcustomer.PersonType,
                IdentityType = newcustomer.IdentityType,
                Identity = newcustomer.Identity,
                Birthdate = newcustomer.Birthdate,
                Enabled = true,
                Addresses = newcustomer.Addresses,
                Phones = newcustomer.Phones,
                Emails = newcustomer.Emails,
                Avatar = newcustomer.Avatar,
                Image = newcustomer.Image,
                Color = newcustomer.Color,
                ReferenceCode = newcustomer.ReferenceCode,
                Note = newcustomer.Note
            };
        }
    }
}
