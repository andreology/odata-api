using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.OData.Builder;

namespace odata_poc.Entities {
     public class Loan {
        [Key]
        public int LoanNumber {get; set;}

        [Required]
        public int LoanAmount{get; set;}

        [Required]
        [StringLength(50)]
        public string  GreenFinanceType {get; set;}
         
        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset SubmittedDate { get; set; }

        [Required]
        [ForeignKey("Account")]
        public int SellerNumber{get; set;}
     }
}