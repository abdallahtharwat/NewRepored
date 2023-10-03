using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class MenController : Controller
    {
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;

        public MenController( IProductService productService, IShoppingCartService shoppingCartService)
        {
      
            _productService = productService;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index( int id )
        {
            IEnumerable<Product> Productlist = _productService.GetAll( u => u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult MenTrousers(int id , int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll( u => u.Category.Id == categorryid  &  u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult MenTshirt(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult Menshirt(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult MenBlazer(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult MenJeans(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }



    }
}
