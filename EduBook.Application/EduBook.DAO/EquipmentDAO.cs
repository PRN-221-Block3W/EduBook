using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace EduBook.DAO
{
	public class EquipmentDAO
	{
		private readonly EduBookContext _context = null;
		private static EquipmentDAO _instance = null;
		public static EquipmentDAO Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new EquipmentDAO();
				}
				return _instance;
			}
		}

		public EquipmentDAO()
		{
			_context = new EduBookContext();
		}

		public bool Create(Equipment equipment)
		{
			var list = GetList().OrderByDescending(x => x.EquipmentId).ToList();

			equipment.Status = true;
			equipment.EquipmentId = list[0].EquipmentId + 1;
			_context.Equipment.Add(equipment);
			return _context.SaveChanges() > 0;
		}
		public List<Equipment> GetList()
		{
			return _context.Equipment
				.Where(x => x.Status == true)
				.ToList();
		}

		public Equipment GetById(int id)
		{
			return _context.Equipment
				.Where(x => x.Status == true)
					.FirstOrDefault(x => x.EquipmentId == id);
		}

		public bool Update(Equipment equipment)
		{
			var existingEquipment = _context.Equipment.Find(equipment.EquipmentId);
			if (existingEquipment != null)
			{
				// Update the properties of the existing tracked entity
				_context.Entry(existingEquipment).CurrentValues.SetValues(equipment);
			}
			else
			{
				// If the entity is not tracked, attach it
				_context.Equipment.Attach(equipment);
				// Change the entity state to Modified so that EF Core knows it should be updated
				_context.Entry(equipment).State = EntityState.Modified;
			}
			return _context.SaveChanges() > 0;
		}

		public bool Remove(Equipment equipment)
		{
			equipment.Status = false;
			_context.Equipment.Update(equipment);
			return _context.SaveChanges() > 0;
		}
	}
}
