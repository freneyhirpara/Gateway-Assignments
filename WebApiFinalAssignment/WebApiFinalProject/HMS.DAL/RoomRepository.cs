using HMS.DAL.Repository;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL
{
    public class RoomRepository : IRoomRepository
    {

        private readonly Database.HotelManagementSystemEntities _dbcontext;
        public RoomRepository()
        {
            _dbcontext = new Database.HotelManagementSystemEntities();
        }
       
        public string CreateRoom(Room room)
        {
            Database.Room entity = new Database.Room();


            
            entity.HotelId = (int)room.HotelId;
            entity.RoomName = room.RoomName;
            entity.RoomPrice = (decimal)room.RoomPrice;
            entity.RoomCategory = room.RoomCategory;
            entity.IsActive = (bool)room.IsActive;
            entity.CreatedDate = (DateTime)room.CreatedDate;
            entity.CreatedBy = room.CreatedBy;
            entity.UpdatedBy = room.UpdatedBy;
            entity.UpdatedDate = (DateTime)room.UpdatedDate;

            _dbcontext.Rooms.Add(entity);
            _dbcontext.SaveChanges();

            return "Succesfully added.";
        }

        public string DeleteRoom(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRooms()
        {
            var entities = _dbcontext.Rooms.ToList();
            List<Room> list = new List<Room>();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Room room = new Room();
                    room.RoomId = item.RoomId;
                    room.HotelId = (int)item.HotelId;
                    room.RoomName = item.RoomName;
                    room.RoomPrice = (decimal)item.RoomPrice;
                    room.RoomCategory = item.RoomCategory;
                    room.IsActive = (bool)item.IsActive;
                    room.CreatedDate = (DateTime)item.CreatedDate;
                    room.CreatedBy = item.CreatedBy;
                    room.UpdatedBy = item.UpdatedBy;
                    room.UpdatedDate = (DateTime)item.UpdatedDate;


                    list.Add(room);
                }
            }
            return list;
        }



        
       public List<Room> GetRoomsByParameter(string Pincode)
       {
            var hotels = _dbcontext.Hotels.ToList();
            var rooms = _dbcontext.Rooms.ToList();
            //var entities = _dbcontext.Rooms.AsQueryable().Select(c => c.Pincode == Pincode).ToList();
            var entities = from r in _dbcontext.Rooms
                           join h in _dbcontext.Hotels on r.HotelId equals h.Id 
                           where h.Pincode == Pincode 
                         select r;

            List<Room> list = new List<Room>();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Room room = new Room();
                    room.RoomId = item.RoomId;
                    room.HotelId = (int)item.HotelId;
                    room.RoomName = item.RoomName;
                    room.RoomPrice = (decimal)item.RoomPrice;
                    room.RoomCategory = item.RoomCategory;
                    room.IsActive = (bool)item.IsActive;
                    room.CreatedDate = (DateTime)item.CreatedDate;
                    room.CreatedBy = item.CreatedBy;
                    room.UpdatedBy = item.UpdatedBy;
                    room.UpdatedDate = (DateTime)item.UpdatedDate;


                    list.Add(room);
                }
            }
            return list;
        }

        public List<Room> GetRoomsByParameters(string Pincode,string City, Decimal RoomPrice, string RoomCategory)
        {
            var hotels = _dbcontext.Hotels.ToList();
            var rooms = _dbcontext.Rooms.ToList();
            //var entities = _dbcontext.Rooms.AsQueryable().Select(c => c.Pincode == Pincode).ToList();
            var entities = from r in _dbcontext.Rooms
                           join h in _dbcontext.Hotels on r.HotelId equals h.Id
                           where h.Pincode == Pincode && h.City==City && r.RoomPrice<=RoomPrice && r.RoomCategory==RoomCategory
                           select r;

            List<Room> list = new List<Room>();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Room room = new Room();
                    room.RoomId = item.RoomId;
                    room.HotelId = (int)item.HotelId;
                    room.RoomName = item.RoomName;
                    room.RoomPrice = (decimal)item.RoomPrice;
                    room.RoomCategory = item.RoomCategory;
                    room.IsActive = (bool)item.IsActive;
                    room.CreatedDate = (DateTime)item.CreatedDate;
                    room.CreatedBy = item.CreatedBy;
                    room.UpdatedBy = item.UpdatedBy;
                    room.UpdatedDate = (DateTime)item.UpdatedDate;


                    list.Add(room);
                }
            }
            return list;
        }







        public Room GetRoom(int id)
        {
            throw new NotImplementedException();
        }

        public string UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
