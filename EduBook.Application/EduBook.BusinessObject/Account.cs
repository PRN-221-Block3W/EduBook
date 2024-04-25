using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Invalid input")]
        public string? UserName { get; set; }

        public string? Phone { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Invalid input")]
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Status { get; set; }
        public string? ImageAccount { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
