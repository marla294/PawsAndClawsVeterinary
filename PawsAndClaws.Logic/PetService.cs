using PawsAndClaws.Data;
using PawsAndClaws.Models;
using System.Linq;

namespace PawsAndClaws.Logic
{
    public class PetService
    {
        public PetModel AddOrEditPet(PetModel model)
        {
            OwnerService ownerLogic = new OwnerService();
            ownerLogic.AddOrEditOwner(model.Owner);

            Pet pet = new Pet();

            using (var db = new PawsAndClawsEntities())
            {
                pet = db.Pets.Where(i => i.PetId == model.PetId).FirstOrDefault();

                if (pet != null)
                {
                    pet = model.ToDTO();
                }
                else
                {
                    pet = db.Pets.Add(model.ToDTO());
                }

                db.SaveChanges();
            }

            return new PetModel(pet);
        }
    }
}
