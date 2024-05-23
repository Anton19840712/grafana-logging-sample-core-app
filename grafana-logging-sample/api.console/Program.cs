using api.console;
using LokiLoggingProvider.Options;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(
	builder => builder
		.AddConsole()
		.AddLoki(loggerOptions =>
		{
			loggerOptions.Client = PushClient.Http;
			//loggerOptions.Formatter = Formatter.Json;

			//additional filters for log search:
			loggerOptions.StaticLabels.JobName = "loki31";
			loggerOptions.StaticLabels.AdditionalStaticLabels.Add("system31", "lokiusing31");
			loggerOptions.Http.Address = "http://10.10.50.81:3100";
		}));

//using var loggerFactory = LoggerFactory.Create(builder => builder.AddJsonConsole());
var logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation("testing info logging process...");

var test = new RandomTest(logger);
test.PrintRandomModels(20);