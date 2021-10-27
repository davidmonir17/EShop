using MediatR;
using order.Application.Command;
using order.Application.Mapper;
using order.Application.Responses;
using order.core.Entities.Reposoties;
using order.core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace order.Application.Handler
{
    public class checkoutOrderHandler : IRequestHandler<CheckoutOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public checkoutOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderResponse> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = OrderMapper.mapper.Map<Order>(request);
            if(orderEntity==null)
            {
                throw new ApplicationException("Not Mapped!");
            }
            var newOrder = await _orderRepository.AddAsync(orderEntity);
            var orderresponse = OrderMapper.mapper.Map<OrderResponse>(newOrder);
            return orderresponse;
        }
    }
}
