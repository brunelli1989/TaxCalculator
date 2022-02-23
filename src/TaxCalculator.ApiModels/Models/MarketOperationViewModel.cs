using Newtonsoft.Json;

namespace TaxCalculator.ApiModels.Models
{
    public class MarketOperationViewModel
    {
        public string Operation { get; set; }

        [JsonProperty("unit-cost")]
        public double UnitCost { get; set; }

        public int Quantity { get; set; }
    }
}
