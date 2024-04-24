using EduBook.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBook.DAO
{
    public class SlotDAO
    {
        private readonly EduBookContext _context;
        private static SlotDAO instance;
        public static SlotDAO Instance { 
            get
            {
                if (instance == null)
                {
                    instance = new SlotDAO();
                }
                return instance;
            }
        }
        public SlotDAO()
        {
            _context = new EduBookContext();
        }

        public IList<Slot> GetList() { 
            var list = _context.Slots.ToList();
            return list;
        }
    }
}
