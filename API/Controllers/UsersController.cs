using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public static class UsersController 
{
    public  static void ConfigApi(this WebApplication app){
        app.MapGet("/Users",GetUsers);
        app.MapGet("/Users/{id}",GetUser);
    }
        private static async Task<IResult> GetUser([FromServices] DataContext context, int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(user);
        }

        private static async Task<IEnumerable<AppUser>> GetUsers([FromServices] DataContext context)
        {
            var users = await context.Users.ToListAsync();
            return users;
        }

}
