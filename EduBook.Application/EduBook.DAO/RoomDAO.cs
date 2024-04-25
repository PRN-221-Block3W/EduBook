using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace EduBook.DAO
{
	public class RoomDAO
	{
		private readonly EduBookContext _context = null;
		private static RoomDAO _instance = null;
		public static RoomDAO Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new RoomDAO();
				}
				return _instance;
			}
		}

		public RoomDAO()
		{
			_context = new EduBookContext();
		}

		public bool Create(Room room)
		{
			var list = GetList().OrderByDescending(x => x.RoomId).ToList();

			//room.Status = true;
			room.RoomId = list[0].RoomId + 1;
			_context.Rooms.Add(room);
			return _context.SaveChanges() > 0;
		}
		public List<Room> GetList()
		{
			var list =_context.Rooms
                .Where(x => x.Status == true)
                .Include(r => r.Department)
                .ToList();
			return list;
		}

		public Room GetById(int id)
		{
			return _context.Rooms
				.Include(r => r.Department)
				.Where(x => x.Status == true)
				.FirstOrDefault(x => x.RoomId == id);
		}

		public bool Update(Room room)
		{
			var existingRoom = _context.Rooms.Find(room.RoomId);
			if (existingRoom != null)
			{
				// Update the properties of the existing tracked entity
				_context.Entry(existingRoom).CurrentValues.SetValues(room);
			}
			else
			{
				// If the entity is not tracked, attach it
				_context.Rooms.Attach(room);
				// Change the entity state to Modified so that EF Core knows it should be updated
				_context.Entry(room).State = EntityState.Modified;
			}
			return _context.SaveChanges() > 0;
		}

		public bool Remove(Room room)
		{
			//room.Status = false;
			_context.Rooms.Update(room);
			return _context.SaveChanges() > 0;
		}
	}
}
