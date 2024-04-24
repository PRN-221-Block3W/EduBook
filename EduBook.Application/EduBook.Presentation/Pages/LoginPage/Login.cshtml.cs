using EduBook.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EduBook.Presentation.Pages.LoginPage
{
	public class LoginModel : PageModel
	{
		[BindProperty]
		[EmailAddress]
		[Required]
		public string Email { get; set; }
		[BindProperty]
		[Required]
		public string Password { get; set; }
		private readonly IAccountService accountService;
		//private readonly IRoleService roleRepository;
		public LoginModel(IAccountService accountService)
		{
			this.accountService = accountService;
		}

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			var account = accountService.Login(Email, Password);
			if (account != null)
			{
				HttpContext.Session.SetString("Email", Email);
				HttpContext.Session.SetInt32("role", account.RoleId);
				HttpContext.Session.SetInt32("AccountId", account.AccountId);
			}
			var role = accountService.GetRoles().FirstOrDefault(p => p.RoleId == account.RoleId);
			if (role.RoleName.ToLower().Equals("customer"))
			{
				return Redirect("/Customer/CustomerHomePage");
			}
			if (role.RoleName.ToLower().Equals("admin"))
			{
				return Redirect("/Admin/Dashboard");
			}
			return Page();
		}
	}
}