using MediatR;
using order.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace order.Application.Queries
{
     public class GetOrderByUserNameQuery:IRequest<IEnumerable<OrderResponse>>
    {
        public string UserName { get; set; }

        public GetOrderByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
