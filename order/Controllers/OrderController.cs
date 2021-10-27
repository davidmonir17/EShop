using MediatR;
using Microsoft.AspNetCore.Mvc;
using order.Application.Command;
using order.Application.Queries;
using order.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace order.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class OrderController:ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderResponse>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrdersByUserName(String username)
        {
            var query = new GetOrderByUserNameQuery(username);
            var orders = await mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderResponse>> CheckoutOrder([FromBody] CheckoutOrderCommand command )
         {
            
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
