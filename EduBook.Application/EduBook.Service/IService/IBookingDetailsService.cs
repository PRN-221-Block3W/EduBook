using EduBook.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBook.Service.IService
{
    public interface IBookingDetailsService
    {
        IList<BookingDetail> GetList();

        BookingDetail GetBookingDetailById(int id);

        bool Create(BookingDetail request);

        bool Update(BookingDetail request);

        bool Delete(BookingDetail request);
    }
}
