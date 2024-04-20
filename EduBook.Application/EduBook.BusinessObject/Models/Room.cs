using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject.Models
{
    public partial class Room
    {
        public Room()
        {
            BookingDetails = new HashSet<BookingDetail>();
            Comments = new HashSet<Comment>();
            Ratings = new HashSet<Rating>();
        }

        public int RoomId { get; set; }
        public int DepartmentId { get; set; }
        public string RoomName { get; set; } = null!;
        public bool Status { get; set; }
        public int? RoomNo { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
