using Microsoft.AspNetCore.Mvc;
using Model.RegisterationModel;
using Model.ResponseModels;

namespace Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RegisterationController(Business.Interfaces.IRegisteration registeration) : ControllerBase
    {
        private readonly Business.Interfaces.IRegisteration _registeration = registeration;

        [HttpPost("register")]
        public async Task<IActionResult> UserRegister(UserRegisterationModel model)
        {
            try
            {
                await _registeration.UserRegister(model);
                var response = new ResponseModel
                {
                    Success = true,
                    Message = "Registration successful!"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseModel
                {
                    Success = false,
                    Message = $"Registration Unsuccessful!. {ex.Message}"
                };
                return Ok(response);
            }

        }
    }
}
