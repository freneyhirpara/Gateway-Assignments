using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using PagedList;
using ProductManagement.Core.Contracts;
using ProductManagement.Core.Models;
using ProductManagement.Core.ViewModels;
using ProductManagement.DataAccess.InMemory;

namespace ProductManagement.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        private static Logger logger = LogManager.GetLogger("myAppLoggerRule");
        // GET: ProductManager
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;

        public ProductManagerController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
        }
        public ActionResult Index( string option=null,string search=null, int? pageNumber=null, string sort=null)
        {
            logger.Info("Entering the Product Manager Controller. Index Method");
            try
            {
                if (Session["Email"] != null)
                {



                    List<Product> products = context.Collection().ToList();


                    //if the sort parameter is null or empty then we are initializing the value as descending name  
                    ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";
                    //if the sort value is gender then we are initializing the value as descending gender  
                    ViewBag.SortByCategory = sort == "Category" ? "descending gender" : "Category";

                    //here we are converting the db.Students to AsQueryable so that we can invoke all the extension methods on variable records.  
                    var records = products.AsQueryable();
                    if (search != null)
                    {
                        if (option == "Category")
                        {

                            records = records.Where(x => x.Category.StartsWith(search) || search == null);

                        }
                        else
                        {
                            records = records.Where(x => x.Name.StartsWith(search) || search == null);
                        }
                    }


                    switch (sort)
                    {

                        case "descending name":
                            records = records.OrderByDescending(x => x.Name);
                            break;

                        case "descending category":
                            records = records.OrderByDescending(x => x.Category);
                            break;

                        case "Category":
                            records = records.OrderBy(x => x.Category);
                            break;

                        default:
                            records = records.OrderBy(x => x.Name);
                            break;

                    }
                    return View(records.ToPagedList(pageNumber ?? 1, 2));
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch(Exception e)
            {
                logger.Error("Exception Occured - " + e.Message);
                return Content("Exception Occured" + e.Message);
            }
            

            
        }




        public ActionResult DeleteSelected(FormCollection formcollection)
        {
            
            
            
            if (formcollection["ids"] == null)
            {
                //throw error
                ModelState.AddModelError("", "No item selected to delete");
                return RedirectToAction("Index");
            }
            string[] idss = formcollection["ids"].Split(new char[] { ',' });

            foreach (string id in idss)
            {
                Product todo = context.Find(id);
                 //remove the record from the database
                context.Delete(todo);

            }
            //redirect to index view once record is deleted
            TempData["DeleteMessage"] = "Deleted Successfully";
            logger.Info("Multiple Records Deleted Successfully");
            return RedirectToAction("Index");

        }

        public ActionResult Create()
        {
            if (Session["Email"] != null) { 
            ProductManagerViewModel viewModel = new ProductManagerViewModel();

            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection(); ;
            return View(viewModel);
               }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Create(Product product,HttpPostedFileBase file)
        {
            try 
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                else
                {
                    if (file != null)
                    {
                        product.Image = product.Id + Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath("//Content//ProductImages//") + product.Image);

                    }
                    context.Insert(product);
                    context.Commit();
                    TempData["CreateMessage"] = "Added Successfully";
                    logger.Info("New Product successfully added.");
                    return RedirectToAction("Index");
                }

            }
            catch (Exception e)
            {

                logger.Error("Exception Occured - " + e.Message);
                return Content("Exception Occured" + e.Message);
            }
            
        }


        public ActionResult Edit(string Id)
        {
            if (Session["Email"] != null)
            {

                Product product = context.Find(Id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ProductManagerViewModel viewModel = new ProductManagerViewModel();

                    viewModel.Product = product;
                    viewModel.ProductCategories = productCategories.Collection(); ;
                    return View(viewModel);
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string Id,HttpPostedFileBase file)
        {
            try
            {
                Product productToEdit = context.Find(Id);
                if (productToEdit == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        return View(product);
                    }
                    if (file != null)
                    {
                        productToEdit.Image = product.Id + Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath("//Content//ProductImages//") + productToEdit.Image);

                    }
                    productToEdit.Category = product.Category;
                    productToEdit.Name = product.Name;
                    productToEdit.Description = product.Description;
                    productToEdit.Price = product.Price;
                    productToEdit.Quantity = product.Quantity;

                    context.Commit();
                    TempData["EditMessage"] = "Edited Successfully";
                    logger.Info("Product Edited successfully.");
                    return RedirectToAction("Index");

                }
            }
            catch(Exception e)
            {
                logger.Error("Exception Occured - " + e.Message);
                return Content("Exception Occured" + e.Message);
            }
            

        }

        public ActionResult Delete(string Id)
        {
            if (Session["Email"] != null)
            {



                Product productToDelete = context.Find(Id);
                if (productToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(productToDelete);
                }
            }
            else
            {
                return RedirectToAction("Login","Account");
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            try
            {
                Product productToDelete = context.Find(Id);
                if (productToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    context.Delete(productToDelete);
                    TempData["DeleteMessage"] = "Deleted Successfully";
                    logger.Info("Product successfully Deleted.");
                    return RedirectToAction("Index");
                }
            }
            catch(Exception e)
            {
                logger.Error("Exception Occured - " + e.Message);
                return Content("Exception Occured" + e.Message);
            }


        }
    }
}