using TaxCalculator.Domain.Contracts.Services;
using TaxCalculator.Domain.Enums;
using TaxCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxCalculator.Domain.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private const double TaxPercentage = 20d / 100d;

        public List<CalculatedTax> Calculate(IEnumerable<MarketOperation> operations)
        {
            var outputs = new List<CalculatedTax>();

            var balance = 0d;
            for (int index = 0; index < operations.Count(); index++)
            {
                var sale = operations.ElementAt(index);

                double tax = 0;

                if (sale.Operation == OperationType.Sell)
                {
                    var lastPurchases = operations.Where(x => x.Operation == OperationType.Buy).Take(index);
                    var amount = lastPurchases.Sum(x => x.Price);
                    var totalQuantity = lastPurchases.Sum(x => x.Quantity);
                    var weightedAverage = amount / totalQuantity;

                    var originalPrice = amount * sale.Quantity / totalQuantity;
                    var variation = sale.Price - originalPrice;

                    if (sale.UnitCost < weightedAverage)
                    {
                        balance -= Math.Abs(variation);
                    }
                    else if (balance + variation > 0 && sale.Price > 20000)
                    {
                        var difference = balance + variation;
                        balance += variation;
                        tax = difference * TaxPercentage;
                    }
                    else
                    {
                        balance += variation;
                    }
                }

                outputs.Add(new CalculatedTax { Tax = tax });
            }

            return outputs;
        }
    }
}