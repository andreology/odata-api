using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.OData.Builder;

namespace odata_poc.Entities {
     public class FnmaSystem {
         [Key]
         public int FnmaSystemId {get; set;}

         [Required]
         [StringLength(50)]
         public string OwnerFirstName {get; set;}
         
         [Required]
         [StringLength(50)]
         public string OwnerLastName {get; set;}

         [Required]
         [DataType(DataType.Date)]
         public DateTimeOffset DateCreated {get; set;}

        [Contained]
         public ICollection<SystemInterface> SystemInterface {get; set;} = new List<SystemInterface>();
         
     }
}