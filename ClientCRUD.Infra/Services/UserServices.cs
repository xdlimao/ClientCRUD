using ClientCRUD.Domain.Entities;
using ClientCRUD.Domain.Services;
using ClientCRUD.Infra.Repositories;

namespace ClientCRUD.Infra.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserRepository _userRepository;
        public UserServices(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> SingInUser(string login, string password)
        {
            var entity = await _userRepository.GetByLogin(login);
            if (entity != null && entity.Password == password)
                return entity;
            return null;
        }
    }
}
