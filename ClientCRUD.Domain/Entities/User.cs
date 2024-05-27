using ClientCRUD.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string  Login { get; set; }
        public string Password { get; set; }
        public CodeName Type { get; set; } = new();
    }
}
