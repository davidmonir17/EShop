using System;
using System.Threading.Tasks;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class CheckOutModel : PageModel
    {
        private readonly ICatalogApi _catalogApi;
        private readonly IBasketApi _basketApi;

        public CheckOutModel(ICatalogApi catalogApi, IBasketApi basketApi)
        {
            _catalogApi = catalogApi;
            _basketApi = basketApi;
        }

        [BindProperty]
        public BasketCheackoutModel Order { get; set; }

        public BasketModel Cart { get; set; } = new BasketModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var username = "davidf";
            Cart = await _basketApi.GetBasket(username);
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            var username = "davidf";
            Cart = await _basketApi.GetBasket(username);
          

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.UserName = username;
            Order.TotalPrice = Cart.TotalPrice;

            await _basketApi.CheackoutBasket(Order);
            
            return RedirectToPage("Confirmation", "OrderSubmitted");
        }       
    }
}