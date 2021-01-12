using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement.Core.Contracts;
using ProductManagement.Core.Models;
using ProductManagement.Core.ViewModels;
using ProductManagement.WebUI.Controllers;

namespace ProductManagement.WebUI.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexPageDoesReturnProducts()
        {
             
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<ProductCategory> productCategoryContext = new Mocks.MockContext<ProductCategory>();

            productContext.Insert(new Product());
            

            ProductManagerController controller = new ProductManagerController(productContext,productCategoryContext);
            //controller.HttpContext.Set<string>("Email","freneyhirpara11@gmail.com");

            ViewResult result = controller.Index() as ViewResult;
            //var viewModel = (Product)result.ViewData.Model;

            Assert.IsNotNull(result);
        }

    }
}
