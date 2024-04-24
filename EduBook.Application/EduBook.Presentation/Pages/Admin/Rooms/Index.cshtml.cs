using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduBook.BusinessObject;

namespace EduBook.Presentation.Pages.Admin.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly EduBook.BusinessObject.EduBookContext _context;

        public IndexModel()
        {
            _context = new EduBookContext();
        }

        public IList<Room> Room { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rooms != null)
            {
                Room = await _context.Rooms
                .Include(r => r.Department).ToListAsync();
            }
        }
    }
}
