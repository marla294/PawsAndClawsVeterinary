using PawsAndClaws.Data;
using PawsAndClaws.Models;
using System.Linq;

namespace PawsAndClaws.Logic
{
    public class PetService
    {
        public PetModel AddOrEditPet(PetModel model, OwnerModel ownerModel)
        {
            OwnerService ownerLogic = new OwnerService();
            var owner = ownerLogic.AddOrEditOwner(ownerModel);

            Pet pet = new Pet();

            using (var db = new PawsAndClawsEntities())
            {
                pet = db.Pets.Where(i => i.PetId == model.PetId).FirstOrDefault();

                if (pet != null)
                {
                    pet.PetName = model.PetName;
                    pet.Type = model.Type;
                    pet.OwnerId = model.OwnerId;
                }
                else
                {
                    model.OwnerId = owner.OwnerId;
                    pet = db.Pets.Add(model.ToDTO());
                }

                db.SaveChanges();
            }

            return new PetModel(pet);
        }

    }
}
