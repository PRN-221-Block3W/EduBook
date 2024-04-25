using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public int DepartmentId { get; set; }
        [Required(ErrorMessage ="Room name is required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Invalid input")]
        public string RoomName { get; set; } = null!;
        [StringLength(255)]
        public string Description { get; set; } = null!;
        [Range(1, double.MaxValue, ErrorMessage = "Length must > 0")]
        public double LengthRoom { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Width must > 0")]
        public double WidthRoom { get; set; }
        public bool Status { get; set; }
        public string? ImageRoom { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<RoomEquipment> RoomEquipments { get; set; }
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
