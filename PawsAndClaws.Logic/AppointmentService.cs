using PawsAndClaws.Models;
using PawsAndClaws.Data;

namespace PawsAndClaws.Logic
{
    public class AppointmentService
    {
        public AppointmentsViewModel PopulateAppointmentsViewModel()
        {
            AppointmentsViewModel model = new AppointmentsViewModel();

            using (var db = new PawsAndClawsEntities())
            {
                foreach (var appointment in db.Appointments)
                {
                    model.Appointments.Add(new AppointmentModel(appointment));
                }
            }

            return model;
        }
    }
}
