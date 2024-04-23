using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;

namespace EduBook.Repository.IRepository
{
    public interface IManufactureRepository
    {
        public bool Create(Manufacture manufacture);
        public List<Manufacture> GetList();
        public Manufacture GetById(int id);
        public bool Update(Manufacture manufacture);
        public bool Remove(Manufacture manufacture);
    }
}
