using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace PlayerStats_WebAPI{


    [ApiController]
    [Route("stats")]
    public class StatsController: ControllerBase {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Stat>>> Get([FromServices] DataContext context)
        {
            var stats = await context.Stats.Include(x=> x.Player).AsNoTracking().ToListAsync();
            return stats;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Stat>>> Get(int id,[FromServices] DataContext context)
        {
            var stats = await context.Stats.Include(x=> x.Player).AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);
            return Ok (stats);
        }

        [HttpGet]
        [Route("stats/{id:int}")]
        public async Task<ActionResult<List<Stat>>> GetByStats(int id,[FromServices] DataContext context)
        {
            var stats = await context.Stats.Include(x=> x.Player).AsNoTracking().Where(x=> x.PlayerId == id).ToListAsync();
            return stats;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Stat>>> Post([FromServices]DataContext context, [FromBody] Stat model)
        {
            if(ModelState.IsValid)
            {
                context.Stats.Add(model);
                await context.SaveChangesAsync();
                return Ok (model);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

    }
}