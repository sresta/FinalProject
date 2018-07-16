using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrphanageFinalEntity.Models
{
    public class AdoptionRequest           
    {
        public int Id { get; set; }
        public User User { get; set; }
        [DisplayName("Your account Id")]
        public int UserId { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Married { get; set; }      
        [Required]  
        public string Profession { get; set; }
        [DisplayName("Monthly Income")]
        [Required]
        public int MonthlyIncome { get; set; }
        [DisplayName("Please specify the reason for adoption")]
        [Required]
        public string ReasonOfAdoption { get; set; }
        [DisplayName("Do you have any other child?")]
        [Required]
        public bool IfAnyChild { get; set; }

    }
  
}