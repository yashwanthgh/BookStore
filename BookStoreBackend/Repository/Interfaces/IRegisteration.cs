using Model.RegisterationModel;

namespace Repository.Interfaces
{
    public interface IRegisteration
    {
        public Task<bool> RegisterUser(UserRegisterationModel model);
    }
}
