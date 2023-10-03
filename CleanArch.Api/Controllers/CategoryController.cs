using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModel;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService  categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
       
        public IActionResult get()
        {
            var get = _categoryService.GetAll();
            return Ok(get);
        }

        [HttpGet]
        public IActionResult getbyid(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var get = _categoryService.Get(u=>u.Id == id);

            if (get == null)
            {
                return NotFound();
            }

            return Ok(get);
        }

        [HttpPost]

        public  IActionResult Post([FromBody] Category  category)
        {
            //if (!ModelState.IsValid)
            //{
            //    return NotFound(ModelState);
            //}

            if(_categoryService.Get(u => u.Name.ToLower() == category.Name.ToLower())!= null)
            {
                ModelState.AddModelError("", "This name is already Exists!");
                    return BadRequest(ModelState);
            }
         

            if (category == null)
            {
                return BadRequest(category);
            }

            if(category.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

             _categoryService.add(category);
           
            return Ok(category);
        }

        [HttpDelete]

        public IActionResult deletebyid(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            var get = _categoryService.Get(u => u.Id == id);

            if (get == null)
            {
                return NotFound(id);
            }

            _categoryService.Remove(get);

            return NoContent();
        }
        [HttpPut]
        public IActionResult updatecategory(int id, [FromBody] Category category)
        {
            if (category == null || id != category.Id)
            {
                return NotFound();
            }

            var get = _categoryService.Get(u => u.Id == id);

            if (get == null)
            {
                return NotFound(id);
            }

            get.DisplayOrder = category.DisplayOrder;
            get.Name = category.Name;
            _categoryService.Update(get);
          

         

            return Ok();
        }
        




    }
}