﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;

namespace EduBook.Service.IService
{
    public interface ICommentService
    {
        public bool Create(Comment cmt);
        public List<Comment> GetList();
        public Comment GetById(int id);
        public bool Update(Comment cmt);
        public bool Remove(Comment cmt);
    }
}
