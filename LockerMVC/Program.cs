using Auth0.AspNetCore.Authentication;
using LockerMVC.Controllers;
using LockerMVC.DataContext;
using LockerMVC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LockerMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            IServiceCollection serviceCollection = builder.Services.AddDbContext<LockerDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            builder.Services.AddTransient<LockerDataContext, LockerDataContext>();
            builder.Services.AddTransient<LockertypesRepository, LockertypesRepository>();
            builder.Services.AddTransient<LockereventsRepository, LockereventsRepository>();
            builder.Services.AddTransient<LockerlinesRepository, LockerlinesRepository>();
            builder.Services.AddTransient<UsergroupsRepository, UsergroupsRepository>();
            builder.Services.AddTransient<UsertypesRepository, UsertypesRepository>();
            builder.Services.AddTransient<UsersRepository, UsersRepository>();
            builder.Services.AddTransient<CompanysRepository, CompanysRepository>();
            //builder.Services.AddScoped<ProgrammingClubDataContext>();     // creaza un obiect pe durata unei sesiuni
            //builder.Services.AddSingleton<ProgrammingClubDataContext>();  // asigura o singura instanta a unui obiect pe perioada unei cereri
            builder.Services.AddAuth0WebAppAuthentication(options =>
            {
                options.Domain = builder.Configuration["Auth0:Domain"];
                options.ClientId = builder.Configuration["Auth0:ClientId"];

            });

            var app = builder.Build();

            app.UseAuthentication();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
            //test++
        }
    }
}