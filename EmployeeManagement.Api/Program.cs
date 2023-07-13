using EmployeeManagement.Api.Extensions;
using EmployeeManagement.Domain.IRepository;
using EmployeeManagement.Domain.IService;
using EmployeeManagement.Repository.Ef;
using EmployeeManagement.Repository.Ef.Repository;
using EmployeeManagement.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmployeeContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddScoped<IEmployeeService, EmployeeService>();


builder.Services.AddControllers();
//builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add service and repository
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//builder.Services.AddConfig(config);
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
