using Microsoft.EntityFrameworkCore;
using Vacation.Data;
using Vacation.Data.Repositories;
using Vacation.Domain.Contracts.Repositories;
using Vacation.Domain.Contracts.Services;
using Vacation.Services.Services;
using Vacation.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add builder.Service to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VacationDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Applying migration
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<VacationDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
