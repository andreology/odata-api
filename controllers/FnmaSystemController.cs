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
        public IActionResult GetPersonProperty(int key)
        {
            var system = _fnmaSystemDbContext.Systems
                .FirstOrDefault(p => p.FnmaSystemId == key);

            if (system == null)
            {
                return NotFound();
            }

            var propertyToGet = new Uri(HttpContext.Request.GetEncodedUrl()).Segments.Last();

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
    }
}