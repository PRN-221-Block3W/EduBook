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
    public class CommentRepository : ICommentRepository
    {
		public bool Create(Comment cmt) => CommentDAO.Instance.Create(cmt);

		public Comment GetById(int id) => CommentDAO.Instance.GetById(id);

		public List<Comment> GetList() => CommentDAO.Instance.GetList();

        public IList<Comment> GetListOfRoom(int roomId) => CommentDAO.Instance.GetListOfRoom(roomId);
        public bool Remove(Comment cmt) => CommentDAO.Instance.Remove(cmt);

		public bool Update(Comment cmt) => CommentDAO.Instance.Update(cmt);
	}
}
