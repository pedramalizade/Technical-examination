using App.Domain.AppService.CarModel;
using App.Domain.AppService.OPrator;
using App.Domain.AppService.User;
using App.Domain.Core.AppServices;
using App.Domain.Core.Confrig;
using App.Domain.Core.Data.Repository;
using App.Domain.Core.Services;
using App.DomainServices.CarModel;
using App.DomainServices.OPrator;
using App.DomainServices.User;
using App.EndPoints.Api.Car.Middelware;
using App.Infra.Data.Ef.CarModel;
using App.Infra.Data.Ef.OPrator;
using App.Infra.Data.Ef.User;
using App.Infra.Data.SqlServer.Ef.ApplicationDBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var settingsSite = configuration.GetSection(nameof(SettingsSite)).Get<SettingsSite>();
builder.Services.AddSingleton(settingsSite);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddScoped<IUserAppServices, UserAppServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICarModelAppServices, CarModelAppServices>();
builder.Services.AddScoped<ICarModelServices, CarModelServices>();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
builder.Services.AddScoped<IAdminAppServices, AdminAppServices>();
builder.Services.AddScoped<IAdminServices, AdminServices>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(settingsSite.ConnectionStrings.SqlConnection));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
