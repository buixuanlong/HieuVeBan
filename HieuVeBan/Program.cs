using HieuVeBan;
using HieuVeBan.Configurations;
using HieuVeBan.Extension;
using HieuVeBan.Filters;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((hostContext, logConfig) => logConfig.ReadFrom.Configuration(hostContext.Configuration));

builder.Services.AddControllers(otps =>
{
    otps.Filters.Add(typeof(ApiResponseWrapping));
}).InvalidModelStateOption();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseGlobalExceptionHandler();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
