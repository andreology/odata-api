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
    public class PropertyController : ODataController {
        private readonly FnmaSystemDbContext _fnmaSystemDbContext;

        public PropertyController(FnmaSystemDbContext fnmaSystemDbContext) {
            _fnmaSystemDbContext = fnmaSystemDbContext ?? throw new ArgumentNullException(nameof(fnmaSystemDbContext));
        }

        [EnableQuery(MaxExpansionDepth = 3, MaxSkip = 49995, MaxTop = 5, PageSize = 4)]
        public IActionResult Get() {
            return Ok( _fnmaSystemDbContext.Properties);
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("Property({key})")]
        public IActionResult Get(int key) {
            var property = _fnmaSystemDbContext.Properties.Where( p => p.PropertyId == key);

            if(!property.Any()) {
                return NotFound();
            }

            return Ok(SingleResult.Create(property));
        }

         [HttpGet]
         [ODataRoute("Property({key})/PropertyId")]
        [ODataRoute("Property({key})/Name")]
        [ODataRoute("Property({key})/Street")]
        [ODataRoute("Property({key})/City")]
        [ODataRoute("Property({key})/State")]
        [ODataRoute("Property({key})/PostalCode")]
        [ODataRoute("Property({key})/LoanNumber")]
        public IActionResult GetAccountProperty(int key)
        {
            var property = _fnmaSystemDbContext.Properties
                .FirstOrDefault(p => p.PropertyId == key);

            if (property == null)
            {
                return NotFound();
            }

            var propertyToGet = new Uri(HttpContext.Request.GetEncodedUrl()).Segments.Last(); //extensions method on uri

            if (!property.HasProperty(propertyToGet))
            {
                return NotFound();
            }

            var propertyValue = property.GetValue(propertyToGet);

            if (propertyValue == null)
            {
                // null = no content
                return NoContent();
            }

            return Ok(propertyValue);
        }

         [HttpGet]
        [ODataRoute("Property({key})/PropertyId/$value")] 
        [ODataRoute("Property({key})/Name/$value")] 
        [ODataRoute("Property({key})/Street/$value")]
        [ODataRoute("Property({key})/City/$value")]
        [ODataRoute("Property({key})/PostalCode/$value")]
        [ODataRoute("Property({key})/State/$value")]
        [ODataRoute("Property({key})/LoanNumber/$value")]
        public IActionResult GetPropertyPropertyRawValue(int key)
        {
            var property = _fnmaSystemDbContext.Properties
              .FirstOrDefault(p => p.PropertyId == key);

            if (property == null)
            {
                return NotFound();
            }

            var url = HttpContext.Request.GetEncodedUrl();
            var propertyToGet = new Uri(url).Segments[^2].TrimEnd('/');

            if (!property.HasProperty(propertyToGet))
            {
                return NotFound();
            }

            var propertyValue = property.GetValue(propertyToGet);

            if (propertyValue == null)
            {
                // null = no content
                return NoContent();
            }

            return Ok(propertyValue.ToString());
        }

        //create resource method 
        [HttpPost]
        [ODataRoute("Property")]
        public IActionResult CreateProperty([FromBody] Property property) //full update
        {
            if (!ModelState.IsValid) //check if client input is valid 
            {
                return BadRequest(ModelState);
            }

            // add the property to the property collection
            _fnmaSystemDbContext.Properties.Add(property);
            _fnmaSystemDbContext.SaveChanges();

            // return the created property 
            return Created(property);
        }

         [HttpPut]
        [ODataRoute("Property({key})")]
        public IActionResult UpdateProperty(int key, [FromBody] Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentProperty = _fnmaSystemDbContext.Properties
                .FirstOrDefault(p => p.PropertyId == key);

            if (currentProperty == null)
            {
                return NotFound();
            }

            property.PropertyId = currentProperty.PropertyId;
            _fnmaSystemDbContext.Entry(currentProperty).CurrentValues.SetValues(property);
            _fnmaSystemDbContext.SaveChanges();

            return NoContent();
        }
        [HttpPatch]
        [ODataRoute("Property({key})")]
        public IActionResult PartiallyUpdateProperty(int key, [FromBody] Delta<Property> patch) //delta is used to track changes to an entity type
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentProperty = _fnmaSystemDbContext.Properties
                .FirstOrDefault(p => p.PropertyId == key);

            if (currentProperty == null)
            {
                return NotFound();
            }

            patch.Patch(currentProperty); //apply the change set
            _fnmaSystemDbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [ODataRoute("Property({key})")]
        public IActionResult DeleteProperty(int key)
        {
            var currentProperty = _fnmaSystemDbContext.Properties
                .FirstOrDefault(p => p.PropertyId == key);

            if (currentProperty == null)
            {
                return NotFound();
            }

            _fnmaSystemDbContext.Properties.Remove(currentProperty);
            _fnmaSystemDbContext.SaveChanges();
            return NoContent();
        }
    }
}