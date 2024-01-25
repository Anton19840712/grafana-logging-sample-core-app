using LokiLoggingProvider.Options;
using Microsoft.Extensions.Logging.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddLoki(loggerOptions =>
{
	loggerOptions.Client = PushClient.Grpc;
	loggerOptions.Formatter = Formatter.Json;

	//additional filters for log search:
	loggerOptions.StaticLabels.JobName = "loki-web-app";
	loggerOptions.StaticLabels.AdditionalStaticLabels.Add("system-name", "loki-using");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

