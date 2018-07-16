using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrphanageFinalEntity.Models
{
    public enum PaymentType
    {
        Cash,
        CreditCard,
        Cheque
    }
    public class SponsorDetail
    {
        public int Id { get; set; }
        public Orphan Orphan { get; set; }
        [DisplayName("Orphan Id")]
        public int OrphanId  { get; set; }
        public User User { get; set; }
        [DisplayName("User Id")]
        public int UserId { get; set; }
        [DisplayName("Payment type")]
        public PaymentType PaymentType{ get; set; }
        public int Amount { get; set; }
        public int PaymentNo { get; set; }
        [DisplayName("Date of payment")]
        public DateTime DateOfReceipt { get; set; }
    }
   
}