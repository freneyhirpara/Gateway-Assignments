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
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public string CreateHotel(Hotel hotel)
        {
            return _hotelRepository.CreateHotel(hotel);
        }

        public string DeleteHotel(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }

        /*public Hotel GetHotel()
        {
            /*Hotel hotel = new Hotel
            {
                Id = 7,
                HotelName = "FFX",
                Address = "X",
                City = "Abad",
                Pincode = "398394",
                ContactNumber = "7489364",
                ContactPerson = "njn",
                Website = "mk.cmd",
                IsActive = "true",
                



            };
            var hotel = _hotelRepository.GetHotel();
            return hotel;
        }*/

        public Hotel GetHotel(int id)
        {
            return _hotelRepository.GetHotel(id);
        }

        public string UpdateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
