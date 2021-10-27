using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class ProductModel : PageModel
    {
        private readonly ICatalogApi _catalogApi;
        private readonly IBasketApi _basketApi;

        public ProductModel(ICatalogApi catalogApi, IBasketApi basketApi)
        {
            _catalogApi = catalogApi;
            _basketApi = basketApi;
        }

        public IEnumerable<string> CategoryList { get; set; } = new List<string>();
        public IEnumerable<CatalogModel> ProductList { get; set; } = new List<CatalogModel>();


        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(string categoryname)
        {
            var productlist = await _catalogApi.GetCatalog();
            CategoryList = productlist.Select(P => P.Category).Distinct();

            if (! string.IsNullOrWhiteSpace(categoryname))
            {
                ProductList =  productlist.Where(p => p.Category == categoryname);
                SelectedCategory = categoryname;
            }
            else
            {
                ProductList = productlist; 
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            var product = await _catalogApi.GetCatalogById(productId);
            var username = "davidf";
            var basket = await _basketApi.GetBasket(username);
            basket.Items.Add(new BasketCartItem
            {
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1,
                Color = "black"
            });
            var basketupdated = await _basketApi.UpdateBasket(basket);
            return RedirectToPage("Cart");
        }
    }
}