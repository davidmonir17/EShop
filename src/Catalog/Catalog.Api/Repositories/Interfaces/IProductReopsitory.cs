using Catalog.Api.Entities;
using Catalog.Api.Repositories.Interfaces.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories.Interfaces
{
    public interface IProductReopsitory : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int Id);
        Task<IEnumerable<Product>> GetProductByName(String name);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);

        Task Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(Product ID);



    }
}
