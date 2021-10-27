using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class BasketCart
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }

        public List<BasketCartItem> Items { get; set; } = new List<BasketCartItem>();
        public BasketCart()
        {
        }

        public BasketCart(string userName)
        {
            UserName = userName;
        }

        //calc TotalPrice in cart
        public decimal TotalPrice
        { get
            {
                decimal tot = 0;
                foreach (var item in Items)
                {
                    tot += item.Price*item.Quantity;
                }
                return tot;
            }
        }
    }
}
