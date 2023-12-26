using HR.LeaveManagement.Api.Middleware;
using HR.LeaveManagement.Application;
using HR.LeaveManagement.Identity;
using HR.LeaveManagement.Infrastructure;
using HR.LeaveManagement.Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// var applicationService = ApplicationServiceRegistration.AddApplicationServices(builder.Services);
// var infrastructureService = InfrastructureServiceRegistration.AddInfrastructureServices(builder.Services, builder.Configuration);
// var persistenceService = PersistenceServiceRegistration.AddPersistenceServices(builder.Services, builder.Configuration);

// builder.Services.applicationService();
// builder.Services.infrastructureService(builder.Configuration);
// builder.Services.persistenceService(builder.Configuration);

ApplicationServiceRegistration.AddApplicationServices(builder.Services);
InfrastructureServiceRegistration.AddInfrastructureServices(builder.Services, builder.Configuration);
PersistenceServiceRegistration.AddPersistenceServices(builder.Services, builder.Configuration);
IdentityServiceRegistration.AddIdentityServices(builder.Services, builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddCors(options => 
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("all");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
