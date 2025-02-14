using Application;
using CompanyApi.Common;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMyAuthentication(builder.Configuration);

builder.Services.AddSwaggerWithAuth();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddAngularCorsPolicy();

builder
    .AddApplication()
    .AddInfrastructure();
var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseSwaggerWithAuth();
app.UseAngularCorsPolicy();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers(); 
app.Run();