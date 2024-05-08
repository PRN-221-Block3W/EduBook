using EduBook.BusinessObject;
using EduBook.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EduBook.Presentation.Pages.Customer
{
    public class BookingHistoryModel : PageModel
    {
        private readonly IAccountRepository bookingDetailRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IBookingRepository bookingRepository;

        public BookingHistoryModel(
            IAccountRepository accountRepository, IBookingRepository bookingRepository,
            IAccountRepository bookingDetailRepository)
        {
            this.bookingDetailRepository = bookingDetailRepository;
            this.accountRepository = accountRepository;
            this.bookingRepository = bookingRepository;
            customer = new Account();

        }
        public List<Booking> Booking { get; set; } = default!;
        public Account customer { get; set; }

        public IActionResult OnGetAsync()
        {
            int? accountId = HttpContext.Session.GetInt32("AccountId");
            if (accountId == null)
            {
                return RedirectToPage("/Error");
            }
            customer = accountRepository.GetById((int)accountId);
            Booking = bookingRepository.GetBookingsByAccount((int) accountId);
            return Page();
        }
        public IActionResult OnPostAsync(int? id)
        {
            var check = bookingRepository.GetById(id.Value);

            if (check == null)
            {
                return NotFound();
            }
            var booking = bookingRepository.GetById(id.Value);
            booking.Status = false;
            bookingRepository.Update(booking);
            return RedirectToPage("/Customer/BookingHistory");
        }
    }
}

