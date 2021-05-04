
using INStock.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Tests
{
    public interface IInStock
    {

        public void Add(Product product);

        public bool Contains(Product product);

        public int Count { get; }

        public Product Find(int elementNumber);

        public Product FindByLabel(string label);

        public Product [] FindAllInPriceRange(decimal lowerEnd, decimal higherEnd);

        public Product[] FindAllByPrice(decimal price);

        public Product[] FindMostExpensiveProducts(int productsNumber);

         Product this[int index] {get; set;}
    }
}
