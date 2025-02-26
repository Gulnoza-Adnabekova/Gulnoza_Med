using Gulnoza_Med.Models;


using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "att",
    pattern: "{controller=Home}/{action=HomePage}"
    );

app.Run();
