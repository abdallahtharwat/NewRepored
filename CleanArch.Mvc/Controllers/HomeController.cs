using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Mvc.Models;
using CleanArch.Mvc.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CleanArch.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IShoppingCartService  _shoppingCartService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IShoppingCartService shoppingCartService)
        {
            _logger = logger;
            _productService = productService;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> Productlist = _productService.GetAll(includeproperties: "Category,type,productImages");
            return View(Productlist);
        }
        public IActionResult Details(int productid)
        {
            //get product and productid and count from database to pass to view
            ShopingCart cart = new()
            {
                Product = _productService.Get(u => u.Id == productid, includeproperties: "Category,type,productImages"),
                Count = 1,
                ProductId = productid
            };
            return View(cart);
        }

        [HttpPost]
        [Authorize]  // when we add a item in cart we must be login first
        public IActionResult Details(ShopingCart shoppingCart)
        {
            // when we push cart button we need Userid and productid
            var claimsIdentity = (ClaimsIdentity)User.Identity;   // right here we have the userid  -- There is a special claim with the name of name identifier that will have user ID of the logged in user.
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value; // When a user logs in, we have to access dot value and that way the user ID will be populated.
            shoppingCart.ApplicationUserId = userId;

            // we must do that because we donot need to duplicate product when we add  a new item and if user has already have a product on shoppingcart
            // get shopping cart from database and make sure the userid == ApplicationUserId and produc id == productid
            ShopingCart cartFromDb = _shoppingCartService.Get(u => u.ApplicationUserId == userId &&
           u.ProductId == shoppingCart.ProductId);
            if (cartFromDb != null)
            {
                //shopping cart exists
                cartFromDb.Count += shoppingCart.Count;
                _shoppingCartService.Update(cartFromDb);
            
            }
            else
            {
                //add cart record
                _shoppingCartService.add(shoppingCart);
                

                HttpContext.Session.SetInt32(SD.SessionCart,    // how to makr shoppingcart icon to count
                     _shoppingCartService.GetAll(u => u.ApplicationUserId == userId).Count());

            }

            TempData["success"] = "Cart updated successfully";

            return RedirectToAction(nameof(Index));
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}