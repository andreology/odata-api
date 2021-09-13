using System;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using odata_poc.DbContexts;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using odata_poc.Helpers;
using odata_poc.Entities;

namespace odata_poc.Controllers {
    public class LoanExitRateController : ODataController {
        private readonly FnmaSystemDbContext _fnmaSystemDbContext;

        public LoanExitRateController(FnmaSystemDbContext fnmaSystemDbContext) {
            _fnmaSystemDbContext = fnmaSystemDbContext ?? throw new ArgumentNullException(nameof(fnmaSystemDbContext));
        }

        [EnableQuery(MaxExpansionDepth = 3, MaxSkip = 10, MaxTop = 5, PageSize = 4)]
        public IActionResult Get() {
            return Ok( _fnmaSystemDbContext.LoanExitRates);
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("LoanExitRate({key})")]
        public IActionResult Get(int key) {
            var loanexitrate = _fnmaSystemDbContext.LoanExitRates.Where( p => p.MsaCode == key);

            if(!loanexitrate.Any()) {
                return NotFound();
            }

            return Ok(SingleResult.Create(loanexitrate));
        }

         [HttpGet]
        [ODataRoute("LoanExitRate({key})/MsaCode")]
        [ODataRoute("LoanExitRate({key})/OneYrProjectedGrowthRate")]
        [ODataRoute("LoanExitRate({key})/TwoYrProjectedGrowthRate")]
        [ODataRoute("LoanExitRate({key})/ThirdYrProjectedGrowthRate")]
        [ODataRoute("LoanExitRate({key})/ForthYrProjectedGrowthRate")]
        [ODataRoute("LoanExitRate({key})/FifthYrProjectedGrowthRate")]
        public IActionResult GetLoanExistRateProperty(int key)
        {
            var loanexitrate = _fnmaSystemDbContext.LoanExitRates
                .FirstOrDefault(p => p.MsaCode == key);

            if (loanexitrate == null)
            {
                return NotFound();
            }

            var propertyToGet = new Uri(HttpContext.Request.GetEncodedUrl()).Segments.Last(); //extensions method on uri

            if (!loanexitrate.HasProperty(propertyToGet))
            {
                return NotFound();
            }

            var propertyValue = loanexitrate.GetValue(propertyToGet);

            if (propertyValue == null)
            {
                // null = no content
                return NoContent();
            }

            return Ok(propertyValue);
        }

         [HttpGet]
        [ODataRoute("LoanExitRate({key})/MsaCode/$value")]
        [ODataRoute("LoanExitRate({key})/OneYrProjectedGrowthRate/$value")]
        [ODataRoute("LoanExitRate({key})/TwoYrProjectedGrowthRate/$value")]
        [ODataRoute("LoanExitRate({key})/ThirdYrProjectedGrowthRate/$value")]
        [ODataRoute("LoanExitRate({key})/ForthYrProjectedGrowthRate/$value")]
        [ODataRoute("LoanExitRate({key})/FifthYrProjectedGrowthRate/$value")]
        public IActionResult GetLoanExistRatePropertyRawValue(int key)
        {
            var loanexitrate = _fnmaSystemDbContext.LoanExitRates
              .FirstOrDefault(p => p.MsaCode == key);

            if (loanexitrate == null)
            {
                return NotFound();
            }

            var url = HttpContext.Request.GetEncodedUrl();
            var propertyToGet = new Uri(url).Segments[^2].TrimEnd('/');

            if (!loanexitrate.HasProperty(propertyToGet))
            {
                return NotFound();
            }

            var propertyValue = loanexitrate.GetValue(propertyToGet);

            if (propertyValue == null)
            {
                // null = no content
                return NoContent();
            }

            return Ok(propertyValue.ToString());
        }

        //create resource method 
        [HttpPost]
        [ODataRoute("LoanExitRate")]
        public IActionResult CreateLoan([FromBody] LoanExitRate loanexitrate) //full update
        {
            if (!ModelState.IsValid) //check if client input is valid 
            {
                return BadRequest(ModelState);
            }

            // add the loanexitrate to the loanexitrate collection
            _fnmaSystemDbContext.LoanExitRates.Add(loanexitrate);
            _fnmaSystemDbContext.SaveChanges();

            // return the created loanexitrate 
            return Created(loanexitrate);
        }

         [HttpPut]
        [ODataRoute("LoanExitRate({key})")]
        public IActionResult UpdateLoanExistRateint (int key, [FromBody] LoanExitRate loanexitrate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentProperty = _fnmaSystemDbContext.LoanExitRates
                .FirstOrDefault(p => p.MsaCode == key);

            if (currentProperty == null)
            {
                return NotFound();
            }

            loanexitrate.MsaCode = currentProperty.MsaCode;
            _fnmaSystemDbContext.Entry(currentProperty).CurrentValues.SetValues(loanexitrate);
            _fnmaSystemDbContext.SaveChanges();

            return NoContent();
        }
        [HttpPatch]
        [ODataRoute("LoanExitRate({key})")]
        public IActionResult PartiallyUpdateLoanExistRate (int key, [FromBody] Delta<LoanExitRate> patch) //delta is used to track changes to an entity type
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentProperty = _fnmaSystemDbContext.LoanExitRates
                .FirstOrDefault(p => p.MsaCode == key);

            if (currentProperty == null)
            {
                return NotFound();
            }

            patch.Patch(currentProperty); //apply the change set
            _fnmaSystemDbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [ODataRoute("LoanExitRate({key})")]
        public IActionResult DeleteLoanExistRate(int key)
        {
            var currentProperty = _fnmaSystemDbContext.LoanExitRates
                .FirstOrDefault(p => p.MsaCode == key);

            if (currentProperty == null)
            {
                return NotFound();
            }

            _fnmaSystemDbContext.LoanExitRates.Remove(currentProperty);
            _fnmaSystemDbContext.SaveChanges();
            return NoContent();
        }
    }
}