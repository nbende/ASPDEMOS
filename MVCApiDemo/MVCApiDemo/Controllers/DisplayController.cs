using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApiDemo.Controllers
{
    public class DisplayController : Controller
    {
        //
        // GET: /Display/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddJobs()
        {
            return View();
        }
	}
}