using Microsoft.AspNetCore.Mvc;

namespace PlayerStats_WebAPI{


    [ApiController]
    [Route("api/[controller]")]
    public class StatsController: ControllerBase {

        [HttpGet]
        public IActionResult Get(){
            return Ok("Messi");
        }

    }
}