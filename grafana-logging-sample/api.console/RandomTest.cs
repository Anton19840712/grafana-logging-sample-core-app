using Microsoft.Extensions.Logging;

namespace api.console;

public class RandomTest(ILogger logger)
{
	public void PrintRandomModels(int numberOfModels)
	{
		logger.LogInformation("Start generating info...");

		while (numberOfModels > 0)
		{
			var fields = GenerateRandomModel();
			logger.LogInformation($"Model: {fields[0]}, Year: {fields[1]}, Color: {fields[2]}");
			numberOfModels--;
		}
	}

	private string[] GenerateRandomModel()
	{
		string[] possibleModels = ["Sedan", "SUV", "Truck", "Coupe", "Convertible"];
		string[] possibleYears = ["2022", "2023", "2024"];
		string[] possibleColors = ["Red", "Blue", "Green", "Black", "White"];

		var random = new Random();

		var randomModel = possibleModels[random.Next(possibleModels.Length)];
		var randomYear = possibleYears[random.Next(possibleYears.Length)];
		var randomColor = possibleColors[random.Next(possibleColors.Length)];

		return [randomModel, randomYear, randomColor];
	}
}