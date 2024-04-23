using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduBook.BusinessObject;
using EduBook.Service.IService;

namespace EduBook.Presentation.Pages.BookingDetails
{
    public class DetailsBookingDetail : PageModel
    {
        private readonly IBookingDetailsService _bookingDetailsService;

        public DetailsBookingDetail(IBookingDetailsService bookingDetailsService)
        {
            _bookingDetailsService = bookingDetailsService;
        }

      public BookingDetail BookingDetail { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingdetail = _bookingDetailsService.GetBookingDetailById((int)id);
            if (bookingdetail == null)
            {
                return NotFound();
            }
            else 
            {
                BookingDetail = bookingdetail;
            }
            return Page();
        }
    }
}
