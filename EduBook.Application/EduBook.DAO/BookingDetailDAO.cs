using EduBook.BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBook.DAO
{
    public class BookingDetailDAO
    {
        private readonly EduBookContext _context;
        private static BookingDetailDAO instance;
        public static BookingDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookingDetailDAO();
                }
                return instance;
            }
        }
        public BookingDetailDAO()
        {
            _context = new EduBookContext();
        }

        public IList<BookingDetail> GetList()
        {
            var list = _context.BookingDetails.Include(x => x.Slot)
                                    .Include(x => x.Account)
                                    .Include(x => x.Booking)
                                    .ToList();
            return list;
        }

        public BookingDetail GetBookingDetailById(int id)
        {
            var getOne = _context.BookingDetails.FirstOrDefault(x => x.BookingDetailId == id);
            return getOne == null ? null : getOne;
        }

        public bool Create(BookingDetail request)
        {
            var getBk = GetBookingDetailById(request.BookingDetailId);
            if (getBk != null)
            {
                _context.BookingDetails.Add(request);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(BookingDetail request)
        {
            var getBk = GetBookingDetailById(request.BookingDetailId);
            if (getBk != null)
            {
                _context.BookingDetails.Update(request);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(BookingDetail request)
        {
            var getBk = GetBookingDetailById(request.BookingDetailId);
            if (getBk != null)
            {
                _context.BookingDetails.Remove(request);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
