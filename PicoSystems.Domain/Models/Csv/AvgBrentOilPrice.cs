namespace PicoSystems.Domain.Models.Csv
{
    public class AvgBrentOilPrice
    {
        public YearMonth YearMonth { get; set; }
        public decimal Avg { get; set; }
    }
    public class YearMonth
    {
        public int Year { get; set; }
        public string Month { get; set; }
    }
}
