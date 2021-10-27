using Basket.API.Entities;
using Basket.API.Repositories.Interfaces.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories.Interfaces
{
    public interface IBasketRepository: IRepository<BasketCart>
    {
        Task<BasketCart> GetBasket(string Username);
        Task<BasketCart> UpdateBasket(BasketCart baskt);
        Task<bool> DeleteBasket(string UserName);

    }
}
