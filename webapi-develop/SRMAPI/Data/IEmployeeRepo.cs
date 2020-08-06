using SRMAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRMAPI.Data
{
  public  interface IEmployeeRepo
    {
        bool SaveChanges();
        IEnumerable<Employee> GetEmployee();
        Employee GetEmployeeById(int Id);

       
        void UpdateEmployee(Employee employee);

       
    }
}
