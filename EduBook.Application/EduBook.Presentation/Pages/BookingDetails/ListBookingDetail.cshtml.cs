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
    public class ListBookingDetail : PageModel
    {
        private readonly IBookingDetailsService _bookingDetailsService;

        public ListBookingDetail(IBookingDetailsService bookingDetailsService)
        {
            _bookingDetailsService = bookingDetailsService;
        }

        public IList<BookingDetail> BookingDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BookingDetail = _bookingDetailsService.GetList();
        }
    }
}
