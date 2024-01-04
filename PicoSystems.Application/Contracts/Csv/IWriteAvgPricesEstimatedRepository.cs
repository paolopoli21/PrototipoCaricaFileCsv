using PicoSystems.Domain.Models.Csv;

namespace PicoSystems.Application.Contracts.Csv
{
    public interface IWriteAvgPricesEstimatedRepository
    {
        void WriteAvgPricesEstimatedToCsv(List<AvgBrentOilPrice> list);
    }
}
