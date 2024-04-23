using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace EduBook.DAO
{
	public class AccountDAO
	{
		private readonly EduBookContext _context = null;
		private static AccountDAO _instance = null;
		public static AccountDAO Instance
		{
			get
			{
				if(_instance == null)
				{
					_instance = new AccountDAO();
				}
				return _instance;
			}
		}

        public AccountDAO()
        {
			_context = new EduBookContext();
        }

		public Account Login(string email, string password)
		{
			return _context.Accounts
				.FirstOrDefault(x => x.Email.Equals(email)
								&& x.Password.Equals(password)
								&& x.Status == true);
		}

		public bool Create(Account customer)
		{
			var cuslist = GetList().OrderByDescending(x => x.AccountId).ToList();

			customer.Status = true;
			customer.AccountId = cuslist[0].AccountId + 1;
			_context.Accounts.Add(customer);
			return _context.SaveChanges() > 0;
		}
		public List<Account> GetList()
		{
			return _context.Accounts
				.Where(x => x.Status == true)
				.ToList();
		}

		public Account GetById(int id)
		{
			return _context.Accounts
				.Where(x => x.Status == true)
					.FirstOrDefault(x => x.AccountId == id);
		}

		public bool Update(Account customer)
		{
			var existingAccount = _context.Accounts.Find(customer.AccountId);
			if (existingAccount != null)
			{
				// Update the properties of the existing tracked entity
				_context.Entry(existingAccount).CurrentValues.SetValues(customer);
			}
			else
			{
				// If the entity is not tracked, attach it
				_context.Accounts.Attach(customer);
				// Change the entity state to Modified so that EF Core knows it should be updated
				_context.Entry(customer).State = EntityState.Modified;
			}
			return _context.SaveChanges() > 0;
		}

		public bool Remove(Account customer)
		{
			customer.Status = false;
			_context.Accounts.Update(customer);
			return _context.SaveChanges() > 0;
		}
	}
}
