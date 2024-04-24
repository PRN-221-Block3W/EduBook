using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduBook.BusinessObject;

namespace EduBook.Presentation.Pages.Admin.Customer
{
    public class IndexModel : PageModel
    {
        private readonly EduBook.BusinessObject.EduBookContext _context;

        public IndexModel()
        {
            _context = new EduBookContext();
        }

        public IList<Account> Account { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Accounts != null)
            {
                Account = await _context.Accounts
                .Include(a => a.Department)
                .Include(a => a.Role).ToListAsync();
            }
        }
    }
}
