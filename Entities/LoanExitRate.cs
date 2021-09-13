using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.OData.Builder;

namespace odata_poc.Entities {
     public class LoanExitRate {
        [Key]
        public int MsaCode {get; set;}

        [Required]
        public double OneYrProjectedGrowthRate{get; set;}

        [Required] 
        public double TwoYrProjectedGrowthRate {get; set;}
         
        [Required] 
        public double ThirdYrProjectedGrowthRate {get; set;}

        [Required] 
        public double ForthYrProjectedGrowthRate {get; set;}

        [Required] 
        public double FifthYrProjectedGrowthRate {get; set;}
     }
}