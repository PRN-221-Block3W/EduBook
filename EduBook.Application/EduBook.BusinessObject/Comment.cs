using System;
using System.Collections.Generic;

namespace EduBook.BusinessObject
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int AccountId { get; set; }
        public string Context { get; set; } = null!;
        public bool Status { get; set; }
        public int RoomId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
    }
}
