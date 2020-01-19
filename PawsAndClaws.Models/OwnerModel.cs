using PawsAndClaws.Data;

namespace PawsAndClaws.Models
{
    public class OwnerModel
    {
        public OwnerModel(Owner owner)
        {
            OwnerId = owner.OwnerId;
            First = owner.First;
            Last = owner.Last;
            Phone = owner.Phone;
            Address = owner.Address;
        }

        public int OwnerId { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Owner ToDTO()
        {
            return new Owner() {
                OwnerId = OwnerId,
                First = First,
                Last = Last,
                Phone = Phone,
                Address = Address
            };
            
        }
    }
}
