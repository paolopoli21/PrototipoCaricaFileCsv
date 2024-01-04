using PicoSystems.Domain.Models.Csv;

namespace PicoSystems.Application.Contracts.Csv
{
    public interface IGetAvgBrentOilPricesRepository
    {
        IEnumerable<AvgBrentOilPrice> GetDataAvg();
    }
}
