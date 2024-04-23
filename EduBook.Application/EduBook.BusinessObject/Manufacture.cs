using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject
{
    public partial class Manufacture
    {
        public Manufacture()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int ManufactureId { get; set; }
        public string ManufactureName { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
