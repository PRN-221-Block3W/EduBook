using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject.Models
{
    public partial class BookingDetail
    {
        public BookingDetail()
        {
            Bookings = new HashSet<Booking>();
        }

        public int SlotId { get; set; }
        public string StartTime { get; set; } = null!;
        public int RoomId { get; set; }
        public double Price { get; set; }
        public string EndTime { get; set; } = null!;

        public virtual Room Room { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
