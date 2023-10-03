using CleanArch.Application.Interfaces;
using CleanArch.Mvc.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanArch.Mvc.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IShoppingCartService  _shoppingCartService;
        public ShoppingCartViewComponent(IShoppingCartService  shoppingCartService)
        {

            _shoppingCartService = shoppingCartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {

                if (HttpContext.Session.GetInt32(SD.SessionCart) == null)
                {
                    HttpContext.Session.SetInt32(SD.SessionCart,
                    _shoppingCartService.GetAll(u => u.ApplicationUserId == claim.Value).Count());
                }

                return View(HttpContext.Session.GetInt32(SD.SessionCart));
            }
            else
            {
                HttpContext.Session.Clear();
                return View(0);
            }

        }
    }
}
