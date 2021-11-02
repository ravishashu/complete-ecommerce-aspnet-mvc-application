using ETickets.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Data.ViewComponents
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart _shopingCart;
        public ShoppingCartSummary(ShoppingCart shopingCart)
        {
            _shopingCart = shopingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shopingCart.GetShoppingCartItems();
            return View(items.Count());
        }
    }
}
