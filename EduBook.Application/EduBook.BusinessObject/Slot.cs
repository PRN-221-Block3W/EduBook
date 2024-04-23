using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject
{
    public partial class Slot
    {
        public Slot()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int SlotId { get; set; }
        public int RoomId { get; set; }
        public string SlotName { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }

        public virtual Room Room { get; set; } = null!;
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
