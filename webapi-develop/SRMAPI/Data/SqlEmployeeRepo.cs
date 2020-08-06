using Microsoft.EntityFrameworkCore;
using SRMAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRMAPI.Data
{
    public class SqlEmployeeRepo : IEmployeeRepo
    {
        private readonly SRMContext _context;
        public SqlEmployeeRepo(SRMContext context)
        {
            _context = context;
        }


        public IEnumerable<Employee> GetEmployee()
        {
            return _context.Employee.ToList();
        }

        public Employee GetEmployeeById(int Id)
        {
            var employee = _context.Employee.Include(dept => dept.Department).Where(emp => emp.Id == Id).FirstOrDefault();
            return employee;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateEmployee(Employee employee)
        {
            
        }
    }
}
