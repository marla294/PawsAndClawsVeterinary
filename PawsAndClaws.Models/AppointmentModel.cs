using System;
using PawsAndClaws.Data;

namespace PawsAndClaws.Models
{
    public class AppointmentModel
    {
        public AppointmentModel(Appointment appointment)
        {
            AppointmentId = appointment.AppointmentId;
            PetId = appointment.PetId;
            AppointmentDate = appointment.AppointmentDate;
            AppointmentReason = appointment.AppointmentReason;
            Pet = new PetModel(appointment.Pet);
        }

        public int AppointmentId { get; set; }
        public int PetId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string AppointmentReason { get; set; }
        public virtual PetModel Pet { get; set; }

        public Appointment ToDTO()
        {
            return new Appointment()
            {
                AppointmentId = AppointmentId,
                PetId = PetId,
                AppointmentDate = AppointmentDate,
                AppointmentReason = AppointmentReason,
                Pet = Pet.ToDTO()
            };
        }
    }
}
