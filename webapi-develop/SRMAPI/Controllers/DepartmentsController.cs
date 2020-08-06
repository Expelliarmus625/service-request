using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMAPI.Data;
using SRMAPI.Models;

namespace SRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepo _repository;
        private readonly object departmentItems;

        public DepartmentsController(IDepartmentRepo repository)
        {
            _repository = repository;

        }

        // GET: api/Departments
        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetDepartment()
        {
            var departmentItems = _repository.GetDepartment();
            return Ok(departmentItems);
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartmentById(int Id)
        {
            var departmentItem = _repository.GetDepartmentById(Id);


            if (departmentItem != null)
            {

                return Ok(departmentItem);
            }
            return NotFound();

        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int Id, Department department)
        {
           

            var updateDepartmentFromRepo = _repository.GetDepartmentById(Id);
            if (updateDepartmentFromRepo == null)
            {
                return NotFound();
            }
            _repository.UpdateDepartment(updateDepartmentFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Department> CreateDepartment(Department createDepartment)
        {
          
            _repository.CreateDepartment(createDepartment);
            _repository.SaveChanges();
            return createDepartment;
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public ActionResult<Department> DeleteDepartment(int Id)
        {
            
            var departmentFromRepo = _repository.GetDepartmentById(Id);
            if (departmentFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteDepartment(departmentFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

     
    }
}
