using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EduBook.BusinessObject;
using EduBook.Service.IService;

namespace EduBook.Presentation.Pages.Registers
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountService _accountService;

        public RegisterModel(IAccountService accountService)
        {
			_accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;
        [BindProperty]
        public string CfPassword { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          var checkEmail = _accountService.GetByEmail(Account.Email);
            if (checkEmail != null)
            {
                ViewData["Message"] = "Email is already to used";
                return Page();
            }

            if(Account.Dob > DateTime.Now)
            {
				ViewData["Message"] = "Dob is not bigger now";
				return Page();
			}

            if(!Account.Password.Equals(CfPassword))
            {
                ViewData["Message"] = "Password is not match !";
                return Page();
            }
            _accountService.Create(Account);

            return RedirectToPage("/LoginPage/Login");
        }
    }
}
