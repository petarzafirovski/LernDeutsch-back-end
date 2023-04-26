using LernDeutsch_Backend;
using Microsoft.AspNetCore;
using System.Security.Cryptography;
using LernDeutsch_Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
configuration["JWT:Secret"] = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddJwt(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureCors();
builder.Services.AddSwaggerSecurity();


builder.Services.Configure(builder.Configuration);

builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontendOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();

Console.WriteLine("Connection String:");
Console.WriteLine(builder.Configuration["ConnectionStrings:DefaultConnection"]);
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDatabaseContext>();
    dataContext.Database.Migrate();
}

app.Run();
