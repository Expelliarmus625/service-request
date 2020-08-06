using SRMAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRMAPI.Data
{
   public interface IDepartmentRepo
    {
        bool SaveChanges();
        IEnumerable<Department> GetDepartment();
        Department GetDepartmentById(int Id);

        void CreateDepartment(Department department);

        void UpdateDepartment(Department department);

        void DeleteDepartment(Department department);
    }
}
