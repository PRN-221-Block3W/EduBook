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
    public class RoomRepository : IRoomRepository
    {
		public bool Create(Room room) => RoomDAO.Instance.Create(room);

		public Room GetById(int id) => RoomDAO.Instance.GetById(id);

		public List<Room> GetList() => RoomDAO.Instance.GetList();

		public bool Remove(Room room) => RoomDAO.Instance.Remove(room);

		public bool Update(Room room) => RoomDAO.Instance.Update(room);
	}
}
