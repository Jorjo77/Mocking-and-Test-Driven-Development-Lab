namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStockTests
    {
        private InStock inStock;
        [SetUp]

        public void SetupObject()
        {
            inStock = new InStock();
        }

        [Test]
        public void AddMethodShouldAddProductCorrectly()
        {
            Product product = new Product("A", 1);

            inStock.Add(product);

            var expectedResult = 1;
            int actualResult = inStock.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfReceiveNull()
        {           
            Assert.Throws<InvalidOperationException>(()=> inStock.Add(null));
        }

        [Test]
        public void CountMethodShouldWorksCorrectly()
        {
            Product product = new Product("A", 1);
            Product product2 = new Product("B", 2);

            inStock.Add(product);
            inStock.Add(product2);

            var expectedResult = 2;
            var actualResult = inStock.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ContainsMethodShouldWorksCorrectly()
        {
            Product product = new Product("A", 1);

            inStock.Add(product);

            var expectedResult = true;
            bool actualResult = inStock.Contains(product);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindMethodShouldWorksCorrectlyIfReceiveParameterInRange()
        {
            Product product = new Product("A", 1);
            Product product2 = new Product("B", 2);
            Product product3 = new Product("C", 3);

            inStock.Add(product);
            inStock.Add(product2);
            inStock.Add(product3);

            inStock.Find(1);
            var expectedResult = product;
            var actualResult = inStock.Find(1);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindMethodShouldThrowIndexOutOfRangeExceptionIfReceiveOutOfRangeParameter()
        {
            Product product = new Product("A", 1);
            Product product2 = new Product("B", 2);
            Product product3 = new Product("C", 3);

            inStock.Add(product);
            inStock.Add(product2);
            inStock.Add(product3);

            Assert.Throws<IndexOutOfRangeException>(()=> inStock.Find(5));
        }

        [Test]
        public void FindByLabelMethodShouldThrowArgumentExceptionIfReceiveIncorrectParameter()
        {
            Product product = new Product("A", 1);

            inStock.Add(product);

            Assert.Throws<ArgumentException>(() => inStock.FindByLabel("C"));
        }
        [Test]
        public void FindByLabelMethodShouldWorksCorrectlyIfReceiveContainedParameter()
        {
            Product product = new Product("A", 1);

            inStock.Add(product);

            var expectedResult = product;
            var actualResult = inStock.FindByLabel("A");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void SetInvalidIndexShouldThrowIndexOutOfRangeException()
        {
            Product product = new Product("A", 1);

            Assert.Throws<IndexOutOfRangeException>(()=> inStock[inStock.Count + 2] = product);
        }
        [Test]
        public void SetVlidIndexShouldWorksCorrectly()
        {
            Product product = new Product("A", 1);
            inStock.Add(product);
            var expectedResult = product;
            var actualResult = inStock[0];
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void FindAllInPriceRangeMethodShouldReturnElementsInRangeIfCollectionIsNotEmpty()
        {
            Product product = new Product("A", 1);
            Product product2 = new Product("B", 2);
            Product product3 = new Product("C", 3);
            Product product4 = new Product("D", 4);

            inStock.Add(product);
            inStock.Add(product2);
            inStock.Add(product3);
            inStock.Add(product4);

            var expectedResult = new Product[]
            {
               product3,
               product2
            };

            var actualResult = inStock.FindAllInPriceRange(2, 3).ToArray();

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void FindAllByPriceMethodShouldReturnAllProductsWithSamePrice()
        {
            Product product = new Product("A", 1);
            Product product2 = new Product("B", 2);
            Product product3 = new Product("C", 2);
            Product product4 = new Product("D", 4);

            inStock.Add(product);
            inStock.Add(product2);
            inStock.Add(product3);
            inStock.Add(product4);

            var expectedResult = new Product[]
            {
               product2,
               product3
            };

            var actualResult = inStock.FindAllByPrice(2).ToArray();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindAllByPriceMethodShouldReturnEmptyCollectionIfTheSearchedPriceDoNotExistsInCollection()
        {
            Product product = new Product("A", 1);

            inStock.Add(product);

            var expectedResult = new Product[] { };

            var actualResult = inStock.FindAllByPrice(5).ToArray();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindMostExpensiveProductsMethodShouldReturnGivenNumberOfTheMostExpensiveProducts()
        {
            Product product = new Product("A", 1);
            Product product2 = new Product("B", 2);
            Product product3 = new Product("C", 3);
            Product product4 = new Product("D", 4);

            inStock.Add(product);
            inStock.Add(product2);
            inStock.Add(product3);
            inStock.Add(product4);

            var expectedResult = new Product[]
            {
               product4,
               product3,
               product2
            };

            var actualResult = inStock.FindMostExpensiveProducts(3).ToArray();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindMostExpensiveProductsMethodShouldThrowIndexOutOfRangeExceptionIfReceiveOutOfRangeParam()
        {
            Product product = new Product("A", 1);
            Product product2 = new Product("B", 2);

            inStock.Add(product);
            inStock.Add(product2);

            Assert.Throws<IndexOutOfRangeException>(()=> inStock.FindMostExpensiveProducts(3));
        }
    }
}
