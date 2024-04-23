using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using EduBook.DAO;
using EduBook.Repository.IRepository;

namespace EduBook.Repository.ClassRepository
{
    public class BookingRepository : IBookingRepository
    {
		public bool Create(Booking booking) => BookingDAO.Instance.Create(booking);

		public Booking GetById(int id) => BookingDAO.Instance.GetById(id);

		public List<Booking> GetList() => BookingDAO.Instance.GetList();

		public bool Remove(Booking booking) => BookingDAO.Instance.Remove(booking);

		public bool Update(Booking booking) => BookingDAO.Instance.Update(booking);
	}
}
