using CsvHelper;
using CsvHelper.Configuration;
using PicoSystems.Application.Contracts.Csv;
using PicoSystems.Domain.Models.Csv;
using System.Globalization;

namespace PicoSystems.Infrastructure.Repository.Cvs
{
    public class WriteAvgPricesEstimatedForYearRepository : IWriteAvgPricesEstimatedRepository
    {
        private readonly string _path;
        public WriteAvgPricesEstimatedForYearRepository(string path)
        {
            _path = path;
        }

        public void WriteAvgPricesEstimatedToCsv(List<AvgBrentOilPrice> list)
        {
            CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = !File.Exists(_path)
            };
            using (FileStream fileStream = new FileStream(_path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    using (var csv = new CsvWriter(streamWriter, csvConfig))
                    {
                        csv.NextRecord();
                        csv.WriteRecords(list);
                        csv.NextRecord();
                    }
                }
            }
        }
    }
}
