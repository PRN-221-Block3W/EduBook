using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject
{
    public partial class Department
    {
        public Department()
        {
            Rooms = new HashSet<Room>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
        public string? Telephone { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
