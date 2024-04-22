using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public double Total { get; set; }
        public int AccountId { get; set; }
        public int SlotId { get; set; }
        public bool Status { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual BookingDetail Slot { get; set; } = null!;
    }
}
