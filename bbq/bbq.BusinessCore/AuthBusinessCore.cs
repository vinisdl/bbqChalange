using bbq.BusinessCore.Interfaces;
using bbq.Domain.Entities;
using bbq.Domain.ViewModel;
using bbq.Repository.Interfaces;

namespace bbq.BusinessCore
{
    public sealed class AuthBusinessCore : IAuthBusinessCore
    {
        private readonly IRepository<User> _repository;

        public AuthBusinessCore(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Auth(UserModel userModel)
        {
            var user = GetUser(userModel.UserName);

            return !Validate(user, userModel) ? null : user;
        }

        private User GetUser(string userName)
        {
            var user = _repository.GetByKey(userName);

            return user;
        }

        private static bool Validate(User user, UserModel userModel)
        {
            if (user == null)
            {
                return false;
            }

            return user.Password == userModel.Password;
        }
    }
}