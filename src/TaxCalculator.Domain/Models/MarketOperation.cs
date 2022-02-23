using TaxCalculator.Domain.Enums;
using System.Diagnostics;

namespace TaxCalculator.Domain.Models
{
    [DebuggerDisplay("{Operation} -> {Quantity} * {UnitCost} = {Price}")]
    public class MarketOperation
    {
        public OperationType Operation { get; set; }
        public double UnitCost { get; set; }
        public int Quantity { get; set; }

        public double Price
        {
            get { return Quantity * UnitCost; }
        }
    }
}