using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace EduBook.DAO
{
	public class DepartmentDAO
	{
		private readonly EduBookContext _context = null;
		private static DepartmentDAO _instance = null;
		public static DepartmentDAO Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DepartmentDAO();
				}
				return _instance;
			}
		}

		public DepartmentDAO()
		{
			_context = new EduBookContext();
		}

		public bool Create(Department department)
		{
			var list = GetList().OrderByDescending(x => x.DepartmentId).ToList();

			department.Status = true;
			department.DepartmentId = list[0].DepartmentId + 1;
			_context.Departments.Add(department);
			return _context.SaveChanges() > 0;
		}
		public List<Department> GetList()
		{
			return _context.Departments
				.Where(x => x.Status == true)
				.ToList();
		}

		public Department GetById(int id)
		{
			return _context.Departments
				.Where(x => x.Status == true)
					.FirstOrDefault(x => x.DepartmentId == id);
		}

		public bool Update(Department department)
		{
			var existingDepartment = _context.Departments.Find(department.DepartmentId);
			if (existingDepartment != null)
			{
				// Update the properties of the existing tracked entity
				_context.Entry(existingDepartment).CurrentValues.SetValues(department);
			}
			else
			{
				// If the entity is not tracked, attach it
				_context.Departments.Attach(department);
				// Change the entity state to Modified so that EF Core knows it should be updated
				_context.Entry(department).State = EntityState.Modified;
			}
			return _context.SaveChanges() > 0;
		}

		public bool Remove(Department department)
		{
			department.Status = false;
			_context.Departments.Update(department);
			return _context.SaveChanges() > 0;
		}
	}
}
