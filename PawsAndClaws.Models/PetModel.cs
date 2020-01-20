using PawsAndClaws.Data;
using System.ComponentModel.DataAnnotations;

namespace PawsAndClaws.Models
{
    public class PetModel
    {
        public PetModel()
        {
            PetId = 0;
            PetName = null;
            Type = null;
            OwnerId = 0;
        }

        public PetModel(Pet pet)
        {
            PetId = pet.PetId;
            PetName = pet.PetName;
            Type = pet.Type;
            OwnerId = pet.OwnerId;
        }

        public int PetId { get; set; }
        [Display(Name = "Pet Name: ")]
        public string PetName { get; set; }
        [Display(Name = "Pet Type: ")]
        public string Type { get; set; }
        public int OwnerId { get; set; }

        public Pet ToDTO()
        {
            return new Pet() 
            { 
                PetId = PetId,
                PetName = PetName,
                Type = Type,
                OwnerId = OwnerId
            };
        }
    }
}
