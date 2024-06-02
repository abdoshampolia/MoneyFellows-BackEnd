using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyFellows.API.Controllers.Base;
using MoneyFellows.Application.Features.Orders.Commands.CreateOrder;
using MoneyFellows.Application.Features.Orders.Commands.DeleteOrder;
using MoneyFellows.Application.Features.Orders.Commands.UpdateOrder;
using MoneyFellows.Application.Features.Orders.Queries.GetAllOrders;
using MoneyFellows.Application.Features.Orders.Queries.GetOrderById;

namespace MoneyFellows.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ApiControllerBase
    {
        //Commands

        [Authorize(Roles = "User")]
        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "User")]
        [HttpPut("update-order")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "User")]
        [HttpDelete("delete-order/{Id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] DeleteOrderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //Queries

        [Authorize(Roles = "User,Admin")]
        [HttpGet("get-orders")]
        public async Task<IActionResult> GetOrder([FromQuery] GetOrdersQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("get-orders-by-id/{Id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] GetOrderByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
