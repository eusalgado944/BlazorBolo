using BolosApi.Data;
using BolosApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do Entity Framework com SQL Server
builder.Services.AddDbContext<BolosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBoloRepository, BoloRepository>();

builder.Services.AddCors(options => options.AddPolicy("origin", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("origin");
app.MapControllers();

app.Run();
