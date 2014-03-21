using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace WindowsAzureConference.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            string strMessageToShow = "Windows Azure Conference 2014";
            ViewBag.Message = strMessageToShow;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Microsoft Corporation";

            return View();
        }

        public ActionResult PageTrace()
        {
            Trace.TraceInformation("Inside the PageTrace MVC controller");
            ViewBag.Message = "A Simple Page that shows how to trace in Windows Azure Web Sites";

            try
            {
                Trace.TraceInformation("Going to open a database connection");
                SqlConnection conn = new SqlConnection();
                conn.Open();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception {0} with StackTrace {1}", ex.Message, ex.StackTrace);
            }

            

            return View();
        }

        public ActionResult LeakMemory()
        {
            var list = new List<byte[]>();
            for (int i = 0; i < 20000; i++)            
            {
                byte[] someBytes = new byte[10240];
                byte[] someBytes2 = new byte[10240];
                list.Add(someBytes); // Change the size here.               
                list.Add(someBytes2); // Change the size here.               
            }

            System.Web.HttpContext.Current.Cache.Insert("myList", list);



            return View();
        }
    }
}
