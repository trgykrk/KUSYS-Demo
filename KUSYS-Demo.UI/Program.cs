using MediatR;
using AutoMapper;
using KUSYS_Demo.Business.Interfaces;
using KUSYS_Demo.Business.Mapping;
using KUSYS_Demo.Business.Services;
using KUSYS_Demo.DataAccess.Contexts;
using KUSYS_Demo.DataAccess.UnitOfWork;

using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<KUSYSDemoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConn"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>()
    {
        new StudentCourseProfile()
        
    });
});

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => {

    x.LoginPath = "/Login/Admin/";
});

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = "/node_modules"
});
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();
