using Model.AddressModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAddress
    {
        public Task AddAddress(AddAddressModel model, int userId);
        public Task<AllAddressDetails> GetAddress(int userId);
    }
}
