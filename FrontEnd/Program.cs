using FoodBoxClassLibrary.Data;
using FrontEnd.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FrontEnd;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //var connectionString = builder.Configuration.GetConnectionString("FoodBoxDBConnection") ?? throw new InvalidOperationException("Connection string 'FoodBoxDBConnection' not found.");
        builder.Services.AddDbContextFactory<FoodBoxDB>(options => options.UseNpgsql((builder.Configuration["db"])));

        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddDefaultUI()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<FoodBoxDB>();

        builder.Services.AddAuthentication("Cookies")
               .AddCookie(opt =>
               {
                   opt.Cookie.Name = "TryingoutGoogleOAuth";
                   opt.LoginPath = "/auth/google-login";
               })
               .AddGoogle(opt => 
               {  
                   opt.ClientId = builder.Configuration["ClientId"];
                   opt.ClientSecret = builder.Configuration["ClientSecret"];
               });

        // Add services to the container.
        builder.Services.AddScoped<OrderState>();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddScoped<StateContainer>();
        builder.Services.AddHostedService<DefaultUserService>();
        builder.Services.AddControllers();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.MapControllers();

        app.Run();
    }
}
