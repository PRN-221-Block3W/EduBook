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
        private readonly IBookingService _bookingService;
       
        [BindProperty]
        public int TotalDepartmentCount { get; set; }
		
        [BindProperty]
		public int TotalRoomCount { get; set; }
        
        [BindProperty]
		public int TotalBookingCount { get; set; }
        
        public Account Account { get; set; }
        public IList<Booking> Booking { get; set; }

        public DashboardModel(IAccountService accountService,
                        IDepartmentService departmentService,
                        IRoomService roomService,
                        IAccountService accService,
                        IBookingService bookingService)
        {
            _accountService = accountService;
            _departmentService = departmentService;
            _roomService = roomService;
            _accService = accService;
            _bookingService = bookingService;
        }
        public IActionResult OnGet()
        {
            //Check session
            var authorizationResult = Authorized();
            if (authorizationResult != null)
            {
                return authorizationResult;
            }
            Booking = _bookingService.GetList();
            TotalBookingCount = Booking.Count; 
            TotalDepartmentCount = _departmentService.GetList().Count;
            TotalRoomCount = _roomService.GetList().Count;
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
