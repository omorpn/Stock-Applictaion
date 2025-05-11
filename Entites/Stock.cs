using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entites
{
    public class Stock
    {
        [Required(ErrorMessage ="{0} can't be empty")]
        [JsonPropertyName("ticker")]
        public string? StockSymbol { get; set; }
        [Required(ErrorMessage = "{0} can't be empty")]
        [JsonPropertyName("name")]

        public string? StockName { get; set; }
        [Required(ErrorMessage = "{0} can't be empty")]
        [JsonPropertyName("c")]
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
