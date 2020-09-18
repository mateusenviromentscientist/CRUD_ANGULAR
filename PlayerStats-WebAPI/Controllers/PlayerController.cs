using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PlayerStats_WebAPI
{


    [Route("v1/players")]
    public class PlayerController: ControllerBase 
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        [ResponseCache(VaryByHeader="User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        public async Task<ActionResult<List<Player>>> Get([FromServices] DataContext context)
        {
            var players = await context.Players.AsNoTracking().ToListAsync();
            return Ok(players);
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Player>> GetById (int id, [FromServices]DataContext context)
        {
            var player = await context.Players.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Ok(player);
        }
    
        [HttpPost]
        [Route("")]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<List<Player>>> Post([FromBody] Player model, [FromServices]DataContext context){
           if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                context.Players.Add(model);
                await context.SaveChangesAsync();
                return Ok (model);
            }
            catch
            {
                return BadRequest(new { message = "Isnt possible return your player"});
            }
                       
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<List<Player>>> Put(int id, [FromBody] Player model, [FromServices] DataContext context){
            if(id != model.Id)
                return NotFound(new {message = "Player not Found"});
            
            if(!ModelState.IsValid)
            return BadRequest(ModelState);
            try
            {
                context.Entry<Player>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok (model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new {message ="this players was update already"});
            }
            catch (Exception)
            {
                return BadRequest(new{message="isn't possible patch the player "});
            }
            
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<List<Player>>> Delete(int id, [FromServices]DataContext context)
        {
            var player = await context.Players.FirstOrDefaultAsync(x => x.Id == id);
            if(player == null)
            return NotFound(new {message = "player not Found"});

            try
            {
                context.Players.Remove(player);
                await context.SaveChangesAsync();
                return Ok(player);
            }
            catch (Exception)
            {
                return BadRequest(new {message="isn't possible remove the player"});
            }
        }
        
                
    }
}
