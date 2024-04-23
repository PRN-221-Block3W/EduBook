using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;

namespace EduBook.Service.IService
{
    public interface IDepartmentService
    {
        public bool Create(Department dep);
        public List<Department> GetList();
        public Department GetById(int id);
        public bool Update(Department dep);
        public bool Remove(Department dep);
    }
}
