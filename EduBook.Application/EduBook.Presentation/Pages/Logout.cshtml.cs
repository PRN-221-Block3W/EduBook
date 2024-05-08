using System.Security.Principal;
using EduBook.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EduBook.Presentation.Pages
{
	public class LogoutModel : PageModel
	{
		public IActionResult OnGet()
		{

			var email = HttpContext.Session.GetString("Email");
			var roleId = HttpContext.Session.GetInt32("role");
			var accId = HttpContext.Session.GetInt32("AccountId");
			if (!string.IsNullOrEmpty(email))
			{
				HttpContext.Session.Remove("Email");
			}
			if (roleId != null)
			{
				HttpContext.Session.Remove("role");
			}
			if (accId != null)
			{
				HttpContext.Session.Remove("AccountId");
			}
			return Redirect("/LoginPage/Login");
		}
	}
}
