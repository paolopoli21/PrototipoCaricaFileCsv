using PicoSystems.Application.Contracts.Csv;
using PicoSystems.Domain.Models.Csv;

namespace PicoSystems.Infrastructure.Repository.Cvs
{
    public class PrintAvgPricesMonthRepository : IPrintRepository
    {
        public void PrintBy(IEnumerable<AvgBrentOilPrice> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.YearMonth.Year} - {item.YearMonth.Month} - {item.Avg}");
            }
        }
    }
}
