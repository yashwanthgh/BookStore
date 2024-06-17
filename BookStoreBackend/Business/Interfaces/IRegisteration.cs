using Model.RegisterationModel;

namespace Business.Interfaces
{
    public interface IRegisteration
    {
        public Task<bool> UserRegister(UserRegisterationModel model);
    }
}
