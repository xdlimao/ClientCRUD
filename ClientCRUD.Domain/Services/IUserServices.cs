using ClientCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Domain.Services
{
    public interface IUserServices
    {
        public Task<User> SingInUser(string login, string password);
        public Task<bool> VerifyUserAccess(Guid id, int[] type);
    }
}
