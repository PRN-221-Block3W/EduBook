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
	public class ManufactureService : IManufactureService
	{
		private readonly IManufactureRepository _repo;

		public ManufactureService(IManufactureRepository repo)
		{
			_repo = repo;
		}

		public bool Create(Manufacture manufacture) => _repo.Create(manufacture);

		public Manufacture GetById(int id) => _repo.GetById(id);

		public List<Manufacture> GetList() => _repo.GetList();

		public bool Remove(Manufacture manufacture) => _repo.Remove(manufacture);

		public bool Update(Manufacture manufacture) => _repo.Update(manufacture);
	}
}
