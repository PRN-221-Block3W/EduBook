using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduBook.BusinessObject;
using EduBook.Service.ClassService;

namespace EduBook.Presentation.Pages.BookingDetails
{
    public class DeleteBookingDetail : PageModel
    {
        private readonly BookingDetailsService _bookingDetailsService;

        public DeleteBookingDetail(BookingDetailsService bookingDetailsService)
        {
            _bookingDetailsService = bookingDetailsService;
        }

        [BindProperty]
      public BookingDetail BookingDetail { get; set; } = default!;

        public IActionResult OnGet(int? id)
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

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bookingdetail = _bookingDetailsService.GetBookingDetailById((int)id);

            if (bookingdetail != null)
            {
                BookingDetail = bookingdetail;
                _bookingDetailsService.Delete(BookingDetail);
            }

            return RedirectToPage("./Index");
        }
    }
}
