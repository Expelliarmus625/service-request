using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using SRMAPI.Data;
using SRMAPI.Models;

namespace SRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepo _repository;
        private readonly object categoryItems;

        public CategoriesController(ICategoryRepo repository)
        {
            _repository = repository;

        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategory()
        {
            var categoryItems = _repository.GetCategory();
            return Ok(categoryItems);
        }

        // GET: api/Categories/5
        [HttpGet("{Id}")]
        public ActionResult<Category> GetCategoryById(int Id)
        {
           
            var categoryItem = _repository.GetCategoryById(Id);


            if (categoryItem != null)
            {

                return Ok(categoryItem);
            }
            return NotFound();

        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{Id}")]
           public IActionResult UpdateCategory(int Id, Category updateCategory)
            {
            var updateCategoryFromRepo = _repository.GetCategoryById(Id);
         if(updateCategoryFromRepo == null)
         {
             return NotFound();
         }
         _repository.UpdateCategory(updateCategoryFromRepo);
         _repository.SaveChanges();
         return NoContent();
 }




     // POST: api/Categories
     // To protect from overposting attacks, please enable the specific properties you want to bind to, for
     // more details see https://aka.ms/RazorPagesCRUD.
         [HttpPost]
          public ActionResult<Category> CreateCategory(Category createCategory)
          {
            _repository.CreateCategory(createCategory);
            _repository.SaveChanges();
            return createCategory;
        }

          // DELETE: api/Categories/5
          [HttpDelete("{id}")]
          public ActionResult<Category> DeleteCategory(int Id)
          {
           
            var categoryFromRepo = _repository.GetCategoryById(Id);
            if (categoryFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCategory(categoryFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }

        }
    }
