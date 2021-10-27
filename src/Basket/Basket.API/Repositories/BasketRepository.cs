using Basket.API.Data;
using Basket.API.Entities;
using Basket.API.Repositories.Base;
using Basket.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace Basket.API.Repositories
{
    public class BasketRepository : Repository<BasketCart>, IBasketRepository
    {

        public BasketRepository(BasketContext dbcontext) : base(dbcontext)
        {

        }
        public async Task<BasketCart> GetBasket(string Username)
        {
            var baskt = await _dbcotext.baskets.Include("Items").Where(o => o.UserName == Username ).FirstOrDefaultAsync();
            if (baskt == null)
            {
                return null;
            }
            return baskt;
        }
      
        public async Task<BasketCart> UpdateBasket(BasketCart baskt)
        {
            var bas = await _dbcotext.baskets.AsNoTracking().Where(o => o.UserName == baskt.UserName).SingleOrDefaultAsync();


            if (bas==null)
            {
                try
                {
                    await  _dbcotext.AddAsync(baskt);
                    await  _dbcotext.SaveChangesAsync();
                    return baskt;
                }
                catch (Exception ex)
                {
                   
                }

            }
            else
            {
                try
                {
                    baskt.Id = bas.Id ;
                   var tra = _dbcotext.Update<BasketCart>(baskt);
                    await _dbcotext.SaveChangesAsync();
                    return baskt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }
        public  async Task<bool> DeleteBasket(string UserName)
        {
            var baskt = await _dbcotext.baskets.FirstOrDefaultAsync(o => o.UserName == UserName);
            try
            {
                _dbcotext.Remove<BasketCart>(baskt);
               await _dbcotext.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                return false;            
            }

        }
    }

}
