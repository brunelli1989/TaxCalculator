using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TaxCalculator.ApiModels.Models;
using TaxCalculator.Domain.Contracts.Services;
using TaxCalculator.Domain.Models;
using TaxCalculator.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxCalculator
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            
            var inputJson = args != null && args.Length > 0 ? args[0] : Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputJson))
            {
                Console.WriteLine("Vazio não é permitido.");
                return;
            }

            IEnumerable<MarketOperationViewModel> inputOperations = null;
            try
            {
                inputOperations = JsonConvert.DeserializeObject<IEnumerable<MarketOperationViewModel>>(inputJson).Where(x => x != null).ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("JSON invalido.");
                return;
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MarketOperationViewModel, MarketOperation>();
                cfg.CreateMap<CalculatedTax, CalculatedTaxViewModel>();
            });

            IMapper mapper = config.CreateMapper();

            ITaxCalculatorService calculator = new TaxCalculatorService();

            var operations = mapper.Map<List<MarketOperation>>(inputOperations);
            var marketOperations = calculator.Calculate(operations);

            var taxes = mapper.Map<List<CalculatedTaxViewModel>>(marketOperations);

            var outputJson = JsonConvert.SerializeObject(taxes);

            Console.WriteLine(outputJson);
        }
    }
}