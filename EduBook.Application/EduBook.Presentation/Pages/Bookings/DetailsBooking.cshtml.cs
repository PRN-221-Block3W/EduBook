using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduBook.BusinessObject;
using EduBook.Service.IService;

namespace EduBook.Presentation.Pages.Bookings
{
    public class DetailsBooking : PageModel
    {
        private readonly IBookingService _bookingService;

        public DetailsBooking(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public Booking Booking { get; set; } = default!; 

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = _bookingService.GetById((int)id);
            if (booking == null)
            {
                return NotFound();
            }
            else 
            {
                Booking = booking;
            }
            return Page();
        }
    }
}
