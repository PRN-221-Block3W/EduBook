using EduBook.BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBook.Repository.IRepository
{
    public interface IBookingDetailsRepository
    {
         IList<BookingDetail> GetListByBookingId(int bookingId);

		 IList<BookingDetail> GetList();

         BookingDetail GetBookingDetailById(int id);

         bool Create(BookingDetail request);

         bool Update(BookingDetail request);

         bool Delete(BookingDetail request);
    }
}
