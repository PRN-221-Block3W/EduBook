using EduBook.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBook.Repository.IRepository
{
    public interface ISlotRepository
    {
        IList<Slot> GetList();
    }
}
