using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.CartModels;
using System.Security.Claims;
using Model.ResponseModels;
using Repository.Entities;

namespace Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CartController(ICart cart) : ControllerBase
    {
        private readonly Business.Interfaces.ICart _Cart = cart;

        [Authorize]
        [HttpPost("addToCart")]
        public async Task<IActionResult> AddToCart(AddToCartRequestModel model)
        {
            try
            {

                var userIdClime = User.FindFirstValue("UserId");
                int userId = Convert.ToInt32(userIdClime);
                var addToCartValue = new AddToCartModel
                {
                    Quantity = model.Quantity,
                    UserId = userId,
                    IsOrdered = model.IsOrdered,
                    IsUnCarted = model.IsUnCarted,
                    BookId = model.BookId,
                };
                var result = await _Cart.AddCart(addToCartValue);
                return Ok(new ResponseModel
                {
                    Success = true,
                    Message = "Added to cart"
                });

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel
                {
                    Success = false,
                    Message = $"Failed to Add to cart. {ex.Message}"
                });
            }
        }

        [Authorize]
        [HttpGet("getCartBooks")]
        public async Task<IActionResult> GetAllCartBooks()
        {
            try
            {
                var userIdClime = User.FindFirstValue("UserId");
                int userId = Convert.ToInt32(userIdClime);
                return Ok(new ResponseModel<IEnumerable<CartResponse>>
                {
                    Success = true,
                    Message = "Cart Books fetched uccessfully",
                    Data = await _Cart.GetCartByUserId(userId)
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel
                {
                    Success = false,
                    Message = $"Unable to fetch cart data. {ex.Message}"
                });
            }
        }

        [Authorize]
        [HttpPatch("uncart{cartId}")]
        public async Task<IActionResult> UnCart(int cartId)
        {
            try
            {
                var userIdClime = User.FindFirstValue("UserId");
                int userId = Convert.ToInt32(userIdClime);
                await _Cart.UnCart(cartId, userId);
                return Ok(new ResponseModel
                {
                    Success = true,
                    Message = "Uncarted successfully!"
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel
                {
                    Success = false,
                    Message = $"Uncarting failed. {ex.Message}"
                });
            }
        }

        [Authorize]
        [HttpPatch("updatecartOrder")]
        public async Task<IActionResult> UpdateCartOrder(int cartId, bool isOrdered)
        {
            try
            {
                await _Cart.UpdateCartOrder(cartId, isOrdered);
                return Ok(new ResponseModel
                {
                    Success = true,
                    Message = "Cart updated successfully!"
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel
                {
                    Success = false,
                    Message = $"Updating cart failed. {ex.Message}"
                });
            }
        }

        [Authorize]
        [HttpPatch("updateCartQuantity")]
        public async Task<IActionResult> UpdateCartquantity(int cartId, int quantity)
        {
            try
            {
                await _Cart.UpdateCartquantity(cartId, quantity);
                return Ok(new ResponseModel
                {
                    Success = true,
                    Message = "Cart quantity updated successfully!"
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel
                {
                    Success = false,
                    Message = $"Updating cart quantity failed. {ex.Message}"
                });
            }
        }
    }
}
