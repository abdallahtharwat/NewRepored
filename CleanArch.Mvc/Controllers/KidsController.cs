using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class KidsController : Controller
    {
        private readonly IProductService _productService;

        public KidsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int id)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }


        public IActionResult KidsTrousers(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult KidsTshirt(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult Kidsshirt(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult KidsBlazer(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult KidsJeans(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);

        }


    }
}
