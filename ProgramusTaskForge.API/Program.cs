using Microsoft.EntityFrameworkCore;
using ProgromusTaskForge.Application.Repositories;
using ProgromusTaskForge.Infrastructure;
using ProgromusTaskForge.Infrastructure.Persistences.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Register config
ConfigurationManager configuration = builder.Configuration; 
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TFDbContext>(
    op=>op.UseNpgsql(
            configuration.GetConnectionString("DefaultConnection"),
            b=>b.MigrationsAssembly(typeof(TFDbContext).Assembly.GetName().Name)));
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(typeof(ITaskRepository).Assembly));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(op => 
{
    op.AddPolicy("AllowOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();