using System;
using PawsAndClaws.Data;


namespace PawsAndClaws.Models
{
    public class AppointmentModel
    {
        public AppointmentModel()
        {
            AppointmentId = 0;
            PetId = 0;
            AppointmentDate = null;
            AppointmentReason = null;
        }

        public AppointmentModel(Appointment appointment)
        {
            AppointmentId = appointment.AppointmentId;
            PetId = appointment.PetId;
            AppointmentDate = appointment.AppointmentDate;
            AppointmentReason = appointment.AppointmentReason;
        }

        public int AppointmentId { get; set; }
        public int PetId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string AppointmentReason { get; set; }

        public Appointment ToDTO()
        {
            return new Appointment()
            {
                AppointmentId = AppointmentId,
                PetId = PetId,
                AppointmentDate = AppointmentDate,
                AppointmentReason = AppointmentReason
            };
        }
    }
}
