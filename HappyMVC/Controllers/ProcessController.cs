using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyMVC.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        public ActionResult Index()
        {
            var processes = System.Diagnostics.Process.GetProcesses();
            ViewBag.Foo = processes;
            return View();
        }

        public ActionResult Concrete()
        {
            var processes = System.Diagnostics.Process.GetProcesses();
            return View(processes);
        }

        public ActionResult Details(int id)
        {
            var processes = System.Diagnostics.Process.GetProcessById(id);
            return View(processes);
        }
    }
}