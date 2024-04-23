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
    public class DepartmentRepository : IDepartmentRepository
    {
		public bool Create(Department dep) => DepartmentDAO.Instance.Create(dep);

		public Department GetById(int id) => DepartmentDAO.Instance.GetById(id);

		public List<Department> GetList() => DepartmentDAO.Instance.GetList();

		public bool Remove(Department dep) => DepartmentDAO.Instance.Remove(dep);

		public bool Update(Department dep) => DepartmentDAO.Instance.Update(dep);
	}
}
