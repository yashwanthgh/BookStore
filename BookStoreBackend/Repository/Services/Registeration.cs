using Dapper;
using Model.RegisterationModel;
using Repository.Context;
using Repository.Interfaces;
using System.Data;
using System.Text.RegularExpressions;

namespace Repository.Services
{
    public class Registeration(DapperContext context) : IRegisteration
    {
        private readonly DapperContext _context = context;

        public async Task<bool> RegisterUser(UserRegisterationModel model)
        {
            if (!IsEmailValid(model.Email)) throw new Exception("Invalid email formate");
            if (!IsPasswordValid(model.Password)) throw new Exception("Invalid password formate");

            var parameters = new DynamicParameters();

            parameters.Add("Name", model.Name, DbType.String);
            parameters.Add("Email", model.Email, DbType.String);
            parameters.Add("Password", BCrypt.Net.BCrypt.HashPassword(model.Password), DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var emailExists = await connection.QueryFirstOrDefaultAsync<bool>("spRegisterUser", parameters, commandType: CommandType.StoredProcedure);

                if (emailExists)
                {
                    throw new Exception("Email alredy exists!");
                }
                return true;
            }
        }

        private static bool IsEmailValid(string? email)
        {
            var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (email == null) return false;
            return Regex.IsMatch(email, pattern);
        }

        private static bool IsPasswordValid(string? password)
        {
            var pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*])(?=.*[0-9]).{8,15}$";
            if (password == null) return false;
            return Regex.IsMatch(password, pattern);
        }
    }
}
