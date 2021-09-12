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
    public class AccountController : ODataController {
        private readonly FnmaSystemDbContext _fnmaSystemDbContext;

        public AccountController(FnmaSystemDbContext fnmaSystemDbContext) {
            _fnmaSystemDbContext = fnmaSystemDbContext ?? throw new ArgumentNullException(nameof(fnmaSystemDbContext));
        }

        [EnableQuery(MaxExpansionDepth = 3, MaxSkip = 10, MaxTop = 5, PageSize = 4)]
        public IActionResult Get() {
            return Ok( _fnmaSystemDbContext.Accounts);
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("Account({key})")]
        public IActionResult Get(int key) {
            var account = _fnmaSystemDbContext.Accounts.Where( p => p.SellerNumber == key);

            if(!account.Any()) {
                return NotFound();
            }

            return Ok(SingleResult.Create(account));
        }

         [HttpGet]
        [ODataRoute("Account({key})/Name")]
        public IActionResult GetAccountProperty(int key)
        {
            var account = _fnmaSystemDbContext.Accounts
                .FirstOrDefault(p => p.SellerNumber == key);

            if (account == null)
            {
                return NotFound();
            }

            var propertyToGet = new Uri(HttpContext.Request.GetEncodedUrl()).Segments.Last(); //extensions method on uri

            if (!account.HasProperty(propertyToGet))
            {
                return NotFound();
            }

            var propertyValue = account.GetValue(propertyToGet);

            if (propertyValue == null)
            {
                // null = no content
                return NoContent();
            }

            return Ok(propertyValue);
        }

         [HttpGet]
        [ODataRoute("Account({key})/Name/$value")]
        public IActionResult GetAccountPropertyRawValue(int key)
        {
            var account = _fnmaSystemDbContext.Accounts
              .FirstOrDefault(p => p.SellerNumber == key);

            if (account == null)
            {
                return NotFound();
            }

            var url = HttpContext.Request.GetEncodedUrl();
            var propertyToGet = new Uri(url).Segments[^2].TrimEnd('/');

            if (!account.HasProperty(propertyToGet))
            {
                return NotFound();
            }

            var propertyValue = account.GetValue(propertyToGet);

            if (propertyValue == null)
            {
                // null = no content
                return NoContent();
            }

            return Ok(propertyValue.ToString());
        }

        //create resource method 
        [HttpPost]
        [ODataRoute("Account")]
        public IActionResult CreateAccount([FromBody] Account account) //full update
        {
            if (!ModelState.IsValid) //check if client input is valid 
            {
                return BadRequest(ModelState);
            }

            // add the account to the account collection
            _fnmaSystemDbContext.Accounts.Add(account);
            _fnmaSystemDbContext.SaveChanges();

            // return the created account 
            return Created(account);
        }

         [HttpPut]
        [ODataRoute("Account({key})")]
        public IActionResult UpdateAccount(int key, [FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentAccount = _fnmaSystemDbContext.Accounts
                .FirstOrDefault(p => p.SellerNumber == key);

            if (currentAccount == null)
            {
                return NotFound();
            }

            account.SellerNumber = currentAccount.SellerNumber;
            _fnmaSystemDbContext.Entry(currentAccount).CurrentValues.SetValues(account);
            _fnmaSystemDbContext.SaveChanges();

            return NoContent();
        }
        [HttpPatch]
        [ODataRoute("Account({key})")]
        public IActionResult PartiallyUpdateAccount(int key, [FromBody] Delta<Account> patch) //delta is used to track changes to an entity type
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentAccount = _fnmaSystemDbContext.Accounts
                .FirstOrDefault(p => p.SellerNumber == key);

            if (currentAccount == null)
            {
                return NotFound();
            }

            patch.Patch(currentAccount); //apply the change set
            _fnmaSystemDbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [ODataRoute("Account({key})")]
        public IActionResult DeleteAccount(int key)
        {
            var currentAccount = _fnmaSystemDbContext.Accounts
                .FirstOrDefault(p => p.SellerNumber == key);

            if (currentAccount == null)
            {
                return NotFound();
            }

            _fnmaSystemDbContext.Accounts.Remove(currentAccount);
            _fnmaSystemDbContext.SaveChanges();
            return NoContent();
        }
    }
}