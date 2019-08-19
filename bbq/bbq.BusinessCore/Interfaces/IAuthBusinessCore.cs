using bbq.Domain.Entities;
using bbq.Domain.ViewModel;

namespace bbq.BusinessCore.Interfaces
{
    public interface IAuthBusinessCore
    {
        User Auth(UserModel userModel);
    }
}