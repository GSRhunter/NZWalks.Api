using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }  
        [HttpGet ]
        public IActionResult GetAll()
        {

         var region=   dbContext.Regions.ToList();
            return Ok(region);  


        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var regions = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(regions == null)
            {
                return NotFound();

            }
            return Ok(regions);
        }

    }
}
