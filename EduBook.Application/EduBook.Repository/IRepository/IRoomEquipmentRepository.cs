using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;

namespace EduBook.Repository.IRepository
{
    public interface IRoomEquipmentRepository
    {
        public bool Create(RoomEquipment roomEq);
        public List<RoomEquipment> GetList();
        public RoomEquipment GetById(int id);
        public bool Update(RoomEquipment roomEq);
        public bool Remove(RoomEquipment roomEq);
        IList<RoomEquipment> GetListRoomEquip(int roomId);
    }
}
