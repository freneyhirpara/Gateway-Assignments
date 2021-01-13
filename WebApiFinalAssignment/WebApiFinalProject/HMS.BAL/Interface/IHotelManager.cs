using System;
using HMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Interface
{
    public interface IHotelManager
    {
        Hotel GetHotel(int id);

        List<Hotel> GetAllHotels();

        string CreateHotel(Hotel hotel);

        string UpdateHotel(Hotel hotel);

        string DeleteHotel(int Id);
    }
}
