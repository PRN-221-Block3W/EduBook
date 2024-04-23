using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace EduBook.DAO
{
	public class CommentDAO
	{
		private readonly EduBookContext _context = null;
		private static CommentDAO _instance = null;
		public static CommentDAO Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CommentDAO();
				}
				return _instance;
			}
		}

		public CommentDAO()
		{
			_context = new EduBookContext();
		}

		public bool Create(Comment comment)
		{
			var cuslist = GetList().OrderByDescending(x => x.CommentId).ToList();

			comment.Status = true;
			comment.CommentId = cuslist[0].CommentId + 1;
			_context.Comments.Add(comment);
			return _context.SaveChanges() > 0;
		}
		public List<Comment> GetList()
		{
			return _context.Comments
				.Where(x => x.Status == true)
				.ToList();
		}

		public Comment GetById(int id)
		{
			return _context.Comments
				.Where(x => x.Status == true)
					.FirstOrDefault(x => x.CommentId == id);
		}

		public bool Update(Comment comment)
		{
			var existingComment = _context.Comments.Find(comment.CommentId);
			if (existingComment != null)
			{
				// Update the properties of the existing tracked entity
				_context.Entry(existingComment).CurrentValues.SetValues(comment);
			}
			else
			{
				// If the entity is not tracked, attach it
				_context.Comments.Attach(comment);
				// Change the entity state to Modified so that EF Core knows it should be updated
				_context.Entry(comment).State = EntityState.Modified;
			}
			return _context.SaveChanges() > 0;
		}

		public bool Remove(Comment comment)
		{
			comment.Status = false;
			_context.Comments.Update(comment);
			return _context.SaveChanges() > 0;
		}
	}
}
