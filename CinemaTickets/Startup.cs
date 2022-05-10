using CinemaTickets.Data;
using CinemaTickets.Data.Helper;
using CinemaTickets.Models;
using CinemaTickets.Data.Services;
using CinemaTickets.Data.ViewModels.Email;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CinemaTickets
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration,IWebHostEnvironment env)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CinemaTicketsContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<CinemaTicketsContext>().AddDefaultTokenProviders();

      

            services.Configure<IdentityOptions>(option =>
            {
                option.SignIn.RequireConfirmedEmail = true;
            });

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = _configuration["Application:LoginPath"];
            });

            // Add Session 
            services.AddSession(options => {
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        


            #if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();

            #endif
            services.AddAuthentication().AddGoogle(option=> 
            {
                option.ClientId = _configuration["Google:ClientId"];
                option.ClientSecret = _configuration["Google:ClientSecret"];
            } );
            // Add services
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITheaterService, TheaterService>();
            services.AddScoped<IScreenService, ScreenService>();
            services.AddScoped<IShowService, ShowService>();
            services.AddScoped<ITimeService, TimeService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICrewService, CrewService>();
            services.AddScoped<ICrewRoleService, CrewRoleService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ISlideService, SlideService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IEmailService, EmailService>();

            //Claims
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdvertisingManage", policy => policy.RequireRole("Advertising Admin","Super Admin","Admin"));  
                options.AddPolicy("AdminManage", policy => policy.RequireRole("Super Admin","Admin"));
                options.AddPolicy("SuperManager", policy => policy.RequireRole("Super Admin"));
            });
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaims>();


            //Email Services
            services.Configure<STMPConfigViewModel>(_configuration.GetSection("SMTPConfig"));
          
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
