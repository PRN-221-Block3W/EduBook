using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject
{
    public partial class Account
    {
        public Account()
        {
            BookingDetails = new HashSet<BookingDetail>();
            Comments = new HashSet<Comment>();
        }

        public int AccountId { get; set; }
        public int RoleId { get; set; }
        public string? UserName { get; set; }
        public int DepartmentId { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Status { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
