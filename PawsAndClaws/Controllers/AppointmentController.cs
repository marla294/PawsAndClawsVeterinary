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
            var model = new AppointmentModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AppointmentModel model)
        {
            model = AppointmentLogic.AddOrEditAppointment(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int appointmentId)
        {
            AppointmentModel model = AppointmentLogic.GetAppointmentModelById(appointmentId);

            return View(model);
        }
    }
}