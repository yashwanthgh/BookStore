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
                return Ok("Registration successful!");
            }
            catch (Exception ex)
            {
                return Ok($"Null Data, {ex.Message}");
            }

        }
    }
}
