using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodeKY_SD01
{
	public class ProductLogic : IProductLogic
	{
		// private List<Product> _products = new List<Product>();
		private Dictionary<string, Product> _products = new Dictionary<string, Product>();
		private Dictionary<string, CatFood> _catFoods = new Dictionary<string, CatFood>();
		private Dictionary<string, DogLeash> _dogLeashs = new Dictionary<string, DogLeash>();

		public void DebugDatabaseInit()
		{
			Console.WriteLine("Creating a Debug Database.");

			this.AddProduct(new CatFood("Kitten Chow", "A Delicious Bag of Kitten Chow", 9.87m, 65, 4.32, true));
			this.AddProduct(new CatFood("Kittendines", "A Delicious Bag of Sardines just for Kittens", 8.87m, 55, 3.32, true));
			this.AddProduct(new CatFood("Void's Vittles for Kittens", "An Empty Bag of Kitten Food", 6.66m, 0, 0.01, true));
			this.AddProduct(new CatFood("Kitten Kuts", "A Delicious Bag of Choped Steak for Kittens", 19.87m, 15, 2.32, true));
			this.AddProduct(new CatFood("Bad Boy Bumble Bees", "A Delicious Bag of Dried Bumble Bees.  The Purrfect Snack for your one eyed Pirate Cats", 29.87m, 5, 1.32, false));

			Console.WriteLine();
		}

				
		public void AddProduct (Product product) 
		{
			_products.Add((product.Name).ToLower(),product);

			if (product is DogLeash) 
			{
				Console.WriteLine("Adding a Dog Leash");
				_dogLeashs.Add((product.Name).ToLower(), product as DogLeash);
			} 
			else if (product is CatFood)
			{
				Console.WriteLine("Adding a Cat Food");
				_catFoods.Add((product.Name).ToLower(), product as CatFood);
			}
			else
			{
				Console.WriteLine("Adding a Generic Product");
			}
		}

		public List<Product> GetAllProducts()
		{
			List<Product> _list = new List<Product>();
			foreach (var item in  _products) { _list.Add(item.Value); }
			return _list;
		}

		public List<Product> GetOnlyInStockProducts()
		{
			//var query =
			//	from item in _products
			//	where item.Value.Quantity > 0
			//	select item.Value;
			//var results = query.ToList();
			//return results;

			return _products.Values.ToList().InStock();
		}

		public decimal GetTotalPriceOfInventory ()
		{
			//return _products.Values.ToList().InStock().Sum(item => item.Price * item.Quantity);
			return this.GetOnlyInStockProducts().Sum(item => item.Price * item.Quantity); 
		}

		public List<String> GetOnlyInStockProductsByName()
		{
			var query =
				from item in _products
				where item.Value.Quantity > 0
				select item.Value.Name;
				var results = query.ToList();
				return results;
		}

		// Return the dogleash or null
		public DogLeash GetDogLeashByName(string name)
		{
			name = name.ToLower();	
			return _dogLeashs.ContainsKey(name) ?  _dogLeashs[name] : null;
		}

		// Return the catfood or null
		public CatFood GetCatFoodByName(string name)
		{
			name = name.ToLower();
			return _catFoods.ContainsKey(name) ?  _catFoods[name] : null;
		}


		public List<Product> SearchProducts(string name)
		{
			name = name.ToLower();
			List<Product> _list = new List<Product>();
			foreach (var item in _products) 
			{
				if (item.Key.Contains(name)) { _list.Add(item.Value); }
			}
			return _list;
		}

	}
}
