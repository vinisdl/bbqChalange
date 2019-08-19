﻿using bbq.BusinessCore.Interfaces;
using bbq.Domain.ViewModel;
using bbq.Services.Interfaces;

namespace bbq.Services.Layers
{
    public sealed class UserServices : IUserServices
    {
        private readonly IAuthBusinessCore _authBusinessCore;
        private readonly ITokenBusinessCore _tokenBusinessCore;

        public UserServices(IAuthBusinessCore authBusinessCore, ITokenBusinessCore tokenBusinessCore)
        {
            _authBusinessCore = authBusinessCore;
            _tokenBusinessCore = tokenBusinessCore;
        }

        public string Auth(UserModel userModel)
        {
            var user = _authBusinessCore.Auth(userModel);

            if (user == null)
            {
                return null;
            }

            var token = _tokenBusinessCore.GenerateToken(user);

            return token;
        }

        public bool Validate(string userName, string token, out string message)
        {
            var result = _tokenBusinessCore.Validate(userName, token, out message);

            return result;
        }

        public string RefreshToken(string userName, string token, out string message)
        {
            var result = Validate(userName, token, out message);

            if (!result)
            {
                return null;
            }

            var refreshedToken = _tokenBusinessCore.RefreshToken(userName);

            return refreshedToken;
        }
    }
}