using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientCRUD.Shared.ComplexTypes
{
    public class Email
    {
        public CodeName Type { get; set; }
        public string Address { get; set; }
    }
}
