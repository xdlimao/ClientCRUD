using ClientCRUD.Domain.Entities;
using ClientCRUD.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Infra.Services
{
    public class CustomerToNoDetails
    {
        public static CustomerNoDetails Convert(Customer list)
        {
            return new CustomerNoDetails()
            {
                Code = list.Code,
                Type = list.Type,
                Name = list.Name,
                Description = list.Description,
                IdentityType = list.IdentityType,
                Identity = list.Identity,
                Addresses = list.Addresses,
                Phones = list.Phones,
                Emails = list.Emails
            };
        }
    }
}
