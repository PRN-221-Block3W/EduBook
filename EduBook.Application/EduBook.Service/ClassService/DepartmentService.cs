using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using EduBook.Service.IService;
using EduBook.Repository.IRepository;

namespace EduBook.Service.ClassService
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IDepartmentRepository _repo;

		public DepartmentService(IDepartmentRepository repo)
		{
			_repo = repo;
		}

		public bool Create(Department dep) => _repo.Create(dep);

		public Department GetById(int id) => _repo.GetById(id);

		public List<Department> GetList() => _repo.GetList();

		public bool Remove(Department dep) => _repo.Remove(dep);

		public bool Update(Department dep) => _repo.Update(dep);
	}
}
