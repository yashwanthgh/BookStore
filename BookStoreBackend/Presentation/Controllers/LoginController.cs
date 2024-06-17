using Microsoft.AspNetCore.Mvc;
using Model.LoginModel;
using Model.ResponseModels;
using Business.Interfaces;

namespace Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController(ILogin login) : ControllerBase
    {
        private readonly ILogin _login = login;

        [HttpPost("login")]
        public async Task<IActionResult> UserLogin(UserLoginModel model)
        {
            try
            {
                var token = await _login.LoginUser(model);

                var response = new ResponseModel<string>
                {
                    Success = true,
                    Message = "Login successful!",
                    Data = token.ToString()
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel
                {
                    Success = false,
                    Message = $"Null Data, {ex.Message}"
                };
                return Ok(response);
            }
        }
    }
}
