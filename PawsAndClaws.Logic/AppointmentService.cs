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
                    model.Appointments.Add(new AppointmentViewModel()
                    {
                        AppointmentId = appointment.AppointmentId,
                        AppointmentDate = appointment.AppointmentDate,
                        AppointmentReason = appointment.AppointmentReason,
                        PetName = appointment.Pet.PetName
                    });
                }
            }

            return model;
        }

        public AppointmentModel AddOrEditAppointment(AppointmentViewModel model)
        {
            PetModel petModel = new PetModel()
            {
                PetId = model.PetId,
                PetName = model.PetName,
                Type = model.Type,
                OwnerId = model.OwnerId
            };

            OwnerModel ownerModel = new OwnerModel()
            {
                OwnerId = model.OwnerId,
                First = model.First,
                Last = model.Last,
                Phone = model.Phone,
                Address = model.Address
            };

            AppointmentModel appointmentModel = new AppointmentModel()
            {
                AppointmentId = model.AppointmentId,
                PetId = model.PetId,
                AppointmentDate = model.AppointmentDate,
                AppointmentReason = model.AppointmentReason
            };

            PetService petLogic = new PetService();
            var pet = petLogic.AddOrEditPet(petModel, ownerModel);

            Appointment appointment = new Appointment();

            using (var db = new PawsAndClawsEntities())
            {
                appointment = db.Appointments.Where(i => i.AppointmentId == model.AppointmentId).FirstOrDefault();

                if (appointment != null)
                {
                    appointment.AppointmentDate = model.AppointmentDate;
                    appointment.AppointmentReason = model.AppointmentReason;
                    appointment.PetId = model.PetId;
                }
                else
                {
                    appointmentModel.PetId = pet.PetId;
                    appointment = db.Appointments.Add(appointmentModel.ToDTO());
                }

                db.SaveChanges();
            }

            return appointmentModel;
        }

        public AppointmentViewModel GetAppointmentViewModelById(int appointmentId)
        {
            Appointment appointment = new Appointment();
            Pet pet = new Pet();
            Owner owner = new Owner();

            using (var db = new PawsAndClawsEntities())
            {
                appointment = db.Appointments.Where(i => i.AppointmentId == appointmentId).FirstOrDefault();
                pet = db.Pets.Where(i => i.PetId == appointment.PetId).FirstOrDefault();
                owner = db.Owners.Where(i => i.OwnerId == pet.OwnerId).FirstOrDefault();

                if (appointment == null)
                {
                    return new AppointmentViewModel();
                }

                return new AppointmentViewModel() { 
                    AppointmentId = appointment.AppointmentId,
                    AppointmentDate = appointment.AppointmentDate,
                    AppointmentReason = appointment.AppointmentReason,
                    PetId = appointment.PetId,
                    PetName = pet.PetName,
                    Type = pet.Type,
                    OwnerId = pet.OwnerId,
                    First = owner.First,
                    Last = owner.Last,
                    Address = owner.Address,
                    Phone = owner.Phone
                };
            }

        }

        public AppointmentModel DeleteAppointmentById(int appointmentId)
        {
            Appointment appointment = new Appointment();

            using (var db = new PawsAndClawsEntities())
            {
                appointment = db.Appointments.Where(i => i.AppointmentId == appointmentId).FirstOrDefault();

                db.Appointments.Remove(appointment);

                db.SaveChanges();
            }

            return new AppointmentModel(appointment); ;
        }
    }
}
