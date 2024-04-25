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
    public class BookingDetailsRepository : IBookingDetailsRepository
    {
        public bool Create(BookingDetail request)
        {
            return BookingDetailDAO.Instance.Create(request);
        }

        public bool Delete(BookingDetail request)
        {
            return BookingDetailDAO.Instance.Delete(request);
        }

        public BookingDetail GetBookingDetailById(int id)
        {
            return BookingDetailDAO.Instance.GetBookingDetailById(id);
        }

		public IList<BookingDetail> GetListByBookingId(int bookingId)
        {
            return BookingDetailDAO.Instance.GetListByBookingId(bookingId);
        }


		public IList<BookingDetail> GetList()
        {
            return BookingDetailDAO.Instance.GetList();
        }

        public bool Update(BookingDetail request)
        {
            return BookingDetailDAO.Instance.Update(request);
        }
    }
}
