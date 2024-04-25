using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EduBook.BusinessObject;
using EduBook.Service.IService;

namespace EduBook.Presentation.Pages.Admin.Rooms
{
    public class CreateModel : PageModel
    {
        private readonly IRoomService _roomService;
        private readonly IAccountService _accService;
        private readonly IDepartmentService _depService;

        public CreateModel(IAccountService accService, IRoomService _roomService, IDepartmentService depService)
        {
            this._roomService = _roomService;
            _accService = accService;
            _depService = depService;
        }

        public IActionResult OnGet()
        {
            var authorizationResult = Authorized();
            if (authorizationResult != null)
            {
                return authorizationResult;
            }
            ViewData["DepartmentId"] = new SelectList(_depService.GetList(), "DepartmentId", "Address");
            return Page();
        }

        [BindProperty]
        public Room Room { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Room == null)
            {
                return Page();
            }

            _roomService.Create(Room);

            return RedirectToPage("./Index");
        }

        private IActionResult Authorized()
        {
            var id = HttpContext.Session.GetInt32("AccountId");
            var role = _accService.GetById((int)id).RoleId;
            if (id == null || role != 1 || role == null)
            {
                return RedirectToPage("/Error");
            }

            return null; // Return null if authorization succeeds
        }
    }
}
