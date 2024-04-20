using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject.Models
{
    public partial class Department
    {
        public Department()
        {
            Accounts = new HashSet<Account>();
            Drinks = new HashSet<Drink>();
            Foods = new HashSet<Food>();
            Rooms = new HashSet<Room>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string StartTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;
        public string ImageDepartment { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Drink> Drinks { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
