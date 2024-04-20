using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject.Models
{
    public partial class BookingDetail1
    {
        public int BookingDetailId { get; set; }
        public int BookingId { get; set; }
        public int? FoodId { get; set; }
        public int? DrinkId { get; set; }
        public int? NumberOfDrink { get; set; }
        public int? NumberOfFood { get; set; }
        public double? TotalPriceFood { get; set; }
        public double? TotalPriceDrink { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual Drink? Drink { get; set; }
        public virtual Food? Food { get; set; }
    }
}
