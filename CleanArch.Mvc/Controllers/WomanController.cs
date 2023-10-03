using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class WomanController : Controller
    {
        private readonly IProductService _productService;


        public WomanController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int id)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }


        public IActionResult WomanTrousers(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult WomanTshirt(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult Womanshirt(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult WomanBlazer(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);
        }

        public IActionResult WomanJeans(int id, int categorryid)
        {
            IEnumerable<Product> Productlist = _productService.GetAll(u => u.Category.Id == categorryid & u.type.Id == id, includeproperties: "Category,type,productImages");
            return View(Productlist);



        }
    }
}
