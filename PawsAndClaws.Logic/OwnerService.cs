using PawsAndClaws.Data;
using PawsAndClaws.Models;
using System.Linq;

namespace PawsAndClaws.Logic
{
    public class OwnerService
    {
        public OwnerModel AddOrEditOwner(OwnerModel model)
        {
            Owner owner = new Owner();

            using (var db = new PawsAndClawsEntities())
            {
                owner = db.Owners.Where(i => i.OwnerId == model.OwnerId).FirstOrDefault();

                if (owner != null)
                {
                    owner.First = model.First;
                    owner.Last = model.Last;
                    owner.Phone = model.Phone;
                    owner.Address = model.Address;
                }
                else
                {
                    owner = db.Owners.Add(model.ToDTO());
                }

                db.SaveChanges();
            }

            return new OwnerModel(owner);
        }
    }
}
