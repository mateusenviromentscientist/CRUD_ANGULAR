using System;
using Microsoft.AspNetCore.Mvc;

namespace PlayerStats_WebAPI{


    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController: ControllerBase {
         
         
        [HttpGet]
        public IActionResult Get(){
            try
            {
                return Ok("");
            }
            catch (Exception ex)
            {
            return BadRequest($"Erro: {ex.Message}");
            }
            
        }

    }
}