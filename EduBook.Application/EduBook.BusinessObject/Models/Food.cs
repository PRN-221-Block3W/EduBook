using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject.Models
{
    public partial class Food
    {
        public Food()
        {
            BookingDetail1s = new HashSet<BookingDetail1>();
        }

        public int FoodId { get; set; }
        public int DepartmentId { get; set; }
        public string FoodName { get; set; } = null!;
        public string FoodInfo { get; set; } = null!;
        public double FoodPrice { get; set; }
        public string ImageFood { get; set; } = null!;
        public bool Status { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<BookingDetail1> BookingDetail1s { get; set; }
    }
}
