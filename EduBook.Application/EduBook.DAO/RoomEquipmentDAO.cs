using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBook.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace EduBook.DAO
{
    public class RoomEquipmentDAO
    {
        private readonly EduBookContext _context = null;
        private static RoomEquipmentDAO _instance = null;
        public static RoomEquipmentDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RoomEquipmentDAO();
                }
                return _instance;
            }
        }

        public RoomEquipmentDAO()
        {
            _context = new EduBookContext();
        }

        public bool Create(RoomEquipment roomEq)
        {
            var list = GetList().OrderByDescending(x => x.RoomEquipmentId).ToList();

            roomEq.Status = true;
            roomEq.RoomEquipmentId = list[0].RoomEquipmentId + 1;
            _context.RoomEquipments.Add(roomEq);
            return _context.SaveChanges() > 0;
        }
        public List<RoomEquipment> GetList()
        {
            return _context.RoomEquipments
                .Where(x => x.Status == true)
                .ToList();
        }

        public RoomEquipment GetById(int id)
        {
            return _context.RoomEquipments
                .Where(x => x.Status == true)
                    .FirstOrDefault(x => x.RoomEquipmentId == id);
        }

        public bool Update(RoomEquipment roomEq)
        {
            var existingRoomEquipment = _context.RoomEquipments.Find(roomEq.RoomEquipmentId);
            if (existingRoomEquipment != null)
            {
                // Update the properties of the existing tracked entity
                _context.Entry(existingRoomEquipment).CurrentValues.SetValues(roomEq);
            }
            else
            {
                // If the entity is not tracked, attach it
                _context.RoomEquipments.Attach(roomEq);
                // Change the entity state to Modified so that EF Core knows it should be updated
                _context.Entry(roomEq).State = EntityState.Modified;
            }
            return _context.SaveChanges() > 0;
        }

        public bool Remove(RoomEquipment roomEq)
        {
            roomEq.Status = false;
            _context.RoomEquipments.Update(roomEq);
            return _context.SaveChanges() > 0;
        }

        public IList<RoomEquipment> GetListRoomEquip(int roomId)
        {
            return _context.RoomEquipments
                .Include(x => x.Equipment)
                .ThenInclude(x => x.Manufacture)
                .Where(x => x.Status == true && x.RoomId == roomId)
                .ToList();
        }
    }
}
