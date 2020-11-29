using HelloMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {

        ObjectCache cache = MemoryCache.Default;
        List<Customer> customers;

        public HomeController()
        {
            customers = cache["customers"] as List<Customer>;
            if (customers == null)
            {
                customers = new List<Customer>();
            }
        }

        public void SaveCache()
        {
            cache["customers"] = customers;
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.MyMessage = "Hi i am freney";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Made by: Freney Hirpara----" +
                "freney.hirpara@thegatewaycorp.co.in";

            return View();
        }

        public ActionResult ViewCustomer(String id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }


        public ActionResult AddCustomer()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            customer.Id = Guid.NewGuid().ToString();
            customers.Add(customer);
            SaveCache();

            return RedirectToAction("CustomerList");
        }

        public ActionResult EditCustomer(String id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                
                    return View(customer);
                
            }
        }

        [HttpPost]
        public ActionResult EditCustomer(Customer customer, String id)
        {
            Customer customerToEdit = customers.FirstOrDefault(c => c.Id == id);
            if (customerToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                customerToEdit.Name = customer.Name;
                customerToEdit.Telephone = customer.Telephone;
                customerToEdit.Email = customer.Email;
                customerToEdit.ConfirmEmail = customer.ConfirmEmail;
                customerToEdit.PurchaseDate = customer.PurchaseDate;
                customerToEdit.Age = customer.Age;
                customerToEdit.FileName = customer.FileName;
                customerToEdit.CreditCardNumber = customer.CreditCardNumber;
               
                SaveCache();

                return RedirectToAction("CustomerList");
            }
        }

        public ActionResult DeleteCustomer(String id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }
        [HttpPost]
        [ActionName("DeleteCustomer")]
        public ActionResult ConfirmDeleteCustomer(String id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                customers.Remove(customer);
                return RedirectToAction("CustomerList");
            }
        }


        public ActionResult CustomerList()
        {
            return View(customers);
        }
    }
}