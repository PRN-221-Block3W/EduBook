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

        public Account Account { get; set; }
        public IList<Room> Rooms { get; set; }

        public DashboardModel(IAccountService accountService,
                        IDepartmentService departmentService,
                        IRoomService roomService)
        {
            _accountService = accountService;
            _departmentService = departmentService;
            _roomService = roomService;
        }
        public void OnGet()
        {
            //Check session
            //Account = _accountService.GetById(0);
            Rooms = _roomService.GetList();


        }
    }
}
