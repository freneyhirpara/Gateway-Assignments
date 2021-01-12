using ProductManagement.Core.Contracts;
using ProductManagement.Core.Models;
using ProductManagement.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        // GET: ProductCategoryManager
        IRepository<ProductCategory> context;

        public ProductCategoryManagerController(IRepository<ProductCategory> context)
        {
            this.context = context;
        }
        public ActionResult Index()
        {
            if (Session["Email"] != null)
            {


                List<ProductCategory> productCategories = context.Collection().ToList();
                return View(productCategories);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Create()
        {
            if (Session["Email"] != null)
            {



                ProductCategory productCategory = new ProductCategory();
                return View(productCategory);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
                context.Commit();

                return RedirectToAction("Index");
            }

        }


        public ActionResult Edit(string Id)
        {
            if (Session["Email"] != null)
            {



                ProductCategory productCategory = context.Find(Id);
                if (productCategory == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(productCategory);
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory categoryToEdit = context.Find(Id);
            if (categoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }
                categoryToEdit.Category = productCategory.Category;
                
                context.Commit();

                return RedirectToAction("Index");

            }

        }

        public ActionResult Delete(string Id)
        {
            if (Session["Email"] != null)
            {



                ProductCategory categoryToDelete = context.Find(Id);
                if (categoryToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(categoryToDelete);
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory categoryToDelete = context.Find(Id);
            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(categoryToDelete);

                return RedirectToAction("Index");
            }

        }
    }
}