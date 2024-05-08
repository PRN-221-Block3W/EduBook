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

namespace EduBook.Presentation.Pages.Admin.Rooms
{
    public class EditModel : PageModel
    {
        private readonly IRoomService _roomService;
        private readonly IAccountService _accService;
        private readonly IDepartmentService _depService;
        public EditModel(IAccountService _accService, IRoomService _roomService, IDepartmentService depService)
        {
            this._roomService = _roomService;
            this._accService = _accService;
            _depService = depService;
        }

        [BindProperty]
        public Room Room { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var authorizationResult = Authorized();
            if (authorizationResult != null)
            {
                return authorizationResult;
            }
            if (id == null)
            {
                return NotFound();
            }

            var room = _roomService.GetById((int)id);
            if (room == null)
            {
                return NotFound();
            }
            Room = room;
            ViewData["DepartmentId"] = new SelectList(_depService.GetList(), "DepartmentId", "Address");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _roomService.Update(Room);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(Room.RoomId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RoomExists(int id)
        {
            var room = _roomService.GetById(id);
            return room != null;
        }


        private IActionResult Authorized()
        {
            var id = HttpContext.Session.GetInt32("AccountId");
            var role = _accService.GetById((int)id).RoleId;
            if (id == null || role != 1)
            {
                return RedirectToPage("/Error");
            }

            return null; // Return null if authorization succeeds
        }
    }
}
