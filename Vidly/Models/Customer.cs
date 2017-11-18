using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Videosity.Models {
    public class Customer {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool isSubscribed { get; set; }
        // Navigation property
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}