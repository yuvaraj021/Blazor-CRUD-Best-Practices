using BlazorCRUD.Application.Interfaces;
using BlazorCRUD.Application.Mapper;
using BlazorCRUD.Application.Services;
using BlazorCRUD.Components;
using BlazorCRUD.Domain.Interfaces;
using BlazorCRUD.Infrastructure.Data;
using BlazorCRUD.Infrastructure.Respositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog before building the host
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error() // For testing purposes
    .WriteTo.Console()
    .WriteTo.File(
        path: "logs/log.txt",
        rollingInterval: RollingInterval.Day,
        fileSizeLimitBytes: 10 * 1024 * 1024,
        rollOnFileSizeLimit: true,
        retainedFileCountLimit: null,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}",
        restrictedToMinimumLevel: LogEventLevel.Error) // Error level logs
    .CreateLogger();


// Ensure Serilog is used for logging
builder.Host.UseSerilog();

// Add services to the container
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<DataMapper>();
}, typeof(Program).Assembly);

// Register repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Register services
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Use the custom exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
