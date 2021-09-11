using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.OData.Builder;

namespace odata_poc.Entities {
     public class Property {
         [Key]
         public int PropertyId {get; set;}

         [Required]
         [StringLength(50)]
         public string Street {get; set;}
         
         [Required]
         [StringLength(50)]
         public string City {get; set;}

         [Required]
         public int Zip {get; set;}

         [Required]
         public int Price {get; set;}

         [Required]
         public int LoanNumber{get; set;}
         
     }
}