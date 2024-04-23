using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject
{
    public partial class BookingDetail
    {
        public int BookingDetailId { get; set; }
        public int BookingId { get; set; }
        public int SlotId { get; set; }
        public int AccountId { get; set; }
        public bool Status { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Booking Booking { get; set; } = null!;
        public virtual Slot Slot { get; set; } = null!;
    }
}
