using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Models;
using ShoppingCartApi.Requests;
using ShoppingCartApi.Services;

namespace ShoppingCartApi.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        public IShoppingCartService BasketService { get; set; }

        public ShoppingCartController(IShoppingCartService basketService)
        {
            BasketService = basketService;
        }

        public ICollection<ShoppingCart> GetAll()
        {
            return BasketService.GetShoppingCartItems();
        }

        [HttpPost]
        public IActionResult AddProductToShoppingCart([FromBody] AddToShoppingCartRequest request)
        {
            if (request == null) {
                return BadRequest("product can not be null!");
            }

            if(string.IsNullOrEmpty(request.ProductId)) {
                return BadRequest("product id should be greater than zero!");
            }
            
            var res = BasketService.AddProductToShoppingCart(request);
            return Ok(res);
        }
    }
}
