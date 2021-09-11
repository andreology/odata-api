using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.OData.Builder;

namespace odata_poc.Entities {
     public class Account {
         [Key]
         public int AccountId {get; set;}

         [Required]
         [StringLength(50)]
         public string Name {get; set;}
         
         [Required]
         public int LoanNumber {get; set;}
         
     }
}