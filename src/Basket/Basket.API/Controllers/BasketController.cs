using AutoMapper;
using Basket.API.Entities;
using Basket.API.Repositories.Interfaces;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;
        private readonly EventBusRabbitMQProducer _EventBus;

        public BasketController(IBasketRepository repository, IMapper mapper, EventBusRabbitMQProducer eventBus)
        {
            _repository = repository;
            _mapper = mapper;
            _EventBus = eventBus;
        }

        [HttpGet]
        public async Task<ActionResult<BasketCart>> GetBasket(string Username)
        {
            var baskt = await _repository.GetBasket(Username);
            if (baskt == null)
            {
                return BadRequest();
            }
            return Ok(baskt);
        }
        [HttpPost]
        public async Task<ActionResult<BasketCart>> UpdateBasket([FromBody] BasketCart basket)
        {
            return Ok(await _repository.UpdateBasket(basket));
        }

        [HttpDelete("{Username}")]
        public async Task<IActionResult> DeleteBasket(string Username)
        {
            return Ok(await _repository.DeleteBasket(Username));
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> checkout([FromBody] BasketCheckoout basketCheckoout)
        {
            var basket = await _repository.GetBasket(basketCheckoout.UserName);
            if (basket == null)
            {
                return BadRequest();

            }
            var deleteBasket = await _repository.DeleteBasket(basket.UserName);
            if (!deleteBasket)
            {
                return BadRequest();
            }
            var eventmsg = _mapper.Map<BasketCheckoutEvent>(basketCheckoout);
            eventmsg.RequestId = Guid.NewGuid();
            eventmsg.TotalPrice = basket.TotalPrice;
            try
            {
                _EventBus.PublishBasketChekout(EventBusConstants.BasketCheckoutQueue, eventmsg);
            }
            catch (Exception)
            {

                throw;
            }
            return Accepted();
        }
    }
}
