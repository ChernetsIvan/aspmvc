using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Domain.Entities
{
	public class Cart
	{
		private List<CartLine> lineCollection = new List<CartLine>();

		public void AddItem(Product product, int quantity)
		{
			CartLine line = lineCollection
				.Where(p => p.Product.ProductID == product.ProductID)
				.FirstOrDefault();
			if (line == null)
				lineCollection.Add(new CartLine
				{
					Product = product,
					Quantity = quantity
				});
			else
				line.Quantity += quantity;
		}

		public void RemoveLine(Product product, bool all)
		{
			if (all)
				lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
			else
			{
				foreach(CartLine l in lineCollection)
					if (l.Product.ProductID == product.ProductID)
					{
						l.Quantity--;
						if (l.Quantity == 0)
						{
							lineCollection.Remove(l);
							break;
						}
					}
			}
		}

		public decimal ComputeTotalValue()
		{
			return lineCollection.Sum(e => e.Product.Price * e.Quantity);
		}

		public void Clear()
		{
			lineCollection.Clear();
		}

		public IEnumerable<CartLine> Lines { 
			get { return lineCollection; } 
		}
	}

	public class CartLine
	{
		public Product Product {get;set;}
		public int Quantity {get;set;}
	}
}
