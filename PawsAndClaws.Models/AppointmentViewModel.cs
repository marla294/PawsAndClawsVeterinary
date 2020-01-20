using System;
using System.ComponentModel.DataAnnotations;

namespace PawsAndClaws.Models
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }

        public int PetId { get; set; }

        [Display(Name = "Date of appointment: ")]
        public DateTime? AppointmentDate { get; set; }

        [Display(Name = "Reason for appointment: ")]
        public string AppointmentReason { get; set; }

        [Display(Name = "Pet Name: ")]
        public string PetName { get; set; }

        [Display(Name = "Pet Type: ")]
        public string Type { get; set; }

        public int OwnerId { get; set; }

        [Display(Name = "First Name: ")]
        public string First { get; set; }

        [Display(Name = "Last Name: ")]
        public string Last { get; set; }

        [Display(Name = "Phone Number: ")]
        public string Phone { get; set; }

        [Display(Name = "Address: ")]
        public string Address { get; set; }
    }
}
