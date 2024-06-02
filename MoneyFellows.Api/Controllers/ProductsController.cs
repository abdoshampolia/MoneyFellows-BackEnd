using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyFellows.API.Controllers.Base;
using MoneyFellows.Application.Features.Products.Commands.CreateProduct;
using MoneyFellows.Application.Features.Products.Commands.DeleteProduct;
using MoneyFellows.Application.Features.Products.Commands.UpdateProduct;
using MoneyFellows.Application.Features.Products.Queries.GetAllProducts;
using MoneyFellows.Application.Features.Products.Queries.GetProductById;

namespace MoneyFellows.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ApiControllerBase
    {
        //Commands

        [Authorize(Roles = "Admin")]
        [HttpPost("create-product")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update-product")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-product/{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //Queries

        [Authorize(Roles = "User,Admin")]
        [HttpGet("get-products")]
        public async Task<IActionResult> GetProduct([FromQuery] GetProductsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("get-products-by-id/{Id}")]
        public async Task<IActionResult> GetProductById([FromRoute] GetProductByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

    }
}
