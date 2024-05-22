using LokiLoggingProvider.Options;

var builder = WebApplication.CreateBuilder(args);
//https://www.youtube.com/watch?v=PBfKDyNPBug&t=7755s&ab_channel.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adding loki:
builder.Logging.AddLoki(loggerOptions =>
{
	loggerOptions.Client = PushClient.Grpc;
	loggerOptions.Formatter = Formatter.Json;

	//additional filters for log search:
	loggerOptions.StaticLabels.JobName = "lokiwapp";
	loggerOptions.StaticLabels.AdditionalStaticLabels.Add("systemname", "lokiusing");
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

