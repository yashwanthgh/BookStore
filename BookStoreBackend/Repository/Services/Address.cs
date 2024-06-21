using Dapper;
using Model.AddressModels;
using Repository.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class Address(DapperContext context) : IAddress
    {
        private readonly DapperContext _context = context;

        public async Task AddAddress(AddAddressModel model, int userId)
        {
            using(var connection = _context.CreateConnection())
            {
                var addressAlreadyExists = await connection.QuerySingleAsync<bool>("addressExists", new { UserId = userId }, commandType: System.Data.CommandType.StoredProcedure);

                var userDelaits = await connection.QueryFirstAsync<GetUserDetailsModel>("spGetUserDetails", new { UserId = userId }, commandType: System.Data.CommandType.StoredProcedure);

                if (userDelaits != null && !addressAlreadyExists)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("UserId", userId, System.Data.DbType.Int64);
                    parameters.Add("Name", userDelaits.Name, System.Data.DbType.String);
                    parameters.Add("Number", userDelaits.Number, System.Data.DbType.Int64);
                    parameters.Add("Email", userDelaits.Email, System.Data.DbType.String);
                    parameters.Add("Address", model.Address, System.Data.DbType.String);
                    parameters.Add("City", model.City, System.Data.DbType.String);
                    parameters.Add("State", model.State, System.Data.DbType.String);

                    await connection.ExecuteAsync("spAddAddress", parameters, commandType: System.Data.CommandType.StoredProcedure);
                } else
                {
                    throw new Exception("Address Already exists");
                }
            }
        }

        public async Task<AllAddressDetails> GetAddress(int userId)
        {
            using(var connection = _context.CreateConnection())
            {
                var address = await connection.QueryFirstAsync<AllAddressDetails>("spGetUsersAddress", new { UserId = userId }, commandType: System.Data.CommandType.StoredProcedure);
                return address;
            }
        }
    }
}
