﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;

namespace EduBook.Service.IService
{
    public interface IRoomService
    {
        public bool Create(Room room);
        public List<Room> GetList();
        public Room GetById(int id);
        public bool Update(Room room);
        public bool Remove(Room room);
    }
}
