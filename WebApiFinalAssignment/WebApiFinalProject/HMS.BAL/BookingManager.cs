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
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public string CreateBooking(Booking booking)
        {
            return _bookingRepository.CreateBooking(booking);
        }


        public string PostBooking(int RoomId, DateTime BookingDate, string StatusOfBooking = "Optional")
        {
            return _bookingRepository.PostBooking(RoomId,BookingDate,StatusOfBooking);
        }

        public string GetAvailability(int id,DateTime date)
        {
            return _bookingRepository.GetAvailability(id, date);
        }

        public string DeleteBooking(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAllBookings()
        {
            return _bookingRepository.GetAllBookings();
        }

        public Booking GetBooking(int id)
        {
            return _bookingRepository.GetBooking(id);
        }

        public string UpdateBookingDate(int BookingId, DateTime BookingDate)
        {
            return _bookingRepository.UpdateBookingDate(BookingId,BookingDate);
        }
        public string UpdateBookingStatus(int BookingId, string StatusOfBooking)
        {
            return _bookingRepository.UpdateBookingStatus(BookingId, StatusOfBooking);
        }
        public string UpdateDeleteStatus(int BookingId)
        {
            return _bookingRepository.UpdateDeleteStatus(BookingId);
        }

    }
}
