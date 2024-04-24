using EduBook.BusinessObject;
using EduBook.Repository.IRepository;
using EduBook.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBook.Service.ClassService
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _repo;
        public SlotService(ISlotRepository repo)
        {
            _repo = repo;
        }
        public IList<Slot> GetList() => _repo.GetList();
    }
}
