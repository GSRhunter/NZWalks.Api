using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{   

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "shankar", "raju", "venkatesh" };

            return Ok(studentNames);    


        }

    }
}
