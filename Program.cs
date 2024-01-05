using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddScoped<AnnouncementService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.Configure<IdentityOptions>(options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Login/Index"; // Giriþ yapma sayfasý (gerektiðinde deðiþtirilebilir)
        });
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
