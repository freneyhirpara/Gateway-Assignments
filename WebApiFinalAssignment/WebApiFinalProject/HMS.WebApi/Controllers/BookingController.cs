using HMS.BAL.Interface;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMS.WebApi.Controllers
{
    
    public class BookingController : ApiController
    {

        private readonly IBookingManager _bookingManager;
        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        // GET: api/Booking
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse<List<Booking>>(HttpStatusCode.OK,_bookingManager.GetAllBookings().ToList());
        }

        [Route("api/Booking/{id}/{date}")]
        public IHttpActionResult Get(int id,DateTime date)
        {
            return Ok<string>(_bookingManager.GetAvailability(id, date));
        }

        // GET: api/Booking/5
        public Booking Get(int id)
        {
            return _bookingManager.GetBooking(id);
        }

        // POST: api/Booking
        public IHttpActionResult Post([FromBody]Booking booking)
        {
            return Ok<string>(_bookingManager.CreateBooking(booking));
        }
        [Route("api/Booking/{RoomId}/{BookingDate}/{StatusOfBooking}")]
        public IHttpActionResult Post([FromUri] int RoomId, DateTime BookingDate, string StatusOfBooking = "Optional"  )
        {
            

            return Ok<string>(_bookingManager.PostBooking(RoomId,BookingDate,StatusOfBooking));
        }

        // PUT: api/Booking/5
        [Route("api/Booking/PutDate/{BookingId}/{BookingDate}")]
        public IHttpActionResult PutDate([FromUri] int BookingId, DateTime BookingDate)
        {
            return Ok<string>(_bookingManager.UpdateBookingDate(BookingId,BookingDate));
        }
        [Route("api/Booking/PutStatus/{BookingId}/{StatusOfBooking}")]
        public IHttpActionResult PutStatus([FromUri] int BookingId, string StatusOfBooking)
        {
            return Ok<string>(_bookingManager.UpdateBookingStatus(BookingId, StatusOfBooking));
        }

        [Route("api/Booking/PutDelete/{BookingId}")]
        public IHttpActionResult PutDelete([FromUri] int BookingId)
        {
            return Ok<string>(_bookingManager.UpdateDeleteStatus(BookingId));
        }
        // DELETE: api/Booking/5
        public void Delete(int id)
        {
        }
    }
}
