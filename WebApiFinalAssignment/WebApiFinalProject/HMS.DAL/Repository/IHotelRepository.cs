using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public interface IHotelRepository
    {
        Hotel GetHotel(int id);

        List<Hotel> GetAllHotels();

        string CreateHotel(Hotel hotel);

        string UpdateHotel(Hotel hotel);

        string DeleteHotel(int Id);
    }
}
