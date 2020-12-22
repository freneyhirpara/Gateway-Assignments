
using SourceControlFinalAssignment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace SourceControlFinalAssignment.Controllers
{
    public class HomeController : Controller
    {
         
        private static readonly ILog logger = LogManager.GetLogger(System.Environment.MachineName);  //Declaring log4net

        private DB_Entities _db = new DB_Entities();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Users _user, HttpPostedFileBase file)
        {
            
            try
            {
                logger.Info("Entering the Home Controller. Register Method.");
                if (ModelState.IsValid)
                {
                    var check = _db.Users.FirstOrDefault(s => s.Email == _user.Email);
                    if (check == null)
                    {

                        if (file != null)
                        {
                            _user.Image = _user.FirstName + _user.ContactNumber + Path.GetExtension(file.FileName);
                            file.SaveAs(Server.MapPath("//Content//UserImages//") + _user.Image);

                        }

                        _user.Password = GetMD5(_user.Password);
                        _db.Configuration.ValidateOnSaveEnabled = false;
                        _db.Users.Add(_user);
                        _db.SaveChanges();
                        logger.Info("Account Successfully Created.");
                        Session["FullName"] = _user.FirstName +" " + _user.LastName;
                        Session["Email"] = _user.Email;
                        Session["ID"] = _user.ID;
                        Session["Email"] = _user.Email;
                        Session["DateOfBirth"] = _user.DateOfBirth;
                        Session["ContactNumber"] = _user.ContactNumber;
                        Session["Age"] = _user.Age;
                        Session["Image"] = _user.Image;
                        Session["Country"] = _user.Country;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        
                            ModelState.AddModelError("Email", "User with this email already exists");
                            return View(_user);
         

                    }


                }
            }
            catch(Exception ex)
            {
                logger.Error("Exception occured- " , ex);
            }
            
            return View();



        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            try
            {
                logger.Info("Entering the Home Controller. Login Method.");
                if (ModelState.IsValid)
                {


                    var f_password = GetMD5(password);
                    var data = _db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                    if (data.Count() > 0)
                    {
                        //add session
                        Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                        Session["Email"] = data.FirstOrDefault().Email;
                        Session["ID"] = data.FirstOrDefault().ID;
                        Session["Email"] = data.FirstOrDefault().Email;
                        Session["DateOfBirth"] = data.FirstOrDefault().DateOfBirth;
                        Session["ContactNumber"] = data.FirstOrDefault().ContactNumber;
                        Session["Age"] = data.FirstOrDefault().Age;
                        Session["Image"] = data.FirstOrDefault().Image;
                        Session["Country"] = data.FirstOrDefault().Country;
                        logger.Info("Login Success");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        logger.Info("Login Failure");
                        ViewBag.error = "Login failed";
                        return RedirectToAction("Login");
                    }
                }
            }
            catch(Exception e)
            {
                logger.Error("Error Occurred- ", e);
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            logger.Info("Successfully Logged out.");
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }



        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}
