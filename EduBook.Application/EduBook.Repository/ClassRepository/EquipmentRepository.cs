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
    public class EquipmentRepository : IEquipmentRepository
    {
		public bool Create(Equipment eq) => EquipmentDAO.Instance.Create(eq);

		public Equipment GetById(int id) => EquipmentDAO.Instance.GetById(id);

		public List<Equipment> GetList() => EquipmentDAO.Instance.GetList();

		public bool Remove(Equipment eq) => EquipmentDAO.Instance.Remove(eq);

		public bool Update(Equipment eq) => EquipmentDAO.Instance.Update(eq);
	}
}
