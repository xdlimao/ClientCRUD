using ClientCRUD.Shared.ComplexTypes;

namespace ClientCRUD.Shared.Results
{
    public class NoDetailsCustomer
    {
        public NoDetailsCustomer()
        {
            Addresses = new List<Address>();
            Phones = new List<Phone>();
            Emails = new List<Email>();

        }
        public int Code { get; set; }
        public CodeName Type { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CodeName? IdentityType { get; set; }
        public string? Identity { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
    }
}

