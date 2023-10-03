using Microsoft.AspNetCore.Mvc;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModel;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using CleanArch.Application.Services;
using CleanArch.Mvc.Utility;

namespace CleanArch.Mvc.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private ICompanyService  _CompanyService;
        public CompanyController(ICompanyService  companyService)
        {
            _CompanyService = companyService;
        }

        public IActionResult Index()
        {
            List<Company> objCompanylist = _CompanyService.GetAll().ToList();
            return View(objCompanylist);
        }


        [Authorize(Roles = SD.Role_Admin)]
        // get create
        public IActionResult Create()
        {

            return View();
        }

        // post create
        [HttpPost]
        public IActionResult Create(Company obj)  //  (obj== anta btstlm el value el fe post method input fe el create view )  when we have the obj here that will have the value of category that needs to be add
        {


            //Validation for sliver side
            if (ModelState.IsValid)
            {
                _CompanyService.add(obj);
            
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
        
            Company companyfromDb = _CompanyService.Get(u => u.Id == id);
            if (companyfromDb == null)
            {
                return NotFound();
            }

            return View(companyfromDb);
        }

        // post Edit
        [HttpPost]
        public IActionResult Edit(Company obj)
        {

            //Validation for sliver side
            if (ModelState.IsValid)
            {
                _CompanyService.Update(obj);
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
      
            Company companyfromDb = _CompanyService.Get(u => u.Id == id);
            if (companyfromDb == null)
            {
                return NotFound();
            }

            return View(companyfromDb);
        }

        // post Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(int? id)
        {
      
            Company obj = _CompanyService.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _CompanyService.Remove(obj);
            //_UnitofWork.Save();
            TempData["success"] = "  Delete successfully";
            return RedirectToAction("Index");


        }





    }
}
