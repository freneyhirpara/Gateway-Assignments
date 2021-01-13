using HMS.DAL.Repository;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL
{
    public class BookingRepository : IBookingRepository
    {

        private readonly Database.HotelManagementSystemEntities _dbcontext;

        public BookingRepository()
        {
            _dbcontext = new Database.HotelManagementSystemEntities();
        }
        public string CreateBooking(Booking booking)
        {
            if (booking.BookingDate == null)
            {
                Database.Booking entity = new Database.Booking();


                entity.RoomId = booking.RoomId;
                entity.BookingDate = booking.BookingDate;
                entity.StatusOfBooking = booking.StatusOfBooking;


                _dbcontext.Bookings.Add(entity);
                _dbcontext.SaveChanges();

                return "Succesfully added.";
            }
            else
            {
                try
                {
                    var entity = _dbcontext.Bookings.Find(booking.BookingId);


                    if (entity != null)
                    {
                        entity.RoomId = booking.RoomId;
                        entity.BookingDate = booking.BookingDate;
                        entity.StatusOfBooking = booking.StatusOfBooking;



                        _dbcontext.SaveChanges();

                        return "Succesfully Updated.";
                    }

                    return "No Data Found";

                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        public string PostBooking(int RoomId, DateTime BookingDate, string StatusOfBooking = "Optional")
        {
            var check = GetAvailability(RoomId, BookingDate);
            if (check == "True")
            {

                Database.Booking entity = new Database.Booking();


                entity.RoomId = RoomId;
                entity.BookingDate = BookingDate;
                entity.StatusOfBooking = StatusOfBooking;


                _dbcontext.Bookings.Add(entity);
                _dbcontext.SaveChanges();

                return "Succesfully added.";
            }
            else
            {
                return "Sorry!! Room Not Available for this particular date.";
            }
        }


        public string DeleteBooking(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAllBookings()
        {
            var entities = _dbcontext.Bookings.ToList();
            List<Booking> list = new List<Booking>();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Booking booking = new Booking();
                    booking.BookingId = item.BookingId;
                    booking.RoomId = (int)item.RoomId;
                    booking.BookingDate = (DateTime)item.BookingDate;
                    booking.StatusOfBooking = item.StatusOfBooking;
                    
                    list.Add(booking);
                }
            }
            return list;
        }

        public string GetAvailability(int id, DateTime date)
        {
            var room = _dbcontext.Bookings.AsQueryable().FirstOrDefault(c => c.RoomId == id && c.BookingDate == date);
            //var bdate = _dbcontext.Bookings.AsQueryable().FirstOrDefault(c => c.BookingDate == date);
            if (room!=null)
            {
                return "False";
            }
            else
            {
                return "True";
            }

            
        }

        public Booking GetBooking(int id)
        {
            Booking booking = new Booking();
            var entity = _dbcontext.Bookings.Find(id);
            if (entity != null)
            {


                booking.BookingId = entity.BookingId;
                booking.RoomId = (int)entity.RoomId;
                booking.BookingDate = (DateTime)entity.BookingDate;
                booking.StatusOfBooking = entity.StatusOfBooking;
                




            }

            return booking;
        }

        public string UpdateBookingDate(int BookingId, DateTime BookingDate)
        {
            try
            {
                var entity = _dbcontext.Bookings.Find(BookingId);


                if (entity != null)
                {
                    
                    entity.BookingDate = BookingDate;
                    


                    
                    _dbcontext.SaveChanges();

                    return "Succesfully Updated.";
                }

                return "No Data Found";

            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
        public string UpdateBookingStatus(int BookingId, string StatusOfBooking)
        {
            try
            {
                var entity = _dbcontext.Bookings.Find(BookingId);


                if (entity != null)
                {

                    entity.StatusOfBooking = StatusOfBooking;




                    _dbcontext.SaveChanges();

                    return "Succesfully Updated.";
                }

                return "No Data Found";

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string UpdateDeleteStatus(int BookingId)
        {
            try
            {
                var entity = _dbcontext.Bookings.Find(BookingId);


                if (entity != null)
                {

                    entity.StatusOfBooking = "Deleted";




                    _dbcontext.SaveChanges();

                    return "Succesfully Updated.";
                }

                return "No Data Found";

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
