using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public interface IBookingRepository
    {
        Booking GetBooking(int id);

        List<Booking> GetAllBookings();

        string CreateBooking(Booking booking);

        string UpdateBookingDate(int BookingId, DateTime BookingDate);
        string UpdateBookingStatus(int BookingId, string StatusOfBooking);
        string UpdateDeleteStatus(int BookingId);

        string DeleteBooking(int Id);

        string GetAvailability(int id, DateTime date);
        string PostBooking(int RoomId, DateTime BookingDate, string StatusOfBooking = "Optional");
    }
}
