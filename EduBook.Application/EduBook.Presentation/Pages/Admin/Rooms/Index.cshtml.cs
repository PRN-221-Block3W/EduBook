using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduBook.BusinessObject;
using EduBook.Service.IService;

namespace EduBook.Presentation.Pages.Admin.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly IRoomService _service;
        private readonly IAccountService _accService;
        public IndexModel(IRoomService service, IAccountService accService)
        {
            _service = service;
            _accService = accService;

        }

        public IList<Room> Room { get;set; } = default!;

        public IActionResult OnGetAsync()
        {
            var authorizationResult = Authorized();
            if (authorizationResult != null)
            {
                return authorizationResult;
            }
            Room = _service.GetList();
            return Page();
        }

        private IActionResult Authorized()
        {
            var id = HttpContext.Session.GetInt32("AccountId");
            if (id == null)
            {
                return RedirectToPage("/LoginPage/Login");
            }
            var role = _accService.GetById((int)id).RoleId;
            if (role != 1)
            {
                return RedirectToPage("/LoginPage/Login");
            }

            return null; // Return null if authorization succeeds
        }
    }
}
