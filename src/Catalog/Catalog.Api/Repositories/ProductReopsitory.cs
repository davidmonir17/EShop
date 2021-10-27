using Catalog.Api.Data;
using Catalog.Api.Entities;
using Catalog.Api.Repositories.Base;
using Catalog.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories
{
    public class ProductReopsitory : Repository<Product>, IProductReopsitory
    {
        public ProductReopsitory(CatalogContext dbcontext) : base(dbcontext)
        {
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var prl = await _dbcotext.products.ToListAsync();
            return prl;
        }
        public async Task<Product> GetProduct(int Id)
        {
            var prd = await _dbcotext.products.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return prd;
        }
        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            var prl = await _dbcotext.products.Where(x => x.Name == name).ToListAsync();
            return prl;

        }
        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            var prl = await _dbcotext.products.Where(x => x.Category == categoryName).ToListAsync();
            return prl;
        }
        public async Task Create(Product product)
        {
             await _dbcotext.products.AddAsync(product);
            await _dbcotext.SaveChangesAsync();
        }

        public async Task<bool> Update(Product product)
        {
           
            var tra = _dbcotext.Update<Product>(product);
            
            await _dbcotext.SaveChangesAsync();
            if (tra != null)
            {
                return true;
            }
            return false;
           
        }
        public async Task<bool> Delete(Product product)
        {
            var prd = await _dbcotext.products.FirstOrDefaultAsync(o => o.Id==product.Id);
            try
            {
                _dbcotext.Remove<Product>(product);
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
