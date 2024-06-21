using Business.Interfaces;
using Model.AddressModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class Address(Repository.Interfaces.IAddress address) : IAddress
    {
        private readonly Repository.Interfaces.IAddress _address = address;

        public async Task AddAddress(AddAddressModel model, int userId)
        {
            await _address.AddAddress(model, userId);
        }

        public async Task<AllAddressDetails> GetAddress(int userId)
        {
           return await _address.GetAddress(userId);
        }
    }
}
