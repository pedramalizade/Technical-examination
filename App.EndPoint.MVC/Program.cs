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
using App.Infra.Data.Ef.CarModel;
using App.Infra.Data.Ef.OPrator;
using App.Infra.Data.Ef.User;
using Microsoft.EntityFrameworkCore;

namespace App.EndPoint.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var settingsSite = builder.Configuration.GetSection(nameof(SettingsSite)).Get<SettingsSite>();
            builder.Services.AddSingleton(settingsSite);

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IUserAppServices, UserAppServices>();
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICarModelAppServices, CarModelAppServices>();
            builder.Services.AddScoped<ICarModelServices, CarModelServices>();
            builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
            builder.Services.AddScoped<IAdminAppServices, AdminAppServices>();
            builder.Services.AddScoped<IAdminServices, AdminServices>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();

            builder.Services.AddDbContext<Infra.Data.SqlServer.Ef.ApplicationDBContext.AppDbContext>(options =>
                options.UseSqlServer(settingsSite.ConnectionStrings.SqlConnection));

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

