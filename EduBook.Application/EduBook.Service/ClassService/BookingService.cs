using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using EduBook.Repository.IRepository;
using EduBook.Service.IService;

namespace EduBook.Service.ClassService
{
	public class BookingService : IBookingService
	{
		private readonly IBookingRepository _repo;

		public BookingService(IBookingRepository repo)
		{
			_repo = repo;
		}
		public bool Create(Booking booking) => _repo.Create(booking);

		public Booking GetById(int id) => _repo.GetById(id);

		public List<Booking> GetList() => _repo.GetList();

		public bool Remove(Booking booking) => _repo.Remove(booking);

		public bool Update(Booking booking) => _repo.Update(booking);
		public List<Booking> GetBookingsByAccount(int accountID) => _repo.GetBookingsByAccount(accountID);
	}
}
