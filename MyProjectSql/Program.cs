using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyProjectSql.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews() ;

builder.Services.AddDbContext<MyprojectDbtContext>(Options => Options.UseNpgsql(
    builder.Configuration.GetConnectionString("PostgreSQL")
    ));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
