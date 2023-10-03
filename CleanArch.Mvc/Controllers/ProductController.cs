using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModel;
using CleanArch.Domain.Models;
using CleanArch.Domain.ViewModel;
using CleanArch.Mvc.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.Mvc.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private IProductService  _productService;
        private readonly ICategoryService _categoryService;
        private readonly ItypeService  _itypeService;
        private readonly IProductImageService  _productImageService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ProductController(IProductService  productService , IWebHostEnvironment webHostEnvironment, ICategoryService categoryService, IProductImageService productImageService, ItypeService itypeService )
        {
            _productService = productService;
            _WebHostEnvironment = webHostEnvironment;
            _categoryService = categoryService;
            _productImageService = productImageService;
            _itypeService = itypeService;
        }

        public IActionResult Index()
        {
            List<Product> objproductlist = _productService.GetAll(includeproperties: "Category,type").ToList();

            return View(objproductlist);
        }

        [Authorize(Roles = SD.Role_Admin)]
        // get create
        public IActionResult Upsert(int? id)
        {
            // when you want to  pass data from controller to view page || we must retrive from database first and send it to view                                                                
            ProductVM productVM = new()
            {
                CategoryList = _categoryService.GetAll().Select(u => new SelectListItem  // (step 3 for forienkey category)  انت بتحيبها من قاعد البيانات و بتبعتها لل فيو    
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),

                typeList = _itypeService.GetAll().Select(u => new SelectListItem  // (step 3 for forienkey category)  انت بتحيبها من قاعد البيانات و بتبعتها لل فيو    
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),


                Product = new Product()
            };

            if (id == null || id == 0)
            {
                // if id is zero its create
                return View(productVM);
            }
            else
            {
                // the id is present (its update)
                productVM.Product = _productService.Get(u => u.Id == id, includeproperties: "productImages");
                return View(productVM);
            }

        }




        // post create
        [HttpPost]
        public async Task< IActionResult> Upsert(ProductVM productVM, List<IFormFile> files)  //  (obj== anta btstlm el value el fe post method input fe el create view )  when we have the obj here that will have the value of category that needs to be add
        {
            //Validation for sliver side
            if (ModelState.IsValid)
            {
                string wwwRootPath = _WebHostEnvironment.WebRootPath;
                if (productVM.Product.Id == 0)
                {
                 await   _productService.add(productVM.Product, files, wwwRootPath);
                  
                    TempData["success"] = "  Created successfully";
                }
                else
                {
                    await _productService.Update(productVM.Product, files, wwwRootPath);
                    TempData["success"] = "  update successfully";
                }

                //string wwwRootPath = _WebHostEnvironment.WebRootPath;  // access to wwwroot folder
                //if (files != null)
                //{
                //    // we can iterate through each file that were uploaded 
                //    foreach (IFormFile file in files)
                //    {
                //        // unique name for image
                //        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                //        string productPath = @"images\products\product-" + productVM.Product.Id; // we need to add the productID
                //        string finalPath = Path.Combine(wwwRootPath, productPath); // the location where to have save images

                //        // we will have to create this particular product folder in linen(95) if that does not exist
                //        if (!Directory.Exists(finalPath))  // if final path is not exists
                //            Directory.CreateDirectory(finalPath); // will create that particular  ||  to upload all the files 

                //        // change piets to file and  (( Save the photo))
                //        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))  // where to have save the file
                //        {
                //            file.CopyTo(fileStream);      // that will copy the file in the new location|| that we added  in line 76
                //        }

                //        ProductImage productImage = new()   //save
                //        {
                //            ImageUrl = @"\" + productPath + @"\" + fileName,
                //            ProductId = productVM.Product.Id,
                //        };

                //        // that way we will not get an exception if product image is null
                //        if (productVM.Product.productImages == null)
                //            productVM.Product.productImages = new List<ProductImage>();

                //        productVM.Product.productImages.Add(productImage);
                //    }

                //    _productService.Update(productVM.Product);
                //}
                  
                return RedirectToAction("Index");
            }
            return View();
        }





        public  async  Task<IActionResult >DeleteImage(int imageId)  // in the parameter here we will receive image ID based on (asp-route-image-id in view)
        {
            var imageToBeDeleted = _productImageService.Get(u => u.Id == imageId);  //  based on image ID we will retrieve the images that we have to delete
            int productId = imageToBeDeleted.ProductId; // we need product Id
            if (imageToBeDeleted != null)
            {
               if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_WebHostEnvironment.WebRootPath, imageToBeDeleted.ImageUrl.TrimStart('\\')); // we can retrieve the old image path and delete it  

                    if (System.IO.File.Exists(oldImagePath))
                  {
                        System.IO.File.Delete(oldImagePath);
                   }
               }

              await  _productImageService.Remove(imageToBeDeleted.Id);
                

                TempData["success"] = "Deleted successfully";
            }

            return RedirectToAction(nameof(Upsert), new { id = productId });
        }






        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objproductlist = _productService.GetAll(includeproperties: "Category,type").ToList();
            return Json(new { data = objproductlist });
        }

        [Authorize(Roles = SD.Role_Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {

            var producttobedelete =  _productService.Get(u => u.Id == id);
            
            if (producttobedelete == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            //// when we delete the product that will delete ( the folder image  it contain images) 
            string productPath = @"images\products\product-" + id;
            string finalPath = Path.Combine(_WebHostEnvironment.WebRootPath, productPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
            }


           await _productService.Remove(producttobedelete.Id);

            return Json(new { success = false, message = "Delete Successful" });
        }


        #endregion



    }
}
