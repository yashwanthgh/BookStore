using Dapper;
using Model.LoginModel;
using Repository.Context;
using Repository.Interfaces;
using Repository.Entities;
using System.Data;


namespace Repository.Services
{
    public class Login(DapperContext context, IAuth auth) : ILogin
    {
        private readonly DapperContext _context = context;
        private readonly IAuth _auth = auth;

        public async Task<string> LoginUser(UserLoginModel model)
        {
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>("spGetUserByEmail", new { model.Email }, commandType: CommandType.StoredProcedure);

                if (user == null) throw new Exception($"User with email '{model.Email}' not found.");

                if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password)) throw new Exception($"Wrong Password");

                return _auth.GenerateJwtToken(user);
            }
        }
    }
}
