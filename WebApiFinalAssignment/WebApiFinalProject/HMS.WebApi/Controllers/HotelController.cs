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
    public class HotelController : ApiController
    {

        private readonly IHotelManager _hotelManager;
        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }
        // GET: api/Hotel
        public HttpResponseMessage Get()
        
        {
            //var hotel = _hotelManager.GetHotel();
            return Request.CreateResponse<List<Hotel>>(HttpStatusCode.OK, _hotelManager.GetAllHotels().AsQueryable().OrderBy(d => d.HotelName).ToList());
            ///return new string[] { "value1", "value2" };
        }

        // GET: api/Hotel/5
        public Hotel Get(int id)
        {
            return _hotelManager.GetHotel(id);
        }

        // POST: api/Hotel
        public IHttpActionResult Post([FromBody]Hotel hotel)
        {
            return Ok<string>(_hotelManager.CreateHotel(hotel));
        }

        // PUT: api/Hotel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
        }
    }
}
