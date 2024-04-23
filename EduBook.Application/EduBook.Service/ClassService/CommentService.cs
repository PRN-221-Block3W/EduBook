using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using EduBook.Repository.IRepository;
using EduBook.Service.IService;

namespace EduBook.Service.ClassRepository
{
	public class CommentService : ICommentService
	{
		private readonly ICommentRepository _repo;

		public CommentService(ICommentRepository repo)
		{
			_repo = repo;
		}

		public bool Create(Comment cmt) => _repo.Create(cmt);

		public Comment GetById(int id) => _repo.GetById(id);

		public List<Comment> GetList() => _repo.GetList();

		public bool Remove(Comment cmt) => _repo.Remove(cmt);

		public bool Update(Comment cmt) => _repo.Update(cmt);
	}
}
