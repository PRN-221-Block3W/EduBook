using EduBook.BusinessObject;
using EduBook.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EduBook.Presentation.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IDepartmentService _departmentService;
        private readonly IRoomService _roomService;
        private readonly IAccountService _accService;


        public Account Account { get; set; }
        public IList<Room> Rooms { get; set; }

        public DashboardModel(IAccountService accountService,
                        IDepartmentService departmentService,
                        IRoomService roomService,
                        IAccountService accService)
        {
            _accountService = accountService;
            _departmentService = departmentService;
            _roomService = roomService;
            _accService = accService;
        }
        public IActionResult OnGet()
        {
            //Check session
            var authorizationResult = Authorized();
            if (authorizationResult != null)
            {
                return authorizationResult;
            }
            //Account = _accountService.GetById(0);
            Rooms = _roomService.GetList();
            return Page();
        }

        private IActionResult Authorized()
        {
            var id = HttpContext.Session.GetInt32("AccountId");
            if (id == null)
            {
                return Redirect("/LoginPage/Login");
            }
            var role = _accService.GetById((int)id).RoleId;
            if (role != 1)
            {
                return Redirect("/LoginPage/Login");
            }
            return null;
        }
    }
}
