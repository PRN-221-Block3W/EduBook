using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using EduBook.BusinessObject;
using EduBook.Service.IService;
using EduBook.Repository.ClassRepository;

namespace EduBook.Presentation.Pages.Customer
{
    public class SearchRoomModel : PageModel
    {
        private readonly IManufactureService manufactureService;
        private readonly IRoomService roomService;
        private readonly IAccountService accountService;

        public SearchRoomModel(IManufactureService manufactureService, IRoomService roomService, IAccountService accountService)
        {
            this.manufactureService = manufactureService;
            this.roomService = roomService;
            this.accountService = accountService;
            customer = new Account();

        }

        public IList<Room>? ListRoom { get; set; }

        public String RoomName {  get; set; }
        public Account customer { get; set; }

        public async Task<IActionResult> OnGet(string roomName)
        {
            int? accountId = HttpContext.Session.GetInt32("AccountId");
            if (accountId != null)
            {
                customer = accountService.GetById((int)accountId);
            }
            ListRoom = roomService.GetList().Where(p => p.RoomName.Contains(roomName)).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            HttpContext.Session.Remove("AccountId");
            return RedirectToPage("/Customer/HomePage");
        }
    }
}
