using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Application.ViewModel;
using CleanArch.Domain.Models;
using CleanArch.Domain.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IApplicationUserService  _applicationUserService;
      

        public UserController(IApplicationUserService  applicationUserService)
        {
            _applicationUserService = applicationUserService;
           
        }


        [HttpGet]
        public IActionResult get()
        {
            var get = _applicationUserService.GetAll(includeproperties: "Company");



            return Ok(get);
        }

        [HttpGet("{id:int}")]
        public IActionResult getbyid(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var get = _applicationUserService.Get(u => u.Id == id);

            if (get == null)
            {
                return NotFound();
            }

            return Ok(get);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ApplicationUser  applicationUser )
        {
            _applicationUserService.add(applicationUser);
           
            return Ok(applicationUser);
        }

        [HttpDelete("{id:int}")]
        public IActionResult deletebyid(string id)
        {
            var get = _applicationUserService.Get(u => u.Id == id);
            return Ok(get);
        }


    }
}