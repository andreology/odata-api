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
    public class FnmaSystemController : ODataController {
        private readonly FnmaSystemDbContext _fnmaSystemDbContext;

        public FnmaSystemController(FnmaSystemDbContext fnmaSystemDbContext) {
            _fnmaSystemDbContext = fnmaSystemDbContext ?? throw new ArgumentNullException(nameof(fnmaSystemDbContext));
        }

        [EnableQuery(MaxExpansionDepth = 3, MaxSkip = 10, MaxTop = 5, PageSize = 4)]
        public IActionResult Get() {
            return Ok( _fnmaSystemDbContext.Systems);
        }

        [HttpGet]
        [ODataRoute("FnmaSystem({key})")]
        public IActionResult Get(int key) {
            var system = _fnmaSystemDbContext.Systems.Where( p => p.FnmaSystemId == key);

            if(!system.Any()) {
                return NotFound();
            }

            return Ok(system);
        }

         [HttpGet]
        [ODataRoute("FnmaSystem({key})/OwnerFirstName")]
        [ODataRoute("FnmaSystem({key})/OwnerLastName")]
        [ODataRoute("FnmaSystem({key})/DateCreated")]
        public IActionResult GetFnmaSystemProperty(int key)
        {
            var system = _fnmaSystemDbContext.Systems
                .FirstOrDefault(p => p.FnmaSystemId == key);

            if (system == null)
            {
                return NotFound();
            }

            var propertyToGet = new Uri(HttpContext.Request.GetEncodedUrl()).Segments.Last(); //extensions method on uri

            if (!system.HasProperty(propertyToGet))
            {
                return NotFound();
            }

            var propertyValue = system.GetValue(propertyToGet);

            if (propertyValue == null)
            {
                // null = no content
                return NoContent();
            }

            return Ok(propertyValue);
        }

         [HttpGet]
        [ODataRoute("FnmaSystem({key})/OwnerFirstName/$value")]
        [ODataRoute("FnmaSystem({key})/OwnerLastName/$value")]
        [ODataRoute("FnmaSystem({key})/DateCreated/$value")]
        public IActionResult GetFnmaSystemPropertyRawValue(int key)
        {
            var system = _fnmaSystemDbContext.Systems
              .FirstOrDefault(p => p.FnmaSystemId == key);

            if (system == null)
            {
                return NotFound();
            }

            var url = HttpContext.Request.GetEncodedUrl();
            var propertyToGet = new Uri(url).Segments[^2].TrimEnd('/');

            if (!system.HasProperty(propertyToGet))
            {
                return NotFound();
            }

            var propertyValue = system.GetValue(propertyToGet);

            if (propertyValue == null)
            {
                // null = no content
                return NoContent();
            }

            return Ok(propertyValue.ToString());
        }

        //create resource method 
        [HttpPost]
        [ODataRoute("FnmaSystem")]
        public IActionResult CreateFnmaSystem([FromBody] FnmaSystem system) //full update
        {
            if (!ModelState.IsValid) //check if client input is valid 
            {
                return BadRequest(ModelState);
            }

            // add the system to the system collection
            _fnmaSystemDbContext.Systems.Add(system);
            _fnmaSystemDbContext.SaveChanges();

            // return the created system 
            return Created(system);
        }

         [HttpPut]
        [ODataRoute("FnmaSystem({key})")]
        public IActionResult UpdateFnmaSystem(int key, [FromBody] FnmaSystem system)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentSystem = _fnmaSystemDbContext.Systems
                .FirstOrDefault(p => p.FnmaSystemId == key);

            if (currentSystem == null)
            {
                return NotFound();
            }

            system.FnmaSystemId = currentSystem.FnmaSystemId;
            _fnmaSystemDbContext.Entry(currentSystem).CurrentValues.SetValues(system);
            _fnmaSystemDbContext.SaveChanges();

            return NoContent();
        }
        [HttpPatch]
        [ODataRoute("FnmaSystem({key})")]
        public IActionResult PartiallyUpdateFnmaSystem(int key, [FromBody] Delta<FnmaSystem> patch) //delta is used to track changes to an entity type
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentSystem = _fnmaSystemDbContext.Systems
                .FirstOrDefault(p => p.FnmaSystemId == key);

            if (currentSystem == null)
            {
                return NotFound();
            }

            patch.Patch(currentSystem); //apply the change set
            _fnmaSystemDbContext.SaveChanges();
            return NoContent();
        }
    }
}