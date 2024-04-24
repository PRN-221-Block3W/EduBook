using EduBook.BusinessObject;
using EduBook.Repository.IRepository;
using EduBook.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace EduBook.Presentation.Pages.Customer
{
    public class CustomerHomePageModel : PageModel
    {
		private readonly IDepartmentService departmentService;
		private readonly IAccountService accountService;
		private readonly IRoomService roomService;

		public CustomerHomePageModel(IDepartmentService departmentService, IAccountService accountService,IRoomService roomService)
		{
			this.departmentService = departmentService;
			this.accountService = accountService;
			this.roomService = roomService;
			customer = new Account();
		}

		public IList<Room> Room { get; set; } = default!;
		public string RoomName { get; set; }

		public Account customer { get; set; }


		public async Task<IActionResult> OnGetAsync()
		{
			int? accountId = HttpContext.Session.GetInt32("AccountId");
			customer = accountService.GetById(accountId);
			if (!string.IsNullOrEmpty(RoomName))
			{
				return RedirectToPage("/Customer/SearchShop", new { roomName = RoomName });
			}

			Room = roomService.GetList();
			return Page();
		}
		public async Task<IActionResult> OnPostLogoutAsync()
		{
			HttpContext.Session.Remove("AccountId");
			return Redirect("/Customer/HomePage");
		}
		
    }
}
