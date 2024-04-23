using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Shared.ComplexTypes
{
    public class Phone
    {
        public CodeName Type { get; set; }
        public string CountryCode {  get; set; }
        public string DDD { get; set; }
        public string PhoneNumber { get; set; }
    }
}
