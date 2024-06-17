using Model.LoginModel;

namespace Repository.Interfaces
{
    public interface ILogin
    {
        public Task<string> LoginUser(UserLoginModel model);
    }
}
