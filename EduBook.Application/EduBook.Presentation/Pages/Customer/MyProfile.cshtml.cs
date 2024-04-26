using EduBook.BusinessObject;
using EduBook.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EduBook.Presentation.Pages.Customer
{
    public class MyProfileModel : PageModel
    {
        private readonly IAccountRepository accountRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public MyProfileModel(IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.accountRepository = accountRepository;
            this.httpContextAccessor = httpContextAccessor;
            Account = new Account();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;
        [BindProperty]
        public string ConfirmPassword { get; set; }

        public IActionResult OnGetAsync(int? id)
        {
            Account = accountRepository.GetById((int)id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return Page();
            }

            if (Account.Password != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Password and confirmation do not match.");
                return Page();
            }

            var accountToUpdate = accountRepository.GetById((int)id);
            if (accountToUpdate == null)
            {
                return Page();
            }

            // Cập nhật thông tin tài khoản
            //accountToUpdate.AccountId = Account.AccountId;
            accountToUpdate.Password = Account.Password;
            accountToUpdate.UserName = Account.UserName;
            accountToUpdate.Email = Account.Email;
            accountToUpdate.Phone = Account.Phone;
            accountToUpdate.Email = Account.Email;
            accountToUpdate.Dob = Account.Dob;
            accountToUpdate.Status = true;

            accountRepository.Update(accountToUpdate);

            return Redirect("/Customer/CustomerHomePage");
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            httpContextAccessor.HttpContext.Session.Remove("AccountId");
            return Redirect("/Customer/CustomerHomePage");
        }
    }
}
