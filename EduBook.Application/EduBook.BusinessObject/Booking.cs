using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public double Total { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
