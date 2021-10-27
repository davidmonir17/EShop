using Microsoft.EntityFrameworkCore;
using order.core.Entities.Reposoties;
using order.core.Entity;
using order.infrastructure.Data;
using order.infrastructure.Reposotries.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order.infrastructure.Reposotries
{
    public class OrderReposotiry:Repository<Order>,IOrderRepository
    {
        public OrderReposotiry( OrderContext dbcontext):base(dbcontext)
        {

        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string UserName)
        {
            var orderList = await _dbcotext.Orders.Where(o => o.UserName == UserName).ToListAsync();
            return orderList;
        }
    }
}
