using order.core.Entities.Reposoties.Base;
using order.core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace order.core.Entities.Reposoties
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string UserName);

    }
}
