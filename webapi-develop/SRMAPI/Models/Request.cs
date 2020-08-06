using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRMAPI.Models
{
    public partial class Request
    {
        public Request()
        {
            Comments = new HashSet<Comments>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int RequestTypeId { get; set; }

         [ForeignKey("Request")]
        public int DepartmentId { get; set; }
        public int CreatedEmpId { get; set; }
        public int AssignedEmpId { get; set; }
        public int? StatusId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }

        public Employee AssignedEmp { get; set; }
        public Category Category { get; set; }
        public Employee CreatedEmp { get; set; }
        public Department Department { get; set; }
        public RequestType RequestType { get; set; }
        public Status Status { get; set; }
        public Category SubCategory { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
