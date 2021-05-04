
using System;

namespace INStock.Contracts
{
    public interface IProduct 
    {
        public string Label { get; set; }

        public decimal Price { get; set; }
    }
}
