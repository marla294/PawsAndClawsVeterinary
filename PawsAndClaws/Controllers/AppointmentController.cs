﻿using PawsAndClaws.Logic;
using PawsAndClaws.Models;
using System.Web.Mvc;

namespace PawsAndClaws.Controllers
{
    public class AppointmentController : Controller
    {
        public ActionResult Index()
        {
            var logic = new AppointmentService();
            var model = logic.PopulateAppointmentsViewModel();

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new AppointmentModel();

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}