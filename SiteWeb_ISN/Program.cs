using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIWeb_ISN.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<APIWeb_ISNContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIWeb_ISNContext") ?? throw new InvalidOperationException("Connection string 'APIWeb_ISNContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
//ajout pour creation bdd
#pragma warning disable CS8602//Dereferencement d'une eventuelle reference n
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<APIWeb_ISNContext>();
   // context.Database.EnsureDeleted();
  //  context.Database.EnsureCreated();
}
#pragma warning restore CS8602//Dereferencement d'une eventuelle reference n

app.Run();
