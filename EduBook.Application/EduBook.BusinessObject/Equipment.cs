using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject
{
    public partial class Equipment
    {
        public Equipment()
        {
            RoomEquipments = new HashSet<RoomEquipment>();
        }

        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int ManufactureId { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public bool Status { get; set; }

        public virtual Manufacture Manufacture { get; set; } = null!;
        public virtual ICollection<RoomEquipment> RoomEquipments { get; set; }
    }
}
