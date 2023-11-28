using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKY_SD01
{
	internal interface IProductLogic
	{
		public void AddProduct (Product product);
		public List<Product> GetAllProducts();
		public DogLeash GetDogLeashByName(string name);
		public CatFood GetCatFoodByName(string name);
		public List<Product> SearchProducts(string name);
		public List<Product> GetOnlyInStockProducts();
		public List<String> GetOnlyInStockProductsByName();
	}
}
