using PawsAndClaws.Data;

namespace PawsAndClaws.Models
{
    public class PetModel
    {
        public PetModel(Pet pet)
        {
            PetId = pet.PetId;
            PetName = pet.PetName;
            Type = pet.Type;
            OwnerId = pet.OwnerId;
            Owner = new OwnerModel(pet.Owner);
        }

        public int PetId { get; set; }
        public string PetName { get; set; }
        public string Type { get; set; }
        public int OwnerId { get; set; }
        public virtual OwnerModel Owner { get; set; }

        public Pet ToDTO()
        {
            return new Pet() 
            { 
                PetId = PetId,
                PetName = PetName,
                Type = Type,
                OwnerId = OwnerId,
                Owner = Owner.ToDTO()
            };
        }
    }
}
