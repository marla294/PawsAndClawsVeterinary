using PawsAndClaws.Data;

namespace PawsAndClaws.Logic
{
    public class PetService
    {
        public void AddPet()
        {
            using (var db = new PawsAndClawsEntities())
            {
                db.Pets.Add(new Pet() { PetName = "Fluffy", Type = "Cat" });
                db.SaveChanges();
            }
        }
    }
}
