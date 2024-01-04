using CsvHelper;
using PicoSystems.Application.Contracts.Csv;
using System.Globalization;

namespace PicoSystems.Infrastructure.Repository.Cvs
{
    public class WriteAvgPricesForYearCvsCvsRepository : IWriteAvgBrentOilPricesRepository
    {
        private readonly IGetAvgBrentOilPricesRepository _getAvgBrentOilPricesRepository;
        private readonly string _path;
        public WriteAvgPricesForYearCvsCvsRepository(IGetAvgBrentOilPricesRepository getAvgBrentOilPricesRepository, string path)
        {
            _getAvgBrentOilPricesRepository = getAvgBrentOilPricesRepository;
            _path = path;
        }

        public void WriteAvgPrices()
        {
            var avgList = _getAvgBrentOilPricesRepository.GetDataAvg();
            using (var writer = new StreamWriter(_path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.NextRecord();
                csv.WriteRecords(avgList);
                csv.NextRecord();
            }
        }
    }
}
