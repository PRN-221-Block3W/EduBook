using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduBook.BusinessObject;
using EduBook.Service.IService;

namespace EduBook.Presentation.Pages.Rooms
{
    public class DetailsRoomModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IRoomService _roomService;
        private readonly IRoomEquipmentService _roomEquipmentService;
        private readonly ICommentService _commentService;
        public DetailsRoomModel(IAccountService accountService, 
                                IRoomService roomService,
                                ICommentService commentService,
                                IRoomEquipmentService roomEquipmentService)
        {
            _commentService = commentService;
            _accountService = accountService;
            _roomService = roomService;
            _roomEquipmentService = roomEquipmentService;
        }
        public Account customer { get; set; }
        public int countCmt { get; set; }
        public Room Room { get; set; } = default!;
        [BindProperty]
        public Comment Commnent { get; set; }
        public IList<Comment> ListComment { get; set; }
        public IList<RoomEquipment> RoomEquipment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var room = _roomService.GetById((int)id);
            if (room == null)
            {
                return NotFound();
            }
            else
            {
                int? customerId = HttpContext.Session.GetInt32("AccountId");
                customer = _accountService.GetById((int)customerId);
                RoomEquipment = _roomEquipmentService.GetListRoomEquip((int)id);
                ListComment = _commentService.GetListOfRoom((int)id);
                countCmt = ListComment.Count;
                Room = room;
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            int? customerId = HttpContext.Session.GetInt32("AccountId");
            if(customerId == null)
            {
                return Redirect("/LoginPage/Login");
            }
            Commnent.AccountId = (int)customerId;
            Commnent.RoomId = (int)id;
            _commentService.Create(Commnent);
            return Redirect("/Rooms/DetailsRoom?id=" + id);
        }
    }
}
