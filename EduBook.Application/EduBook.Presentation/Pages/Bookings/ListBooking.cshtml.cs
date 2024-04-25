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
    public class ListBooking : PageModel
    {
        private readonly IBookingService _bookingService;

        public ListBooking(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public IActionResult OnGet()
        {
            Booking = _bookingService.GetList();

            return Page();
        }
    }
}
