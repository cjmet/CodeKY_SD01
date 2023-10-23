using CodeKY_SD01;
using System.Text.Json;

namespace CodeKY_SD01
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string userInput;
			Console.WriteLine("Welcome to our Pet Shop!");

			do
			{
				Console.WriteLine("Press 1 to add a product.");
				Console.WriteLine("Type 'exit' to quit.");

				userInput = Console.ReadLine();
				userInput = userInput.Trim();
				userInput = userInput.ToLower();

				switch (userInput)
				{
					case "1":
						Console.WriteLine("1"); 
						Console.WriteLine("Adding a new product.");
						CatFood catChow = new CatFood();
						catChow.AddCatFood();

						var options = new JsonSerializerOptions { IncludeFields = true, WriteIndented = true };
						Console.WriteLine(JsonSerializer.Serialize(catChow,options));
						
						break;
					case "2": 
						Console.WriteLine("2"); 
						break;
					case "exit": Console.WriteLine("exit"); break;
					case "quit": Console.WriteLine("quit"); break;
					case "": Console.WriteLine("<empty>"); break;
					default: Console.WriteLine($"I do not recognize '{userInput}' as a valid input."); break;
				}

			} while (!(userInput.Equals("exit", StringComparison.OrdinalIgnoreCase) 
				|| userInput.Equals("quit", StringComparison.OrdinalIgnoreCase)
				||  userInput.Equals("", StringComparison.OrdinalIgnoreCase)
				));
		}
	}
}