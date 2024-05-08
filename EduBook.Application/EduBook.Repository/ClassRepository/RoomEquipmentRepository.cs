using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using EduBook.DAO;
using EduBook.Repository.IRepository;

namespace EduBook.Repository.ClassRepository
{
    public class RoomEquipmentRepository : IRoomEquipmentRepository
    {
		public bool Create(RoomEquipment roomEq) => RoomEquipmentDAO.Instance.Create(roomEq);

		public RoomEquipment GetById(int id) => RoomEquipmentDAO.Instance.GetById(id);

		public List<RoomEquipment> GetList() => RoomEquipmentDAO.Instance.GetList();

        public IList<RoomEquipment> GetListRoomEquip(int roomId) => RoomEquipmentDAO.Instance.GetListRoomEquip(roomId);

        public bool Remove(RoomEquipment roomEq) => RoomEquipmentDAO.Instance.Remove(roomEq);

		public bool Update(RoomEquipment roomEq) => RoomEquipmentDAO.Instance.Equals(roomEq);

	}
}
