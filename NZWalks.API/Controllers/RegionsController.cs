using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        [HttpGet ]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            { new  Region
            {   Id = Guid.NewGuid(),
                Name = "Auckland region",
                Code = "AKL",
                RegionImageUrl = "https://www.pexels.com/photo/green-trees-under-white-sky-2790395/"
            },
            new  Region
            {   Id = Guid.NewGuid(),
                Name = "Newk region",
                Code = "NKR",
                RegionImageUrl = "https://www.pexels.com/photo/green-trees-under-white-sky-2790395/"
            },
            };
            return Ok(regions);

        }

    }
}
