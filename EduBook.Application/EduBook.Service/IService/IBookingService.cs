using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;

namespace EduBook.Service.IService
{
    public interface IBookingService
    {
        public List<Booking> GetBookingsByAccount(int accountID);

		public bool Create(Booking booking);
        public List<Booking> GetList();
        public Booking GetById(int id);
        public bool Update(Booking booking);
        public bool Remove(Booking booking);
    }
}
