using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WindowsAzureConference.Controllers
{
    public class SlowPageController : Controller
    {
        //
        // GET: /SlowPage/
        public ActionResult Index()
        {
            return View();
        }
	}
}