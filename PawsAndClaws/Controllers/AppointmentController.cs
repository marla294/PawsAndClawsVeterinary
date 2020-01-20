using PawsAndClaws.Logic;
using PawsAndClaws.Models;
using System.Web.Mvc;


namespace PawsAndClaws.Controllers
{
    public class AppointmentController : Controller
    {
        public AppointmentService AppointmentLogic { get; set; } = new AppointmentService();

        public ActionResult Index()
        {
            AppointmentsViewModel model = AppointmentLogic.PopulateAppointmentsViewModel();

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new AppointmentViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AppointmentViewModel model)
        {
            AppointmentLogic.AddOrEditAppointment(model);

            return RedirectToAction("Index", "Appointment");
        }

        public ActionResult Edit(int appointmentId)
        {
            AppointmentViewModel model = AppointmentLogic.GetAppointmentViewModelById(appointmentId);

            return View(model);
        }

        public ActionResult Delete(int appointmentId)
        {
            AppointmentLogic.DeleteAppointmentById(appointmentId);

            return RedirectToAction("Index", "Appointment");
        }

    }
}