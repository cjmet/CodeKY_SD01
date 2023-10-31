using CodeKY_SD01;
using System.Diagnostics;
using System.Text.Json;

namespace CodeKY_SD01
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var productLogic = new ProductLogic();
			
			#if DEBUG 
			productLogic.DebugDatabaseInit(); 
			#endif
			
			string userInput;
			Console.WriteLine("Welcome to our Pet Shop!");
			Console.WriteLine("------------------------");
			Console.WriteLine();

			do
			{
				Console.WriteLine("Press 1 to add a product.");
				Console.WriteLine("Press 2 to view a Cat Food by name.");
				Console.WriteLine("Press 8 to search a list of products for a keyword.");
				Console.WriteLine("Press 9 to view a list of products.");
				Console.WriteLine("Type 'exit' to quit.");

				userInput = Console.ReadLine();
				userInput = userInput.Trim();
				userInput = userInput.ToLower();
				Console.WriteLine();

				switch (userInput)
				{
					case "1":
						Console.WriteLine("Adding a new product.");
						CatFood catChow = new CatFood();
						catChow.AddCatFood();

						productLogic.AddProduct(catChow);

						#if DEBUG
							Console.WriteLine(JsonSerializer.Serialize(catChow, new JsonSerializerOptions { IncludeFields = true, WriteIndented = true }));
						#endif

						Console.WriteLine("Product Added.");
						break;
					case "2":
						{
							Console.WriteLine("Enter the Cat Food you wish to view.");
							string userInput2 = Console.ReadLine();
							userInput2 = userInput2.Trim();
							CatFood catFood = productLogic.GetCatFoodByName(userInput2);
							if (catFood != null)
							{
								Console.WriteLine(JsonSerializer.Serialize(catFood, new JsonSerializerOptions { IncludeFields = true, WriteIndented = true }));
							}
							else
							{
								Console.WriteLine($"Product '{userInput2}' was not found.");
							}
							break;
						}
					case "8":
						{
							Console.WriteLine("Enter the Key Word");
							string userInput2 = Console.ReadLine();
							userInput2 = userInput2.Trim();
							List<Product> results = productLogic.SearchProducts(userInput2);
							if (results.Count > 0)
							{
								Console.WriteLine();
								foreach (var result in results)
								{
									Console.WriteLine(JsonSerializer.Serialize(result, new JsonSerializerOptions { IncludeFields = true, WriteIndented = true }));
								}
								Console.WriteLine($"{results.Count} Items Found.");
							}
							else
							{
								Console.WriteLine($"Product '{userInput2}' was not found.");
							}
							break;
						}
					case "9":
						var list = productLogic.GetAllProducts();
						if (list != null && list.Count > 0)
						{
							Console.WriteLine("The Following is a list of all Items.");
							foreach (var item in productLogic.GetAllProducts())
							{
								Console.WriteLine(item.Name);
							}
						}
						else
						{
							Console.WriteLine("Item List is Empty");
						}
						break;
					case "exit": Console.WriteLine("exit"); break;
					case "quit": Console.WriteLine("quit"); break;
					case "": Console.WriteLine("<empty>"); break;
					default: Console.WriteLine($"I do not recognize '{userInput}' as a valid input."); break;
				}
				Console.WriteLine();

			} while (!(userInput.Equals("exit", StringComparison.OrdinalIgnoreCase) 
				|| userInput.Equals("quit", StringComparison.OrdinalIgnoreCase)
				||  userInput.Equals("", StringComparison.OrdinalIgnoreCase)
				));
		}
	}
}