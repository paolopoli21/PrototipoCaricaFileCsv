using PicoSystems.Application.Contracts.Csv;
using PicoSystems.Domain.Models.Csv;
using PicoSystems.Infrastructure.Data;

namespace PicoSystems.Infrastructure.Repository.Cvs
{
    public class GetAvgPriceForMonthRepository : IGetAvgBrentOilPricesRepository
    {
        private readonly BrentOilPricesDbContext _brentOilPricesDbContext;

        public GetAvgPriceForMonthRepository(BrentOilPricesDbContext brentOilPricesDbContext)
        {
            _brentOilPricesDbContext = brentOilPricesDbContext;
        }

        public IEnumerable<AvgBrentOilPrice> GetDataAvg()
        {
            var allBrantOilPrices = this._brentOilPricesDbContext.GetAllBrentOilPrices();
            var listAvgMonth = allBrantOilPrices
                .Select(x => new { x.Date.Month, x.Price, x.Date.Year })
                .GroupBy(x => new { x.Month, x.Year })
                .Select(x => new { YearMonth = x.Key, Avg = x.Average(y => y.Price) }).ToList();

            foreach (var item in listAvgMonth)
            {
                yield return new AvgBrentOilPrice
                {
                    YearMonth = new YearMonth
                    {
                        Month = item.YearMonth.Month.ToString(),
                        Year = item.YearMonth.Year
                    },
                    Avg = item.Avg
                };
            }
        }

    }
}
