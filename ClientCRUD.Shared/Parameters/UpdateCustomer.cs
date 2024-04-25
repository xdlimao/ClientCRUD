using ClientCRUD.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Shared.Parameters
{
    public class UpdateCustomer
    {
        public UpdateCustomer()
        {
            Addresses = new List<Address>();
            Phones = new List<Phone>();
            Emails = new List<Email>();
        }
        public Guid Id { get; set; }
        public int Code { get; set; } = 0;
        public string? Name { get; set; }
        public CodeName? Type { get; set; }
        public string? Nickname { get; set; }
        public string? Description { get; set; }
        public CodeName? PersonType { get; set; }
        public CodeName? IdentityType { get; set; }
        public string? Identity { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool Enabled { get; set; } = true;
        public List<Address>? Addresses { get; set; }
        public List<Phone>? Phones { get; set; }
        public List<Email>? Emails { get; set; }
        public string? Avatar { get; set; } //Image URL
        public string? Image { get; set; } //Image URL
        public string? Color { get; set; } //HEX(#xxxxxx) or RGB(x,x,x)
        public string? ReferenceCode { get; set; }
        public string? Note { get; set; }
    }
}
