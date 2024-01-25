using api.console;
using LokiLoggingProvider.Options;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(
	builder => builder
		.AddConsole()
		.AddLoki(loggerOptions =>
		{
			loggerOptions.Client = PushClient.Grpc;
			//loggerOptions.Formatter = Formatter.Json;

			//additional filters for log search:
			loggerOptions.StaticLabels.JobName = "loki-console-app";
			loggerOptions.StaticLabels.AdditionalStaticLabels.Add("system-name", "loki-using");
		}));

//using var loggerFactory = LoggerFactory.Create(builder => builder.AddJsonConsole());
var logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation("testing info logging process...");

var test = new RandomTest(logger);
test.PrintRandomModels(20);