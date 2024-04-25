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
    public class BookingDetailsService : IBookingDetailsService
    {
        private readonly IBookingDetailsRepository _repo;

        public BookingDetailsService(IBookingDetailsRepository repo)
        {
            _repo = repo;
        }

        public bool Create(BookingDetail request)
        {
            return _repo.Create(request);
        }

        public bool Delete(BookingDetail request)
        {
            return _repo.Delete(request);
        }

        public BookingDetail GetBookingDetailById(int id)
        {
            return _repo.GetBookingDetailById(id);
        }
		public IList<BookingDetail> GetListByBookingId(int bookingId)
        {
            return _repo.GetListByBookingId(bookingId);
        }


		public IList<BookingDetail> GetList()
        {
            return _repo.GetList();
        }

        public bool Update(BookingDetail request)
        {
            return _repo.Update(request);
        }
    }
}
