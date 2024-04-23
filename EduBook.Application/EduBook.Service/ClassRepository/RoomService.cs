using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using EduBook.Repository.IRepository;
using EduBook.Service.IService;

namespace EduBook.Service.ClassRepository
{
	public class RoomService : IRoomService
	{
		private readonly IRoomRepository _repo;

		public RoomService(IRoomRepository repo)
		{
			_repo = repo;
		}

		public bool Create(Room room) => _repo.Create(room);

		public Room GetById(int id) => _repo.GetById(id);

		public List<Room> GetList() => _repo.GetList();

		public bool Remove(Room room) => _repo.Remove(room);

		public bool Update(Room room) => _repo.Update(room);
	}
}
