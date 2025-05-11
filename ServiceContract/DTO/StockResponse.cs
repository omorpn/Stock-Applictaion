using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;

namespace ServiceContract.DTO
{
  public  class StockResponse
    {
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
    public static class Extension
    {
        public static StockResponse ToStockResponse(this Stock stock)
        {
            return new StockResponse
            {
                StockSymbol = stock.StockSymbol,
                StockName = stock.StockName,
                Price = stock.Price,
                Quantity = stock.Quantity
            };
        }
    }
}
