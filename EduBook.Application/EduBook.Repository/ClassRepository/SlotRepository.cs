using EduBook.BusinessObject;
using EduBook.DAO;
using EduBook.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBook.Repository.ClassRepository
{
    public class SlotRepository : ISlotRepository
    {
        public IList<Slot> GetList()
        {
            return SlotDAO.Instance.GetList();
        }
    }
}
