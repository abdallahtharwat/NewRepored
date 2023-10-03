using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Application.ViewModel;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class typeController : ControllerBase
    {
        private readonly ItypeService  _itypeService;

        public typeController(ItypeService  itypeService)
        {
            _itypeService = itypeService;
        }


        [HttpGet]
        public IActionResult get()
        {
            var get = _itypeService.GetAll();
            return Ok(get);
        }

        [HttpGet("{id:int}")]
        public IActionResult getbyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var get = _itypeService.Get(u => u.Id == id);

            if (get == null)
            {
                return NotFound();
            }

            return Ok(get);
        }

        [HttpPost]
        public IActionResult Post([FromBody] type   type)
        {
            _itypeService.add(type);
           
            return Ok(type);
        }


        [HttpDelete("{id:int}")]
        public IActionResult deletebyid(int id)
        {
            var get = _itypeService.Get(u => u.Id == id);
            return Ok(get);
        }


    }
}