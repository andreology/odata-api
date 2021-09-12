using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.OData.Builder;
using System.ComponentModel.DataAnnotations.Schema;

namespace odata_poc.Entities {
     public class Property {
        [Key]
        public int PropertyId {get; set;}

         
        [Required]
        [StringLength(50)]
        public string Name {get; set;}
         
        [Required]
        [StringLength(50)]
        public string Street {get; set;}
         
        [Required]
        [StringLength(50)]
        public string City {get; set;}

        [Required]
        [StringLength(50)]
        public string State {get; set;}

        [Required]
        public int PostalCode {get; set;}

        [Required]
        [ForeignKey("Loan")]
        public int LoanNumber{get; set;}
         
     }
}