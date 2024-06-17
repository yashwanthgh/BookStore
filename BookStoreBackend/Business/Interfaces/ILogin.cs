using Model.LoginModel;

namespace Business.Interfaces
{
    public interface ILogin
    {
         public Task<string> LoginUser(UserLoginModel model);
    }
}