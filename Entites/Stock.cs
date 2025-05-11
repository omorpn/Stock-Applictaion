using System.ComponentModel.DataAnnotations;

namespace Entites
{
    public class Stock
    {
        [Required(ErrorMessage ="{0} can't be empty")]
        public string? StockSymbol { get; set; }
        [Required(ErrorMessage = "{0} can't be empty")]

        public string? StockName { get; set; }
        [Required(ErrorMessage = "{0} can't be empty")]

        public double Price { get; set; }
        [Required(ErrorMessage = "{0} can't be empty")]

        public int Quantity { get; set; }
        public Stock(string stockSymbol, string stockName, double price, int quantity)
       => (StockSymbol, StockName, Price, Quantity) = (stockSymbol, stockName, price, quantity);
        public Stock()
        {
        }
      

    }
}
