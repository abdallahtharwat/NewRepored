using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModel;
using CleanArch.Domain.Models;
using CleanArch.Mvc.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class typeController : Controller
    {
        private ItypeService  _itypeService;
        public typeController(ItypeService categoryService)
        {
            _itypeService = categoryService;
        }

        public IActionResult Index()
        {
            List<type> objtypelist = _itypeService.GetAll().ToList();
            return View(objtypelist);
        }


        [Authorize(Roles = SD.Role_Admin)]
        // get create
        public IActionResult Create()
        {

            return View();
        }

        // post create
        [HttpPost]
        public IActionResult Create(type obj)  //  (obj== anta btstlm el value el fe post method input fe el create view )  when we have the obj here that will have the value of category that needs to be add
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("DisplayOrder", "the Display order can not exactly match the name");
            }

            //Validation for sliver side
            if (ModelState.IsValid)
            {
                _itypeService.add(obj);
                //_categoryService.Save();
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
            //type? categoryfromDb = _db.Categories.Get(u => u.Id == id);
            type typefromDb = _itypeService.Get(u => u.Id == id); 
            if (typefromDb == null)
            {
                return NotFound();
            }

            return View(typefromDb);
        }

        // post Edit
        [HttpPost]
        public IActionResult Edit(type obj)
        {

            //Validation for sliver side
            if (ModelState.IsValid)
            {
                _itypeService.Update(obj);
                //_UnitofWork.Save();
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
            //  type? categoryfromDb = _UnitofWork.type.Get(u => u.Id == id);
            type categoryfromDb = _itypeService.Get(u => u.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }

            return View(categoryfromDb);
        }

        // post Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(int? id)
        {
            // type? obj = _db.type.Get(u => u.Id == id);
            type obj = _itypeService.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _itypeService.Remove(obj);
            //_UnitofWork.Save();
            TempData["success"] = "  Delete successfully";
            return RedirectToAction("Index");


        }



    }
}
