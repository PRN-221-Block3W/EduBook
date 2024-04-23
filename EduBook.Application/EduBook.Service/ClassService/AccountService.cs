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
	public class AccountService : IAccountService
	{
		private readonly IAccountRepository _repo;

		public AccountService(IAccountRepository repo)
		{
			_repo = repo;
		}
		public Account Login(string email, string password) => _repo.Login(email, password);
		public bool Create(Account acc) => _repo.Create(acc);

		public Account GetById(int id) => _repo.GetById(id);

		public List<Account> GetList() => _repo.GetList();

		public bool Remove(Account acc) => _repo.Remove(acc);

		public bool Update(Account acc) => _repo.Update(acc);
	}
}
