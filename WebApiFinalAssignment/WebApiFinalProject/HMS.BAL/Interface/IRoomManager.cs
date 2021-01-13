using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Interface
{
    public interface IRoomManager
    {
        Room GetRoom(int id);

        List<Room> GetAllRooms();

        string CreateRoom(Room room);

        string UpdateRoom(Room room);

        string DeleteRoom(int Id);
        List<Room> GetRoomsByParameter(string Pincode);
        List<Room> GetRoomsByParameters(string Pincode, string City, Decimal RoomPrice, string RoomCategory);
    }
}
