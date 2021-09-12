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
    public class LoanController : ODataController {
        private readonly FnmaSystemDbContext _fnmaSystemDbContext;

        public LoanController(FnmaSystemDbContext fnmaSystemDbContext) {
            _fnmaSystemDbContext = fnmaSystemDbContext ?? throw new ArgumentNullException(nameof(fnmaSystemDbContext));
        }

        [EnableQuery(MaxExpansionDepth = 3, MaxSkip = 10, MaxTop = 5, PageSize = 4)]
        public IActionResult Get() {
            return Ok( _fnmaSystemDbContext.Loans);
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("Loan({key})")]
        public IActionResult Get(int key) {
            var loan = _fnmaSystemDbContext.Loans.Where( p => p.LoanNumber == key);

            if(!loan.Any()) {
                return NotFound();
            }

            return Ok(SingleResult.Create(loan));
        }

         [HttpGet]
        [ODataRoute("Loan({key})/LoanNumber")]
        [ODataRoute("Loan({key})/LoanAmount")]
        [ODataRoute("Loan({key})/GreenFinanceType")]
        [ODataRoute("Loan({key})/SubmittedDate")]
        [ODataRoute("Loan({key})/SellerNumber")]
        public IActionResult GetLoanProperty(int key)
        {
            var loan = _fnmaSystemDbContext.Loans
                .FirstOrDefault(p => p.LoanNumber == key);

            if (loan == null)
            {
                return NotFound();
            }

            var propertyToGet = new Uri(HttpContext.Request.GetEncodedUrl()).Segments.Last(); //extensions method on uri

            if (!loan.HasProperty(propertyToGet))
            {
                return NotFound();
            }

            var propertyValue = loan.GetValue(propertyToGet);

            if (propertyValue == null)
            {
                // null = no content
                return NoContent();
            }

            return Ok(propertyValue);
        }

         [HttpGet]
        [ODataRoute("Loan({key})/LoanNumber/$value")]
        [ODataRoute("Loan({key})/LoanAmount/$value")]
        [ODataRoute("Loan({key})/GreenFinanceType/$value")]
        [ODataRoute("Loan({key})/SubmittedDate/$value")]
        [ODataRoute("Loan({key})/SellerNumber/$value")]
        public IActionResult GetLoanPropertyRawValue(int key)
        {
            var loan = _fnmaSystemDbContext.Loans
              .FirstOrDefault(p => p.LoanNumber == key);

            if (loan == null)
            {
                return NotFound();
            }

            var url = HttpContext.Request.GetEncodedUrl();
            var propertyToGet = new Uri(url).Segments[^2].TrimEnd('/');

            if (!loan.HasProperty(propertyToGet))
            {
                return NotFound();
            }

            var propertyValue = loan.GetValue(propertyToGet);

            if (propertyValue == null)
            {
                // null = no content
                return NoContent();
            }

            return Ok(propertyValue.ToString());
        }

        //create resource method 
        [HttpPost]
        [ODataRoute("Loan")]
        public IActionResult CreateLoan([FromBody] Loan loan) //full update
        {
            if (!ModelState.IsValid) //check if client input is valid 
            {
                return BadRequest(ModelState);
            }

            // add the loan to the loan collection
            _fnmaSystemDbContext.Loans.Add(loan);
            _fnmaSystemDbContext.SaveChanges();

            // return the created loan 
            return Created(loan);
        }

         [HttpPut]
        [ODataRoute("Loan({key})")]
        public IActionResult UpdateLoan(int key, [FromBody] Loan loan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentProperty = _fnmaSystemDbContext.Loans
                .FirstOrDefault(p => p.LoanNumber == key);

            if (currentProperty == null)
            {
                return NotFound();
            }

            loan.LoanNumber = currentProperty.LoanNumber;
            _fnmaSystemDbContext.Entry(currentProperty).CurrentValues.SetValues(loan);
            _fnmaSystemDbContext.SaveChanges();

            return NoContent();
        }
        [HttpPatch]
        [ODataRoute("Loan({key})")]
        public IActionResult PartiallyUpdateLoan (int key, [FromBody] Delta<Loan> patch) //delta is used to track changes to an entity type
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentProperty = _fnmaSystemDbContext.Loans
                .FirstOrDefault(p => p.LoanNumber == key);

            if (currentProperty == null)
            {
                return NotFound();
            }

            patch.Patch(currentProperty); //apply the change set
            _fnmaSystemDbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [ODataRoute("Loan({key})")]
        public IActionResult DeleteLoan(int key)
        {
            var currentProperty = _fnmaSystemDbContext.Loans
                .FirstOrDefault(p => p.LoanNumber == key);

            if (currentProperty == null)
            {
                return NotFound();
            }

            _fnmaSystemDbContext.Loans.Remove(currentProperty);
            _fnmaSystemDbContext.SaveChanges();
            return NoContent();
        }
    }
}