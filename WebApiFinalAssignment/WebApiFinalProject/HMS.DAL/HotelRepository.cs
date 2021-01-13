using HMS.DAL.Repository;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HMS.DAL
{
    public class HotelRepository : IHotelRepository
    {

        private readonly Database.HotelManagementSystemEntities _dbcontext;

        public HotelRepository()
        {
            _dbcontext = new Database.HotelManagementSystemEntities();
        }
        public string CreateHotel(Hotel hotel)
        {
            Database.Hotel entity = new Database.Hotel();
            
            
            entity.HotelName = hotel.HotelName;
            entity.Address = hotel.Address;
            entity.City = hotel.City;
            entity.Pincode = hotel.Pincode;
            entity.IsActive = hotel.IsActive;
            entity.Website = hotel.Website;
            entity.Facebook = hotel.Facebook;
            entity.Twitter = hotel.Twitter;
            entity.ContactNumber = hotel.ContactNumber;
            entity.ContactPerson = hotel.ContactPerson;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = hotel.CreatedBy;
            entity.UpdatedBy = hotel.UpdatedBy;
            entity.UpdatedDate = DateTime.Now;

            _dbcontext.Hotels.Add(entity);
            _dbcontext.SaveChanges();

            return "Succesfully added.";

        }

        public string DeleteHotel(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAllHotels()
        {

            var entities = _dbcontext.Hotels.ToList();
            List<Hotel> list = new List<Hotel>();

            if (entities != null)
            {
                foreach(var item in entities)
                {
                    Hotel hotel = new Hotel(); 
                    hotel.Id = item.Id;
                    hotel.HotelName = item.HotelName;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.Pincode = item.Pincode;
                    hotel.IsActive = item.IsActive;
                    hotel.Website = item.Website;
                    hotel.Facebook = item.Facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.ContactNumber = item.ContactNumber;
                    hotel.ContactPerson = item.ContactPerson;
                    hotel.CreatedDate = (DateTime)item.CreatedDate;
                    hotel.CreatedBy = item.CreatedBy;
                    hotel.UpdatedBy = item.UpdatedBy;
                    hotel.UpdatedDate = (DateTime)item.UpdatedDate;


                    list.Add(hotel);
                }
            }
            return list;
            
        }

        /*public Hotel GetHotel()
        {
            
            return hotel;
        }
        */
        public Hotel GetHotel(int id)
        {
            Hotel hotel = new Hotel();
            var entity =  _dbcontext.Hotels.Find(id);
            if (entity != null)
            {
                
                    
                    hotel.Id = entity.Id;
                    hotel.HotelName = entity.HotelName;
                    hotel.Address = entity.Address;
                    hotel.City = entity.City;
                    hotel.Pincode = entity.Pincode;
                    hotel.ContactNumber = entity.ContactNumber;
                    hotel.ContactPerson = entity.ContactPerson;
                    hotel.CreatedDate = (DateTime)entity.CreatedDate;
                    hotel.CreatedBy = entity.CreatedBy;
                    hotel.UpdatedBy = entity.UpdatedBy;
                    hotel.UpdatedDate = (DateTime)entity.UpdatedDate;


                    
                
            }

            return hotel;
        }

        public string UpdateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
