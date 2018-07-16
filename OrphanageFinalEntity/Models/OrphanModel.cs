using OrphanageFinalEntity.Controllers;
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrphanageFinalEntity.Models
{
    public class Orphan
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool Disable { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public Supervisor Supervisor { get; set; }
        public string SupervisorName { get; set; }
        public string Picture { get; set; }
       

    }
    public  partial class OrphanViewModel
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public bool Disable { get; set; }
        [Required]
        [DisplayName("Supervisor Name")]
        public string SupervisorName { get; set; }
        [DisplayName("Select the child")]
        public string Picture { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
    public class OrphanBackground
    {
        public int Id { get; set; }
        public Orphan Orphan { get; set; }
        public int OrphanId { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Relative { get; set; }
        public string AddressDetail { get; set; }
        public string ContactNo { get; set; }
        public string BoardedDetail { get; set; }
      
    }
    public class OrphanBackgroundView
    {        
        [Required]
        public int OrphanId { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required]
        public string Relative { get; set; }
        public string AddressDetail { get; set; }
        public string ContactNo { get; set; }
        public string BoardedDetail { get; set; }

    }
}