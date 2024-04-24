using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace EduBook.DAO
{
	public class BookingDAO
	{
		private readonly EduBookContext _context = null;
		private static BookingDAO _instance = null;
		public static BookingDAO Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new BookingDAO();
				}
				return _instance;
			}
		}

		public BookingDAO()
		{
			_context = new EduBookContext();
		}

		public bool Create(Booking booking)
		{
			var list = GetList().OrderByDescending(x => x.BookingId).ToList();

			booking.Status = true;
			booking.BookingId = list[0].BookingId + 1;
			_context.Bookings.Add(booking);
			return _context.SaveChanges() > 0;
		}
		public List<Booking> GetList()
		{
			return _context.Bookings
				.Where(x => x.Status == true)
				.ToList();
		}

		public Booking GetById(int id)
		{
			return _context.Bookings
				.Where(x => x.Status == true)
					.FirstOrDefault(x => x.BookingId == id);
		}

		public bool Update(Booking booking)
		{
			var existingBooking = _context.Bookings.Find(booking.BookingId);
			if (existingBooking != null)
			{
				// Update the properties of the existing tracked entity
				_context.Entry(existingBooking).CurrentValues.SetValues(booking);
			}
			else
			{
				// If the entity is not tracked, attach it
				_context.Bookings.Attach(booking);
				// Change the entity state to Modified so that EF Core knows it should be updated
				_context.Entry(booking).State = EntityState.Modified;
			}
			return _context.SaveChanges() > 0;
		}

		public bool Remove(Booking booking)
		{
			booking.Status = false;
			_context.Bookings.Update(booking);
			return _context.SaveChanges() > 0;
		}

		public List<Booking> GetBookingsByAccount(int accountID)
		{
			var bookings = _context.Bookings
				.Where(x => x.Status == true)
				.Include(x => x.BookingDetails)
				.ToList();
			List<Booking> result = new List<Booking>();
			foreach (var booking in bookings)
			{
				foreach(var bookingDetails in booking.BookingDetails)
				{
					if(bookingDetails.AccountId == accountID)
					{
						result.Add(booking);
					}
				}
			}
			return result;
		}
	}
}
