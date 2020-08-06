using System;
using System.Collections.Generic;

namespace SRMAPI.Models
{
    public partial class Department
    {
        public Department()
        {
            Category = new HashSet<Category>();
            Employee = new HashSet<Employee>();
            Request = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }

        public ICollection<Category> Category { get; set; }
        public ICollection<Employee> Employee { get; set; }
        public ICollection<Request> Request { get; set; }
    }
}
