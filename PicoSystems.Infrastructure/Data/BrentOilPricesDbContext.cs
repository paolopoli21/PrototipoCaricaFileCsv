using CsvHelper;
using PicoSystems.Domain.Models.Csv;
using System.Globalization;

namespace PicoSystems.Infrastructure.Data
{
    public class BrentOilPricesDbContext
    {
        private List<BrentOilPrice> _brentOilPricesDbContext { get; set; }
        private readonly string _path;
        public BrentOilPricesDbContext(string path)
        {
            _brentOilPricesDbContext = new List<BrentOilPrice>();
            _path = path;
        }

        public IEnumerable<BrentOilPrice> GetAllBrentOilPrices() {

            using (var streamReader = new StreamReader(@"D:\Software\PicoSystemsProject\PicoSystems.Infrastructure\Db\BrentOilPrices.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    this._brentOilPricesDbContext = csvReader.GetRecords<BrentOilPrice>().ToList();
                }
            }
            return this._brentOilPricesDbContext;
        }
    }
}
