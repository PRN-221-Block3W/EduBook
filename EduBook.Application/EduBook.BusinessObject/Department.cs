﻿using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject
{
    public partial class Department
    {
        public Department()
        {
            Accounts = new HashSet<Account>();
            Rooms = new HashSet<Room>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ImageDepartment { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}