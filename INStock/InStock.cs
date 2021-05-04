using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Tests
{
    public class InStock : IInStock
    {
        private IList<Product> products;

        public InStock()
        {
            products = new List<Product>();
        }
        public void Add(Product product)
        {
            if (product == null)
            {
                throw new InvalidOperationException();
            }
            products.Add(product);
        }

        public bool Contains(Product product) 
            => products.Contains(product);

        public int Count 
            => products.Count;

        public Product this[int index] 
        {
            get
            {
                return this.products[index];
            }
            set
            {
                if (index < 0 || index > this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                this.products[index] = value;
            }
        }

        public Product Find(int elementNumber)
        {
            if (elementNumber < 0 || elementNumber>products.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return products[elementNumber - 1];
        }

        public Product FindByLabel(string label)
        {
            Product searchedProduct = products.FirstOrDefault(p => p.Label == label);
            if (searchedProduct == null)
            {
                throw new ArgumentException();
            }
            return searchedProduct;
        }

        public Product[] FindAllInPriceRange(decimal lowerEnd, decimal higherEnd)
        {
            var searchedProducts = products
                .Where(p => p.Price >= lowerEnd)
                .Where(products => products.Price <= higherEnd)
                .OrderByDescending(p => p).ToArray();

            return searchedProducts;
        }

        public Product[] FindAllByPrice(decimal price)
        {
            var searchedProducts = products
                .Where(p => p.Price == price)
                .ToArray();

            return searchedProducts;
        }

        public Product[] FindMostExpensiveProducts(int productsNumber)
        {
            if (productsNumber>=products.Count)
            {
                throw new IndexOutOfRangeException();
            }
            var searchedProducts = products
                .OrderByDescending(p => p.Price)
                .ToArray();

            List<Product> result = new List<Product>();
            
            for (int i = 0; i < productsNumber; i++)
            {
                result.Add(searchedProducts[i]);
            }

            return result.ToArray();
        }
    }
}
