using Business.Interfaces;
using Model.LoginModel;

namespace Business.Services
{
    public class Login(Repository.Interfaces.ILogin login) : ILogin
    {
        private readonly Repository.Interfaces.ILogin _login = login;

        public async Task<string> LoginUser(UserLoginModel model)
        {
            return await _login.LoginUser(model);
        }
    }
}