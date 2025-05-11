using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;

namespace ServiceContract.DTO
{
    public class StockRequest
    {
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Stock Stock(StockRequest stock)
        {
            return new Stock(StockSymbol, StockName, Price, Quantity);
        }
    }
}
