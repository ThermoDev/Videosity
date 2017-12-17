using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Videosity.Models;

namespace Videosity.DTO {
    public class CustomerDTO {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Customer Name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }
        
        //[Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
        
        public byte MembershipTypeId { get; set; }
    }
}