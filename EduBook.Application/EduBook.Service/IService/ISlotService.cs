using EduBook.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBook.Service.IService
{
    public interface ISlotService
    {
        IList<Slot> GetList();
    }
}
