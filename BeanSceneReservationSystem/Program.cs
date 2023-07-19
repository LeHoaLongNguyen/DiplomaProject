using BeanSceneReservationSystem.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BeanSceneReservationSystem.MongoDbApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BeanSceneReservationSystem.MongoDbApi.Services;

namespace BeanSceneReservationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.Configure<ProductStoreDatabaseSettings>(
            builder.Configuration.GetSection(nameof(ProductStoreDatabaseSettings)));

            builder.Services.AddSingleton<IProductStoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ProductStoreDatabaseSettings>>().Value);

            builder.Services.AddSingleton<IMongoClient>(s =>
                    new MongoClient(builder.Configuration.GetValue<string>("ProductStoreDatabaseSettings:ConnectionString")));

            builder.Services.AddScoped<IProductService, ProductService>();


            builder.Services.Configure<OrderStoreDatabaseSettings>(
            builder.Configuration.GetSection(nameof(OrderStoreDatabaseSettings)));

            builder.Services.AddSingleton<IOrderStoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<OrderStoreDatabaseSettings>>().Value);

            builder.Services.AddSingleton<IMongoClient>(s =>
                    new MongoClient(builder.Configuration.GetValue<string>("OrderStoreDatabaseSettings:ConnectionString")));

            builder.Services.AddScoped<IOrderService, OrderService>();



            builder.Services.AddControllers(
                options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;
            });

         
            services.AddMvc(option => option.EnableEndpointRouting = false)
            .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);


            //configure google authentication
            //services.AddAuthentication().AddGoogle(googleOptions =>
            //{
            //    googleOptions.ClientId = configuration["Google:ClientId"];
            //    googleOptions.ClientSecret = configuration["Google:ClientSecret"];
            //});
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultScheme = "JWT_OR_COOKIE";
                o.DefaultChallengeScheme = "JWT_OR_COOKIE";
            })
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,

                            ValidIssuer = builder.Configuration["Jwt:Issuer"],
                            ValidAudience = builder.Configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),

                            // Prevents tokens without an expiry from ever working, as that would be a security vulnerability.
                            RequireExpirationTime = true,

                            // ClockSkew generally exists to account for potential clock difference between issuer and consumer
                            // But we are both, so we don't need to account for it.
                            // For all intents and purposes, this is optional
                            ClockSkew = TimeSpan.Zero
                        };
                    })
                    .AddPolicyScheme("JWT_OR_COOKIE", null, o =>
                    {
                        o.ForwardDefaultSelector = c =>
                        {
                            string auth = c.Request.Headers[HeaderNames.Authorization];
                            if (!string.IsNullOrWhiteSpace(auth) && auth.StartsWith("Bearer "))
                            {
                                return JwtBearerDefaults.AuthenticationScheme;
                            }

                            return IdentityConstants.ApplicationScheme;
                        };
                    });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // have to change this later
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Reservation}/{action=Index}/{id?}");


            app.MapRazorPages();
            app.UseCors(p =>
            {
                p.AllowAnyHeader();
                p.AllowAnyMethod();
                p.AllowAnyOrigin();
            });

            app.Run();
        }
    }
}