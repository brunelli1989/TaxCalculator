using TaxCalculator.Domain.Enums;
using TaxCalculator.Domain.Models;
using TaxCalculator.Domain.Services;
using System.Collections.Generic;
using Xunit;

namespace TaxCalculator.Test
{
    public class TaxCalculatorTest
    {
        private readonly TaxCalculatorService _calculator;

        public TaxCalculatorTest()
        {
            _calculator = new TaxCalculatorService();
        }

        [Fact]
        public void Calculate_Case1()
        {
            var MarketOperations = new List<MarketOperation>
            {
                new MarketOperation
                {
                    Operation = OperationType.Buy,
                    Quantity = 100,
                    UnitCost = 10
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 50,
                    UnitCost = 15
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 50,
                    UnitCost = 15
                }
            };

            var outputs = _calculator.Calculate(MarketOperations);

            Assert.Equal(MarketOperations.Count, outputs.Count);
            Assert.Equal(0, outputs[0].Tax);
            Assert.Equal(0, outputs[1].Tax);
            Assert.Equal(0, outputs[2].Tax);
        }

        [Fact]
        public void Calculate_Case2()
        {
            var MarketOperations = new List<MarketOperation>
            {
                new MarketOperation
                {
                    Operation = OperationType.Buy,
                    Quantity = 10000,
                    UnitCost = 10
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 5000,
                    UnitCost = 20
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 5000,
                    UnitCost = 5
                }
            };

            var outputs = _calculator.Calculate(MarketOperations);

            Assert.Equal(MarketOperations.Count, outputs.Count);
            Assert.Equal(0, outputs[0].Tax);
            Assert.Equal(10000, outputs[1].Tax);
            Assert.Equal(0, outputs[2].Tax);
        }

        [Fact]
        public void Calculate_Case3()
        {
            var MarketOperations = new List<MarketOperation>
            {
                new MarketOperation
                {
                    Operation = OperationType.Buy,
                    Quantity = 10000,
                    UnitCost = 10
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 5000,
                    UnitCost = 5
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 5000,
                    UnitCost = 20
                }
            };

            var outputs = _calculator.Calculate(MarketOperations);

            Assert.Equal(MarketOperations.Count, outputs.Count);
            Assert.Equal(0, outputs[0].Tax);
            Assert.Equal(0, outputs[1].Tax);
            Assert.Equal(5000, outputs[2].Tax);
        }

        [Fact]
        public void Calculate_Case4()
        {
            var MarketOperations = new List<MarketOperation>
            {
                new MarketOperation
                {
                    Operation = OperationType.Buy,
                    Quantity = 10000,
                    UnitCost = 10
                },
                new MarketOperation
                {
                    Operation = OperationType.Buy,
                    Quantity = 5000,
                    UnitCost = 25
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 10000,
                    UnitCost = 15
                }
            };

            var outputs = _calculator.Calculate(MarketOperations);

            Assert.Equal(MarketOperations.Count, outputs.Count);
            Assert.Equal(0, outputs[0].Tax);
            Assert.Equal(0, outputs[1].Tax);
            Assert.Equal(0, outputs[2].Tax);
        }

        [Fact]
        public void Calculate_Case5()
        {
            var MarketOperations = new List<MarketOperation>
            {
                new MarketOperation
                {
                    Operation = OperationType.Buy,
                    Quantity = 10000,
                    UnitCost = 10
                },
                new MarketOperation
                {
                    Operation = OperationType.Buy,
                    Quantity = 5000,
                    UnitCost = 25
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 10000,
                    UnitCost = 15
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 5000,
                    UnitCost = 25
                }
            };

            var outputs = _calculator.Calculate(MarketOperations);

            Assert.Equal(MarketOperations.Count, outputs.Count);
            Assert.Equal(0, outputs[0].Tax);
            Assert.Equal(0, outputs[1].Tax);
            Assert.Equal(0, outputs[2].Tax);
            Assert.Equal(10000, outputs[3].Tax);
        }

        [Fact]
        public void Calculate_Case6()
        {
            var MarketOperations = new List<MarketOperation>
            {
                new MarketOperation
                {
                    Operation = OperationType.Buy,
                    Quantity = 10000,
                    UnitCost = 10
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 5000,
                    UnitCost = 2
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 2000,
                    UnitCost = 20
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 2000,
                    UnitCost = 20
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 1000,
                    UnitCost = 25
                }
            };

            var outputs = _calculator.Calculate(MarketOperations);

            Assert.Equal(MarketOperations.Count, outputs.Count);
            Assert.Equal(0, outputs[0].Tax);
            Assert.Equal(0, outputs[1].Tax);
            Assert.Equal(0, outputs[2].Tax);
            Assert.Equal(0, outputs[3].Tax);
            Assert.Equal(3000, outputs[4].Tax);
        }

        [Fact]
        public void Calculate_MyCase()
        {
            var MarketOperations = new List<MarketOperation>
            {
                new MarketOperation
                {
                    Operation = OperationType.Buy,
                    Quantity = 10000,
                    UnitCost = 10
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 5000,
                    UnitCost = 2
                },
                new MarketOperation
                {
                    Operation = OperationType.Buy,
                    Quantity = 5000,
                    UnitCost = 4
                },
                new MarketOperation
                {
                    Operation = OperationType.Sell,
                    Quantity = 15000,
                    UnitCost = 20
                }
            };

            //7,5
            var outputs = _calculator.Calculate(MarketOperations);

            Assert.Equal(MarketOperations.Count, outputs.Count);
            Assert.Equal(0, outputs[0].Tax);
            Assert.Equal(0, outputs[1].Tax);
            Assert.Equal(0, outputs[2].Tax);
            Assert.Equal(28000, outputs[3].Tax);
        }
    }
}
