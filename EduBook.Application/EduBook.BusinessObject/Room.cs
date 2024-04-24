using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject
{
    public partial class Room
    {
        public Room()
        {
            Comments = new HashSet<Comment>();
            RoomEquipments = new HashSet<RoomEquipment>();
            Slots = new HashSet<Slot>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double LengthRoom { get; set; }
        public double WidthRoom { get; set; }
        public bool Status { get; set; }
        public string? ImageRoom { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<RoomEquipment> RoomEquipments { get; set; }
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
