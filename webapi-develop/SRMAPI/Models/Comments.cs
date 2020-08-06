using System;
using System.Collections.Generic;

namespace SRMAPI.Models
{
    public partial class Comments
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int RequestId { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset LogTime { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }

        public Employee Employee { get; set; }
        public Request Request { get; set; }
    }
}
