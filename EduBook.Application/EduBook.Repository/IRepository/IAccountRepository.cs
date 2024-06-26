﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;

namespace EduBook.Repository.IRepository
{
    public interface IAccountRepository
    {
        public Account Login(string email, string password);
        public List<Role> GetRoles();
        public bool Create(Account acc);
        public List<Account> GetList();
        public Account GetById(int id);
        public bool Update(Account acc);
        public bool Remove(Account acc);
        Account GetByEmail(string email);

	}
}
