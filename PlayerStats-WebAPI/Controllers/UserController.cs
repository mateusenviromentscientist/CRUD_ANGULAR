
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerStats_WebAPI.Services;

namespace PlayerStats_WebAPI
{
    [Microsoft.AspNetCore.Mvc.Route("users")]
    public class UserController : Controller
    {

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<User>>>Get([FromServices]DataContext context)
        {
            var users = await context.Users.AsNoTracking().ToListAsync();
            return users;
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post([FromServices]DataContext context,
        [FromBody] User model)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);    

            try
            {
                model.Username = "admin";
                context.Users.Add(model);
                await context.SaveChangesAsync();
                model.Password="";
                return model;
            }
            catch(Exception)
            {
                return BadRequest(new {message = "isnt possible create user"});
            }
        }

        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<User>> Put([FromServices]DataContext context, int id, [FromBody] User model)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            if (id != model.Id)
            return NotFound(new {message = "User not Found"});

            try
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch
            {
                return BadRequest(new {message= "isnt possible create a user"});
            }
        }
        
        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromServices]DataContext context,
        [FromBody]User model)
        {
            var user = await context.Users.AsNoTracking().Where(x=> x.Username == model.Username && x.Password == model.Password).
            FirstOrDefaultAsync();

            if(user == null)
            return NotFound(new {message = "User or Password invalids"});

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new 
            {
                user = user,
                token = token
            };
        }
        
    }
}
