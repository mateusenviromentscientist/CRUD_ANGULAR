

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayerStats_WebAPI;

namespace Backoffice.Controllers
{   
    [Route("v1")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> Get ([FromServices]DataContext context)
        {
            var admin = new User {Id = 1, Username = "Mateus", Password = "cucabeludo"};
            var player = new Player {Id = 1, player = "Messi"};
            var stat = new Stat {Id = 1, Player = player, Estatistica = "50 gols e 20 assistencias",Ano = 2011, Clube = "Fc Barcelona" };
            context.Users.Add(admin);
            context.Players.Add(player);
            context.Stats.Add(stat);
            await context.SaveChangesAsync();

            return Ok(new {message = "Dados Confirmados"});


        }
    }
}