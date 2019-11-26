using GlobalizationLab.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalizationLab.Controllers
{
    public class ProductController : BaseController
    {
        //
        // GET: /Product/


        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            //string cultureName = Request["cultureName"];
            //if (string.IsNullOrEmpty(cultureName))
            //    return;
            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            //System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;

        }

        public ActionResult Index()
        {
            return View(GetProduct());
        }

        [HttpPost]
        public ActionResult Index(string cultureName)
        {
            return View(GetProduct());
        }

        private ProductModel GetProduct()
        {
            ProductModel model = new ProductModel();
            model.CreateDate = DateTime.Now;
            model.CreateDateTime = DateTime.Now;
            model.CreateDateTimeNullable = new DateTime(2014, 12, 30);
            model.Id = 1;
            model.Price = 12345678.98765D;
            model.PricedDecmial = 12345678.01543M;
            model.ProductName = ""; ;
            return model;
        }

        public ActionResult Price()
        {
            return View(GetProduct());
        }

        [HttpPost]
        public ActionResult Price(string cultureName, ProductModel model)
        {
            return View(GetProduct());
        }

        public ActionResult ValidationDefaultType()
        {
            return View(GetProduct());
        }

        [HttpPost]
        public ActionResult ValidationDefaultType(string cultureName)
        {
            return View(GetProduct());
        }

        public ActionResult DateValidate()
        {
            DateModel m = new DateModel();
            m.CreateDate = DateTime.Now;
            return View(m);
        }

        [HttpPost]
        public ActionResult DateValidate(string cultureName, DateModel m)
        {
            if (m.CreateDate == DateTime.MinValue)
                m.CreateDate = DateTime.Now;
            return View(m);
        }

        public ActionResult TemplateTest()
        {
            return View(GetProduct());
        }
    }
}