using HMS.BAL.Interface;
using HMS.DAL.Repository;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL
{
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;

        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public string CreateRoom(Room room)
        {
            return _roomRepository.CreateRoom(room);
        }

        public string DeleteRoom(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }
        public List<Room> GetRoomsByParameter(string Pincode)
        {
            return _roomRepository.GetRoomsByParameter(Pincode);
        }

        public Room GetRoom(int id)
        {
            throw new NotImplementedException();
        }
        public List<Room> GetRoomsByParameters(string Pincode, string City, Decimal RoomPrice, string RoomCategory)
        {
            return _roomRepository.GetRoomsByParameters(Pincode, City, RoomPrice, RoomCategory);
        }

        public string UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
