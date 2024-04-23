using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduBook.BusinessObject;
using EduBook.Service.IService;
using EduBook.Service.ClassService;

namespace EduBook.Presentation.Pages.BookingDetails
{
    public class EditBookingDetail : PageModel
    {
        private readonly IBookingDetailsService _bookingDetailsService;
        private readonly IAccountService _accountService;
        private readonly IBookingService _bookingService;

        public EditBookingDetail(IAccountService accountService,
                                    IBookingService bookingService,
                                    BookingDetailsService bookingDetailsService)
        {
            _bookingDetailsService = bookingDetailsService;
            _accountService = accountService;
            _bookingService = bookingService;
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
            BookingDetail = bookingdetail;
            ViewData["AccountId"] = new SelectList(_accountService.GetList(), "AccountId", "Email");
            ViewData["BookingId"] = new SelectList(_bookingService.GetList(), "BookingId", "BookingId");
            //ViewData["SlotId"] = new SelectList(_context.Slots, "SlotId", "SlotName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Check validdate
            _bookingDetailsService.Update(BookingDetail);

            return RedirectToPage("./Index");
        }
    }
}
