using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EduBook.BusinessObject;
using EduBook.Service.IService;
using EduBook.Service.ClassService;

namespace EduBook.Presentation.Pages.BookingDetails
{
    public class CreateBookingDetail : PageModel
    {
        private readonly IBookingDetailsService _bookingDetailsService;
        private readonly IAccountService _accountService;
        private readonly IBookingService _bookingService;

        public CreateBookingDetail(IAccountService accountService,
                                    IBookingService bookingService,
                                    BookingDetailsService bookingDetailsService)
        {
            _bookingDetailsService = bookingDetailsService;
            _accountService = accountService;
            _bookingService = bookingService;
        }

        public IActionResult OnGet()
        {
        ViewData["AccountId"] = new SelectList(_accountService.GetList(), "AccountId", "Email");
        ViewData["BookingId"] = new SelectList(_bookingService.GetList(), "BookingId", "BookingId");
        //ViewData["SlotId"] = new SelectList(_context.Slots, "SlotId", "SlotName");
            return Page();
        }

        [BindProperty]
        public BookingDetail BookingDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
          //Check validate
            _bookingDetailsService.Create(BookingDetail);

            return RedirectToPage("./Index");
        }
    }
}
