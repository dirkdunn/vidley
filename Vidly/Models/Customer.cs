using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        // Navigation property, allows us to navigate from one model type to another (load a customer and its membership type together)
        public MembershipType MembershipType { get; set; }
        // Entity recognizes this convention and will automatically use MembershipTypeId as a foreign key.
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }
    }
}