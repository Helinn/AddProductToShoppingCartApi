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
        public IShoppingCartService ShoppingCartService { get; set; }

        public ShoppingCartController(IShoppingCartService basketService)
        {
            ShoppingCartService = basketService;
        }

        public ICollection<ShoppingCart> GetAll()
        {
            return ShoppingCartService.GetShoppingCartItems();
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
            
            var res = ShoppingCartService.AddProductToShoppingCart(request);
            return Ok(res);
        }

        [HttpGet("products")]
        public ICollection<Product> GetProducts()
        {
            return ShoppingCartService.GetProducts();
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct([FromBody] AddProductRequest productRequest){
            var res = ShoppingCartService.AddProduct(productRequest);
            return Ok(res);
        }
    }
}
