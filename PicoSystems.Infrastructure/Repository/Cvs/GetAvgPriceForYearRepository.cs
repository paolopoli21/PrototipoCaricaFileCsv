using PicoSystems.Application.Contracts.Csv;
using PicoSystems.Domain.Models.Csv;
using PicoSystems.Infrastructure.Data;

namespace PicoSystems.Infrastructure.Repository.Cvs
{
    public class GetAvgPriceForYearRepository : IGetAvgBrentOilPricesRepository
    {
        private readonly BrentOilPricesDbContext _brentOilPricesDbContext;
        public GetAvgPriceForYearRepository(BrentOilPricesDbContext brentOilPricesDbContext)
        {
            this._brentOilPricesDbContext = brentOilPricesDbContext;
        }
        public IEnumerable<AvgBrentOilPrice> GetDataAvg()
        {
            var allBrantOilPrices = this._brentOilPricesDbContext.GetAllBrentOilPrices();
            var listAvgYear = allBrantOilPrices
                .Select(x => new { x.Date.Year, x.Price })
                .GroupBy(x => new { x.Year })
                .Select(x => new { YearMonth = x.Key, Avg = x.Average(y => y.Price) }).ToList();

            foreach (var item in listAvgYear)
            {
                yield return new AvgBrentOilPrice
                {
                    YearMonth = new YearMonth
                    {
                        Month = "(1-12)",
                        Year = item.YearMonth.Year
                    },
                    Avg = item.Avg
                };
            }
        }
    }
}
