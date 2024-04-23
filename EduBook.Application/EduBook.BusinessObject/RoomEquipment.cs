using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject
{
    public partial class RoomEquipment
    {
        public int RoomEquipmentId { get; set; }
        public int RoomId { get; set; }
        public int EquipmentId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; } = null!;
        public bool Status { get; set; }

        public virtual Equipment Equipment { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
    }
}
