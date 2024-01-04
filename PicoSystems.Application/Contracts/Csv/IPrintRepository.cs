using PicoSystems.Domain.Models.Csv;

namespace PicoSystems.Application.Contracts.Csv
{
    public interface IPrintRepository
    {
        void PrintBy(IEnumerable<AvgBrentOilPrice> list);
    }
}
