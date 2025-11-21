using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

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
            //Get data from database -domain model
         var regionsDomaion=   dbContext.Regions.ToList();

            //Map Domain model to DTOs
            var regionDto = new List<RegionDto>();
            foreach (var regionDmn in regionsDomaion)
                regionDto.Add(new RegionDto()
                {
                    Id = regionDmn.Id,
                    Name = regionDmn.Name,
                    Code = regionDmn.Code,
                    RegionImageUrl = regionDmn.RegionImageUrl,
                });

           


            //Return DTos 
            return Ok(regionDto);  


        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(regionDomain == null)
            {
                return NotFound();

            }

            var regionDto = new RegionDto()
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl,


            };
            return Ok(regionDto);
        }

        //Post to create new Region 
        [HttpPost]
       public IActionResult Create([FromBody] AddRegionRquestDto addRegionRquestDto)

        {
            var regionDomainModel = new Region
            {
                Code = addRegionRquestDto.Code,
                Name = addRegionRquestDto.Name,
                RegionImageUrl = addRegionRquestDto.RegionImageUrl,
            };

            dbContext.Regions.Add(regionDomainModel);   
            dbContext.SaveChanges();
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };
            return CreatedAtAction(nameof(GetById),new {id=regionDto.Id},regionDto);


        }

    }
}
