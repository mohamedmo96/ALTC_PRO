using ALTC_Site.Services;
using ALTC_Website.Models;
using ALTC_Website.Services;
using ALTC_WebSite.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<AltcDatabaseSettings>(
builder.Configuration.GetSection("altcwebsite"));
builder.Services.AddScoped<ITechnicalSupportService, TechnicalSupportService>();
builder.Services.AddScoped<IJobcandidateService, JobCandidatecsService>();
builder.Services.AddScoped<IStaticData, StaticDataService>();

builder.Services.AddScoped<IComplainService, ComplainService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IDepartment, Departmant>();
builder.Services.AddScoped<ITeamService,TeamService>();
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

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
