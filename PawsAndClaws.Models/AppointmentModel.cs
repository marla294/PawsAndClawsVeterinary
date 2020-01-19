using System;
using PawsAndClaws.Data;
using System.ComponentModel.DataAnnotations;

namespace PawsAndClaws.Models
{
    public class AppointmentModel
    {
        public AppointmentModel()
        {
            
        }

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
        [Display(Name = "Date of appointment: ")]
        public DateTime? AppointmentDate { get; set; }
        [Display(Name = "Reason for appointment: ")]
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
