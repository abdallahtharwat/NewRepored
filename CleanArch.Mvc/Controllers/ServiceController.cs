using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.Models;
using CleanArch.Mvc.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            
            _serviceService = serviceService;
        }
        public IActionResult Index()
        {
            List<service> objcategorylist = _serviceService.GetAll().ToList();
            return View(objcategorylist);
        }


        [Authorize(Roles = SD.Role_Admin)]
        // get create
        public IActionResult Create()
        {

            return View();
        }

        // post create
        [HttpPost]
        public async Task<IActionResult> Create(service obj)  //  (obj== anta btstlm el value el fe post method input fe el create view )  when we have the obj here that will have the value of category that needs to be add
        {



            //Validation for sliver side
            if (ModelState.IsValid)
            {
              await   _serviceService.add(obj);
             
                TempData["success"] = "  Create successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = SD.Role_Admin)]
        // get Edit
        public IActionResult Edit(int? id)
        {

            // how to create edit btton
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Category? categoryfromDb = _db.Categories.Get(u => u.Id == id);
            service categoryfromDb = _serviceService.Get(u => u.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }

            return View(categoryfromDb);
        }

        // post Edit
        [HttpPost]
        public async Task<IActionResult> Edit(service obj)
        {

            //Validation for sliver side
            if (ModelState.IsValid)
            {
              await   _serviceService.Update(obj);
               
                TempData["success"] = "  Update successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = SD.Role_Admin)]
        // get Delete
        public IActionResult Delete(int? id)
        {

            // how to create edit btton
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //  Category? categoryfromDb = _UnitofWork.Category.Get(u => u.Id == id);
            service categoryfromDb = _serviceService.Get(u => u.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }

            return View(categoryfromDb);
        }

        // post Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Deletepost(int? id)
        {

            service obj = _serviceService.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
           await _serviceService.Remove(obj.Id);
          
            TempData["success"] = "  Delete successfully";
            return RedirectToAction("Index");


        }












    }
}
