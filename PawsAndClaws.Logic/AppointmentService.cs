using PawsAndClaws.Models;
using PawsAndClaws.Data;
using System.Linq;

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

        public AppointmentModel CreateNewAppointment(AppointmentModel model)
        {
            return model;
        }

        public AppointmentModel AddOrEditAppointment(AppointmentModel model)
        {
            PetService petLogic = new PetService();
            petLogic.AddOrEditPet(model.Pet);

            Appointment appointment = new Appointment();

            using (var db = new PawsAndClawsEntities())
            {
                appointment = db.Appointments.Where(i => i.AppointmentId == model.AppointmentId).FirstOrDefault();

                if (appointment != null)
                {
                    appointment = model.ToDTO();
                }
                else
                {
                    appointment = db.Appointments.Add(model.ToDTO());
                }

                db.SaveChanges();
            }

            return new AppointmentModel(appointment);
        }
    }
}
