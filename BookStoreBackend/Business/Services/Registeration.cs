using Business.Interfaces;
using Model.RegisterationModel;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class Registeration(Repository.Interfaces.IRegisteration registeration) : Interfaces.IRegisteration
    {
        private readonly Repository.Interfaces.IRegisteration _registeration = registeration;

        public async Task<bool> UserRegister(UserRegisterationModel model)
        {
            return await _registeration.RegisterUser(model);
        }
    }
}
