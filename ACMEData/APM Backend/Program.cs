using ACMEData.Application;
using ACMEData.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductFacade, ProductFacade>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddDbContext<ACMEContext>(DBContextOptions => 
DBContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection")));

builder.Services.AddCors(p => 
{
    p.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
