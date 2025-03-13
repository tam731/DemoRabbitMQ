using MasstransitRabbitMQ.Consumer.API.DependencyInjection.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Add Serilog configuration

Log.Logger=new LoggerConfiguration().ReadFrom
           .Configuration(builder.Configuration)
           .CreateLogger();

builder.Logging
       .ClearProviders()
       .AddSerilog();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Masstransit rabbitMQ
builder.Services.AddConfigureMasstransitRabbitMQ(builder.Configuration);

//Add MediatR
builder.Services.AddMediatR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    await app.RunAsync();
    Log.Information("Stopped cleanly");
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occurred bootstrapping");
	await app.StopAsync();
}
finally
{
    Log.CloseAndFlush();
    await app.DisposeAsync();
}
public partial class Program { }