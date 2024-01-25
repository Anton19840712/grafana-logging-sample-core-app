using api.console;
using Microsoft.Extensions.Logging;

//using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
using var loggerFactory = LoggerFactory.Create(builder => builder.AddJsonConsole());
var logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation("testing info logging process...");

var test = new RandomTest(logger);
test.PrintRandomModels(20);