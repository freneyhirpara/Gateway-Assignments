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
    public class RoomController : ApiController
    {

        private readonly IRoomManager _roomManager;
        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }
        // GET: api/Room
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse<List<Room>>(HttpStatusCode.OK, _roomManager.GetAllRooms().AsQueryable().OrderBy(d => d.RoomPrice).ToList());
        }

        public HttpResponseMessage Get(string Pincode)
        {
            return Request.CreateResponse<List<Room>>(HttpStatusCode.OK, _roomManager.GetRoomsByParameter(Pincode).AsQueryable().OrderBy(d => d.RoomPrice).ToList());
        }

        [Route("api/Room/{Pincode}/{City}/{RoomPrice}/{RoomCategory}")]
        public HttpResponseMessage Get(string Pincode, string City, Decimal RoomPrice, string RoomCategory)
        {
            return Request.CreateResponse<List<Room>>(HttpStatusCode.OK, _roomManager.GetRoomsByParameters(Pincode,City,RoomPrice,RoomCategory).AsQueryable().OrderBy(d => d.RoomPrice).ToList());
        }

        

        // POST: api/Room
        public IHttpActionResult Post([FromBody]Room room)
        {
            return Ok<string>(_roomManager.CreateRoom(room));
        }

        // PUT: api/Room/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
        }
    }
}
