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
    public class AccountRepository : IAccountRepository
    {
		public Account Login(string email, string password) => AccountDAO.Instance.Login(email, password);
        public List<Role> GetRoles() => AccountDAO.Instance.GetRoles();

        public bool Create(Account acc) => AccountDAO.Instance.Create(acc);
		public Account GetById(int id) => AccountDAO.Instance.GetById(id);
		public List<Account> GetList() => AccountDAO.Instance.GetList();
		public bool Remove(Account acc) => AccountDAO.Instance.Remove(acc);
		public bool Update(Account acc) => AccountDAO.Instance.Update(acc);
	}
}
