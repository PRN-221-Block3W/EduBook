using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduBook.BusinessObject;
using EduBook.Service.IService;
using EduBook.Service.ClassService;

namespace EduBook.Presentation.Pages.Admin
{
    public class BookingDetailsModel : PageModel
    {
        private readonly IBookingDetailsService _service;

		public BookingDetailsModel(IBookingDetailsService service)
		{
			_service = service;
		}

        public IList<BookingDetail> BookingDetail { get;set; } = default!;

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null)
            {
				return NotFound();
            }
			BookingDetail = _service.GetListByBookingId((int)id);
            return Page();
        }
    }
}
