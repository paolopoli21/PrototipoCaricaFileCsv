using PicoSystems.Application.Contracts.Csv;
using PicoSystems.Domain.Models.Csv;

namespace PicoSystems.Infrastructure.Repository.Cvs
{
    public class GetAvgPricesEstimate : IGetAvgBrentOilPricesRepository
    {

        public IEnumerable<AvgBrentOilPrice> GetDataAvg()
        {
            return new List<AvgBrentOilPrice>();
        }


    }
}
