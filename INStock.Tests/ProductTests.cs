namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;

    public class ProductTests
    {
        [Test]
        public void ConstructorShoudCreateCorrectObject()
        {
            string label = "A";
            decimal price = 1.1m;

            Product product = new Product(label, price);

            Assert.AreEqual(label, product.Label);
            Assert.AreEqual(price, product.Price);
        }

        [Test]
        public void PropertyLabelShoudThrowArgumentNullExceptionIfReceiveNullParam()
        {
            string label = string.Empty; 
            decimal price = 1.1m;
            Assert.Throws<ArgumentNullException>(() => new Product(label, price));
        }
        [Test]
        public void PropertyPriceShoudThrowArgumentExceptionIfReceiveNegativeParam()
        {
            string label = "A";
            decimal price = - 1.1m;
            Assert.Throws<ArgumentException>(() => new Product(label, price));
        }

        [Test]
        public void MethodCompareToShoudWorksCorrectlyIfReceiveCorrectParams()
        {
            string label = "A";
            decimal price = 1.1m;

            Product product = new Product(label, price);

            string label2 = "B";
            decimal price2 = 1.1m;

            Product product2 = new Product(label2, price2);
            var expectedResult = 0;
            var actualResult = product.CompareTo(product2);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}