using System;
using System.Collections.Generic;

namespace SRMAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Comments = new HashSet<Comments>();
            RequestAssignedEmp = new HashSet<Request>();
            RequestCreatedEmp = new HashSet<Request>();
        }

        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? DepartmentId { get; set; }
        public bool Active { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }

        public Department Department { get; set; }
        public Role Role { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Request> RequestAssignedEmp { get; set; }
        public ICollection<Request> RequestCreatedEmp { get; set; }
    }
}
