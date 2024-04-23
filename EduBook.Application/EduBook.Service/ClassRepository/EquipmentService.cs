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
	public class EquipmentService : IEquipmentService
	{
		private readonly IEquipmentRepository _repo;

		public EquipmentService(IEquipmentRepository repo)
		{
			_repo = repo;
		}

		public bool Create(Equipment eq) => _repo.Create(eq);

		public Equipment GetById(int id) => _repo.GetById(id);

		public List<Equipment> GetList() => _repo.GetList();

		public bool Remove(Equipment eq) => _repo.Remove(eq);

		public bool Update(Equipment eq) => _repo.Update(eq);
	}
}
