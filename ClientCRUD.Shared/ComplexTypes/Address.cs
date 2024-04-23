using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Shared.ComplexTypes
{
    public class Address
    {
        public CodeName Type { get; set; }
        public string Street { get; set; } = "NotDefinedStreet";
        public string Number { get; set; } = "NotDefinedNumber";
        public string? Complement { get; set; }
        public string Neighborhood { get; set; } = "NotDefinedNeighborhood(Bairro)";
        public string City { get; set; } = "NotDefinedCity";
        public string State { get; set; } = "NotDefinedState";
        public string Country { get; set; } = "NotDefinedCountry";
        public string PostalCode { get; set; } = "NotDefinedPostalCode(CEP: 00000-000)";
    }
}

