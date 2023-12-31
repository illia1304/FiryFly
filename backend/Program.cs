using AutoMapper;
using backend.DataModels;
using backend.DTO.LongreadsDTO;
using backend.DTO.UserDTO;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(config => {
    config.CreateMap<User, GetUserDTO>();
    config.CreateMap<CreateUserDTO, User>();
    config.CreateMap<LongreadDTO, Longread>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Dbcontext>((s, o) =>{
    var configuration = s.GetRequiredService<IConfiguration>();
    o.UseNpgsql(configuration.GetConnectionString("DbContext"));
});
var app = builder.Build();



// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
