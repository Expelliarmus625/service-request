using SRMAPI.Models;

namespace SRMAPI.DTOs
{
    public class RequestReadDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int RequestTypeId { get; set; }

        public int DepartmentId { get; set; }
        public int? StatusId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

        public Category Category { get; set; }
        public Employee CreatedEmp { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }
        public Category SubCategory { get; set; }
    }
}