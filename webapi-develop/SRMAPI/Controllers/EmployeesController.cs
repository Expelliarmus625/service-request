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
    public class EmployeesController : ControllerBase
    {
       
        private readonly IEmployeeRepo _repository;
        private readonly object employeeItems;

      
        public EmployeesController(IEmployeeRepo repository)
        {
            _repository = repository;

        }

        // GET: api/Employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployee()
        {
            var employeeItems = _repository.GetEmployee();
            return Ok(employeeItems);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int Id)
        {
            //   var employee = await _context.Employee.FindAsync(id);

            var employeeItem = _repository.GetEmployeeById(Id);


            if (employeeItem != null)
            {

                return Ok(employeeItem);
            }
            return NotFound();
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int Id, Employee employee)
        {
            var updateEmployeeFromRepo = _repository.GetEmployeeById(Id);
            if (updateEmployeeFromRepo == null)
            {
                return NotFound();
            }
            _repository.UpdateEmployee(updateEmployeeFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

       

      
    }
}
