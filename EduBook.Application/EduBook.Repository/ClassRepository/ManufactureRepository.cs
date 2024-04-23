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
    public class ManufactureRepository : IManufactureRepository
    {
		public bool Create(Manufacture manufacture) => ManufactureDAO.Instance.Create(manufacture);

		public Manufacture GetById(int id) => ManufactureDAO.Instance.GetById(id);

		public List<Manufacture> GetList() => ManufactureDAO.Instance.GetList();

		public bool Remove(Manufacture manufacture) => ManufactureDAO.Instance.Remove(manufacture);

		public bool Update(Manufacture manufacture) => ManufactureDAO.Instance.Update(manufacture);
	}
}
