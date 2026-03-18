using Microsoft.EntityFrameworkCore;
using SupplierHub;
using SupplierHub.MapProfile;
using AutoMapper;

using SupplierHub.Repositories;
using SupplierHub.Repositories.Interface;
using SupplierHub.Services;
using SupplierHub.Services.Interface;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
<<<<<<< Updated upstream
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb"));
    // Helpful in development to see parameter values in EF logs. Enable only for dev.
    if (builder.Environment.IsDevelopment())
        options.EnableSensitiveDataLogging();
});
=======
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb")));
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();

//ErpExportRef
builder.Services.AddScoped<IErpExportRefRepository, ErpExportRefRepository>();
builder.Services.AddScoped<IErpExportRefService, ErpExportRefService>();
>>>>>>> Stashed changes

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Make overload resolution unambiguous by passing a Type so the params Type[] overload is selected
builder.Services.AddAutoMapper(typeof(ApplicationMapperProfile).Assembly);






// register services before Build
builder.Services.AddScoped<ISuppliersRepository, SuppliersRepository>();
builder.Services.AddScoped<ISuppliersService, SuppliersService>();

builder.Services.AddScoped<IRfxRepository, RfxRepository>();
builder.Services.AddScoped<IRfxService, RfxService>();



builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();

// User repository & service
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();





