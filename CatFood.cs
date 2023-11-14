﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CodeKY_SD01
{
	public class CatFood : Product
	{
		[JsonPropertyOrder(10)]
		public virtual double Weight { get; set; }
		[JsonPropertyOrder(11)]
		public bool KittenFood;


		public CatFood() {}

		public CatFood(string name, string description, decimal price, int quantity, double weight, bool isKittenFood)
		{
			AddCatFood(name, description, price, quantity, weight, isKittenFood);
		}	
		public void AddCatFood ()
		{
			this.AddProduct();
			this.KittenFood = true;

			string userInput;
			Console.WriteLine("Enter the Product Weight");
			userInput = Console.ReadLine();
			userInput = userInput.Trim();
			this.Weight = double.Parse(userInput);

			
			do 
			{
				Console.WriteLine("Is this Product a Kitten Food (Yes/No)?");
				userInput = Console.ReadLine();
				userInput = userInput.Trim();
				userInput = userInput.ToLower();
			} while (!(userInput.StartsWith("y") || userInput.StartsWith("n")));
			if (userInput.StartsWith("y")) this.KittenFood = true;
			else if (userInput.StartsWith("n")) this.KittenFood = false;
			else { Debug.Assert(false); }
		}

		public void AddCatFood(string name, string description, decimal price, int quantity, double weight,bool isKittenFood)
		{
			this.AddProduct(name,description,price,quantity);
			this.Weight = weight;
			this.KittenFood = isKittenFood;
		}

	}
}
