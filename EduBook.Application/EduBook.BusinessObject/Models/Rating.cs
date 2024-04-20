using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject.Models
{
    public partial class Rating
    {
        public int RateId { get; set; }
        public int RateNumber { get; set; }
        public int RoomId { get; set; }
        public int AccountId { get; set; }
        public bool Status { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
    }
}
