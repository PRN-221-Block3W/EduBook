using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduBook.BusinessObject;

namespace EduBook.Presentation.Pages.Admin
{
    public class BookingDetailsModel : PageModel
    {
        private readonly EduBook.BusinessObject.EduBookContext _context;

        public BookingDetailsModel()
        {
            _context = new EduBookContext();
        }

        public IList<BookingDetail> BookingDetail { get;set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            if (_context.BookingDetails != null || id != null)
            {
                BookingDetail = await _context.BookingDetails
                .Where(x => x.BookingId == id)
                .Include(b => b.Account)
                .Include(b => b.Booking)
                .Include(b => b.Slot)
                .Include(b => b.Slot.Room).
				ToListAsync();
            }
        }
    }
}
