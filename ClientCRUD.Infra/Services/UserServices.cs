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

        public async Task<bool> VerifyUserAccess(Guid id, int[] type)
        {
            var entity = await _userRepository.GetById(id);
            if (entity == null)
                return false;
            for (int i = 0; i < type.Length; i++)
                if (entity.Type.Code == type[i])
                    return true;
            return false;
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
