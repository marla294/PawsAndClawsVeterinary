using PawsAndClaws.Data;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "First Name: ")]
        public string First { get; set; }
        [Display(Name = "Last Name: ")]
        public string Last { get; set; }
        [Display(Name = "Phone Number: ")]
        public string Phone { get; set; }
        [Display(Name = "Address: ")]
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
