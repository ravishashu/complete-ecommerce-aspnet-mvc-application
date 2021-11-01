using ETickets.Data.Cart;
using ETickets.Data.Services;
using ETickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesService _movieService;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart)
        {
            _movieService = moviesService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var responce = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(responce);
        }
    }
}
