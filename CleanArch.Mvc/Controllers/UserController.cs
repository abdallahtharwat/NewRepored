using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.Models;
using CleanArch.Domain.ViewModel;
using CleanArch.Mvc.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.Mvc.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]    // authorize for route 
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IApplicationUserService _applicationUserService;
        private readonly ICompanyService  _companyService;
    
        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IApplicationUserService applicationUserService, ICompanyService companyService)
        {
            _applicationUserService = applicationUserService;
            _roleManager = roleManager;
            _userManager = userManager;
            _companyService = companyService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult RoleManagment(string userId)
        {

            //   string RoleId = _db.UserRoles.FirstOrDefault(u => u.UserId == userId).RoleId; // retrieve the role id 

            RoleManagmentVM RoleVM = new RoleManagmentVM()
            {
                ApplicationUser = _applicationUserService.Get(u => u.Id == userId, includeproperties: "Company"),

                RoleList = _roleManager.Roles.Select(i => new SelectListItem   // Populate the dropdown for row list
                {
                    Text = i.Name,
                    Value = i.Name
                }),
                CompanyList = _companyService.GetAll().Select(i => new SelectListItem // Populate the dropdown for row list
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            RoleVM.ApplicationUser.Role = _userManager.GetRolesAsync(_applicationUserService.Get(u => u.Id == userId))
                    .GetAwaiter().GetResult().FirstOrDefault();  // that will retrieve role of the logged in user -- that will give us a roll of the user id 
            return View(RoleVM);
        }



        [HttpPost]
        public IActionResult RoleManagment(RoleManagmentVM roleManagmentVM)
        {
            // that way we will retrieve old rule of the user
            string oldRole = _userManager.GetRolesAsync(_applicationUserService.Get(u => u.Id == roleManagmentVM.ApplicationUser.Id))
                     .GetAwaiter().GetResult().FirstOrDefault();

            // retrieve the appliaction user
            ApplicationUser applicationUser = _applicationUserService.Get(u => u.Id == roleManagmentVM.ApplicationUser.Id);


            if (!(roleManagmentVM.ApplicationUser.Role == oldRole))
            {
                //a role was updated
                //  ApplicationUser applicationUser = _db.ApplicationUsers.FirstOrDefault(u => u.Id == roleManagmentVM.ApplicationUser.Id);
                if (roleManagmentVM.ApplicationUser.Role == SD.Role_Company)
                {
                    applicationUser.CompanyId = roleManagmentVM.ApplicationUser.CompanyId;
                }
                if (oldRole == SD.Role_Company)
                {
                    applicationUser.CompanyId = null;  //remove
                }

                _applicationUserService.Update(applicationUser);
                //_unitOfWork.Save();

                _userManager.RemoveFromRoleAsync(applicationUser, oldRole).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(applicationUser, roleManagmentVM.ApplicationUser.Role).GetAwaiter().GetResult();

            }
            else
            {
                if (oldRole == SD.Role_Company && applicationUser.CompanyId != roleManagmentVM.ApplicationUser.CompanyId)
                {
                    applicationUser.CompanyId = roleManagmentVM.ApplicationUser.CompanyId;
                    _applicationUserService.Update(applicationUser);
                    //_unitOfWork.Save();
                }
            }

            return RedirectToAction("Index");
        }







        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserlist = _applicationUserService.GetAll(includeproperties: "Company").ToList();

            foreach (var user in objUserlist)
            {

                user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();

                if (user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
            }



            return Json(new { data = objUserlist });
        }


        [Authorize(Roles = SD.Role_Admin)]
        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {

            var objFromDb = _applicationUserService.Get(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }


            objFromDb.LockoutEnabled = !objFromDb.LockoutEnabled;

            if (!objFromDb.LockoutEnabled)
            {
                //user is currently locked and we need to unlock them
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                // if the user is alrady unlocked we want to lock them
                objFromDb.LockoutEnd = DateTime.Now.AddYears(10);
            }

            _applicationUserService.Update(objFromDb);
            //_unitOfWork.Save();
            return Json(new { success = true, message = "Operation Successful" });
        }

        #endregion
    }
}
