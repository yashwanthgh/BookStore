using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.AddressModels;
using Model.ResponseModels;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AddressController(IAddress address) : ControllerBase
    {
        private readonly Business.Interfaces.IAddress _address = address;

        [Authorize]
        [HttpPost("addAddress")]
        public async Task<IActionResult> AddAddress(AddAddressModel model)
        {
            try
            {
                var userIdClime = User.FindFirstValue("UserId");
                int userId = Convert.ToInt32(userIdClime);
                await _address.AddAddress(model, userId);
                return Ok(new ResponseModel
                {
                    Success = true,
                    Message = "Address Added successfully"
                });
            } catch (Exception ex)
            {
                return Ok(new ResponseModel
                {
                    Success = false,
                    Message = $"Address Already Exists. {ex.Message}"
                });
            }
        }

        [Authorize]
        [HttpGet("getAddress")]
        public async Task<IActionResult> GetUserAddress()
        {
            try
            {
                var userIdClime = User.FindFirstValue("UserId");
                int userId = Convert.ToInt32(userIdClime);
                var address = await _address.GetAddress(userId);
                return Ok(new ResponseModel<AllAddressDetails>
                {
                    Success = true,
                    Message = "Address fetched successfully!",
                    Data = address
                });
            } catch(Exception ex)
            {
                return Ok(new ResponseModel
                {
                    Success = false,
                    Message = $"Address fetch failed. {ex.Message}"
                });
            }
        }
    }
}
