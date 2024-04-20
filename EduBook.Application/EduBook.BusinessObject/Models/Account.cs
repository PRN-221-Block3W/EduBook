using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject.Models
{
    public partial class Account
    {
        public Account()
        {
            Bookings = new HashSet<Booking>();
            Comments = new HashSet<Comment>();
            Ratings = new HashSet<Rating>();
        }

        public int AccountId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; } = null!;
        public int? DepartmentId { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Status { get; set; }

        public virtual Department? Department { get; set; }
        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
