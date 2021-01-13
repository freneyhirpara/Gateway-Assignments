using HMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HMS.WebApi.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public ActionResult List()
        {
            List<Hotel> list;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Hotel").Result;
            list = response.Content.ReadAsAsync<List<Hotel>>().Result;
            return View(list);
        }

        public ActionResult CreateHotel(int Id=0)
        {
            return View(new Hotel());
        }
        [HttpPost]
        public ActionResult CreateHotel(Hotel hotel)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Hotel", hotel).Result;
            return RedirectToAction("List");
        }







        public ActionResult RoomList(string pincode)
        {
            List<Room> roomlist;
            if (pincode != null)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Room?Pincode="+pincode).Result;
                roomlist = response.Content.ReadAsAsync<List<Room>>().Result;
                return View(roomlist);
            }
            else
            {
                
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Room").Result;
                roomlist = response.Content.ReadAsAsync<List<Room>>().Result;
                return View(roomlist);
            }
            
        }




        public ActionResult BookingList()
        {
            List<Booking> list;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Booking").Result;
            list = response.Content.ReadAsAsync<List<Booking>>().Result;
            return View(list);
        }




        public ActionResult CreateBooking(int Id)
        {
            
            return View(new Booking() { RoomId= Id});
        }
        [HttpPost]
        public ActionResult CreateBooking(Booking booking)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Booking", booking).Result;
            return RedirectToAction("BookingList");
        }


        public ActionResult UpdateBooking(int Id)
        {

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Booking/"+Id.ToString()).Result;
            return View(response.Content.ReadAsAsync<Booking>().Result);
        }
        [HttpPost]
        public ActionResult UpdateBooking(Booking booking)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Booking", booking).Result;
            return RedirectToAction("BookingList");
        }



    }

    

}
