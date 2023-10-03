using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class BabyController : Controller
    {
        private readonly IProductService _productService;

        public BabyController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int id)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }


        public IActionResult BabyNightwear(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult BabyTshirt(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult Babyshirt(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }
        public IActionResult BabyJeans(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);

        }

    }
}
