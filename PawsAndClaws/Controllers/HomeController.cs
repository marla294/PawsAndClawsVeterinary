﻿using PawsAndClaws.Logic;
using System.Web.Mvc;

namespace PawsAndClaws.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var logic = new AppointmentService();
            var model = logic.PopulateAppointmentsViewModel();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}