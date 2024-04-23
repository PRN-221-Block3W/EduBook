using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;

namespace EduBook.Service.IService
{
    public interface IEquipmentService
    {
        public bool Create(Equipment eq);
        public List<Equipment> GetList();
        public Equipment GetById(int id);
        public bool Update(Equipment eq);
        public bool Remove(Equipment eq);
    }
}
