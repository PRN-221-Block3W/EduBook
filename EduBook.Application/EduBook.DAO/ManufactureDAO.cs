using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace EduBook.DAO
{
	public class ManufactureDAO
	{
		private readonly EduBookContext _context = null;
		private static ManufactureDAO _instance = null;
		public static ManufactureDAO Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ManufactureDAO();
				}
				return _instance;
			}
		}

		public ManufactureDAO()
		{
			_context = new EduBookContext();
		}

		public bool Create(Manufacture manufacture)
		{
			var list = GetList().OrderByDescending(x => x.ManufactureId).ToList();

			manufacture.Status = true;
			manufacture.ManufactureId = list[0].ManufactureId + 1;
			_context.Manufactures.Add(manufacture);
			return _context.SaveChanges() > 0;
		}
		public List<Manufacture> GetList()
		{
			return _context.Manufactures
				.Where(x => x.Status == true)
				.ToList();
		}

		public Manufacture GetById(int id)
		{
			return _context.Manufactures
				.Where(x => x.Status == true)
					.FirstOrDefault(x => x.ManufactureId == id);
		}

		public bool Update(Manufacture manufacture)
		{
			var existingManufacture = _context.Manufactures.Find(manufacture.ManufactureId);
			if (existingManufacture != null)
			{
				// Update the properties of the existing tracked entity
				_context.Entry(existingManufacture).CurrentValues.SetValues(manufacture);
			}
			else
			{
				// If the entity is not tracked, attach it
				_context.Manufactures.Attach(manufacture);
				// Change the entity state to Modified so that EF Core knows it should be updated
				_context.Entry(manufacture).State = EntityState.Modified;
			}
			return _context.SaveChanges() > 0;
		}

		public bool Remove(Manufacture manufacture)
		{
			manufacture.Status = false;
			_context.Manufactures.Update(manufacture);
			return _context.SaveChanges() > 0;
		}
	}
}
