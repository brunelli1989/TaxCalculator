using TaxCalculator.Domain.Models;
using System.Collections.Generic;

namespace TaxCalculator.Domain.Contracts.Services
{
    public interface ITaxCalculatorService
    {
        /// <summary>
        /// Calcula diversas taxas para diversas operações.
        /// </summary>
        /// <param name="operations">Lista de operações</param>
        /// <returns>Lista de taxas</returns>
        List<CalculatedTax> Calculate(IEnumerable<MarketOperation> operations);
    }
}