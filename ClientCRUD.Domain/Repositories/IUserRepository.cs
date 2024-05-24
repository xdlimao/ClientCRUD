using ClientCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetByLogin(string login);
    }
}
