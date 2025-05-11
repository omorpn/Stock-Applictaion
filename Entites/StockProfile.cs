using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class StockProfile
    {
       
            public string Country { get; set; }
            public string Currency { get; set; }
            public string EstimateCurrency { get; set; }
            public string Exchange { get; set; }
            public string FinnhubIndustry { get; set; }
            public DateTime? Ipo { get; set; }
            public string Logo { get; set; }
            public double MarketCapitalization { get; set; }  // Or decimal, depending on your needs
            public string Name { get; set; }
            public string Phone { get; set; }
            public double ShareOutstanding { get; set; }
            public string Ticker { get; set; }
            public string Weburl { get; set; }
        

    }
}
