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
	public class RoomEquipmentService : IRoomEquipmentService
	{
		private readonly IRoomEquipmentRepository _repo;

		public RoomEquipmentService(IRoomEquipmentRepository repo)
		{
			_repo = repo;
		}

		public bool Create(RoomEquipment roomEq) => _repo.Create(roomEq);

		public RoomEquipment GetById(int id) => _repo.GetById(id);

		public List<RoomEquipment> GetList() => _repo.GetList();

		public bool Remove(RoomEquipment roomEq) => _repo.Remove(roomEq);

		public bool Update(RoomEquipment roomEq) => _repo.Equals(roomEq);
	}
}
