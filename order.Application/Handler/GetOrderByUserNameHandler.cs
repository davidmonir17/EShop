using MediatR;
using order.Application.Mapper;
using order.Application.Queries;
using order.Application.Responses;
using order.core.Entities.Reposoties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace order.Application.Handler
{
    public class GetOrderByUserNameHandler:IRequestHandler<GetOrderByUserNameQuery,IEnumerable<OrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByUserNameHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderResponse>> Handle(GetOrderByUserNameQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrdersByUserName(request.UserName);
            var OrderResponseList = OrderMapper.mapper.Map<IEnumerable<OrderResponse>>(orderList);
            return OrderResponseList;

        }
    }
}
