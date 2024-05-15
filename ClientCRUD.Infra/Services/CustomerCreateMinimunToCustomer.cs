using ClientCRUD.Domain.Entities;
using ClientCRUD.Shared.Parameters;


namespace ClientCRUD.Infra.Services
{
    public class CustomerCreateMinimunToCustomer
    {
        public static Customer Convert(CustomerCreateMinimum newcustomer)
        {
            return new Customer()
            {
                Id = Guid.NewGuid(),
                Code = newcustomer.Code,
                Type = newcustomer.Type,
                Addresses = newcustomer.Addresses,
                Emails = newcustomer.Emails,
                Phones = newcustomer.Phones,
                Enabled = true
            };
        }
    }
}
