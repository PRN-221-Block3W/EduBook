using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduBook.BusinessObject
{
    public partial class Department
    {
        public Department()
        {
            Rooms = new HashSet<Room>();
        }

        public int DepartmentId { get; set; }
        [StringLength(20, ErrorMessage ="Max is 20 char")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Invalid input")]
        public string DepartmentName { get; set; } = null!;
        [StringLength(50, ErrorMessage = "Max is 50 char")]
        public string Address { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
