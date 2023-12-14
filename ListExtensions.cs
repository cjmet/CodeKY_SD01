using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKY_SD01
{
	static class ListExtensions
	{
		public static List<T> InStock<T>(this List<T> list) where T : Product
		{
			return list.Where(item => item.Quantity > 0).ToList();
		}
	}
}
