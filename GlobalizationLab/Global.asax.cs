using GlobalizationLab.Core;
using GlobalizationLab.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GlobalizationLab
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            this.BeginRequest += MvcApplication_BeginRequest;
        }

        void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            string cultureName = Request["cultureName"];
            if (string.IsNullOrEmpty(cultureName))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("zh-TW");
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
                return;
            }
            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);

            if (cultureName.StartsWith("en-"))
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            else
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(cultureName);
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cultureName);
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DefaultModelBinder.ResourceClassKey = "Resources";
            ClientDataTypeModelValidatorProvider.ResourceClassKey = "Resources";

            //以下的用法可以讓每個驗證屬性不用去指定ResourceType，但這是全域性的設定無法個別設定
            //PropertyValueRequired需另外設定
            //  http://stackoverflow.com/questions/12545176/mvc-4-ignores-defaultmodelbinder-resourceclasskey/12545997
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredAttribute), typeof(LocalizedRequiredAttributeAdapter));

            //faild
            //http://blog.gauffin.org/2012/10/how-to-dynamically-modify-model-meta-data-in-asp-net-mvc/
            //ModelValidatorProviders.Providers.RemoveAt(0);
            //ModelValidatorProviders.Providers.Add(new LocalizedModelValidatorProvider());




        }


    }
}
