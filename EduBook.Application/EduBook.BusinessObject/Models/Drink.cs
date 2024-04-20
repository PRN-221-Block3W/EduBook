using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject.Models
{
    public partial class Drink
    {
        public Drink()
        {
            BookingDetail1s = new HashSet<BookingDetail1>();
        }

        public int DrinkId { get; set; }
        public string DrinkName { get; set; } = null!;
        public string DinkInfo { get; set; } = null!;
        public int DepartmentId { get; set; }
        public string? ImageDrink { get; set; }
        public double DrinkPrice { get; set; }
        public bool Status { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<BookingDetail1> BookingDetail1s { get; set; }
    }
}
