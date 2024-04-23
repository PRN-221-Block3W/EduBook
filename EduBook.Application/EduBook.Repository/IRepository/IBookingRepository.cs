using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;

namespace EduBook.Repository.IRepository
{
    public interface IBookingRepository
    {
        public bool Create(Booking booking);
        public List<Booking> GetList();
        public Booking GetById(int id);
        public bool Update(Booking booking);
        public bool Remove(Booking booking);
    }
}
