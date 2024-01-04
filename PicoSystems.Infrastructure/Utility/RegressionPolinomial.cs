using PicoSystems.Application.Contracts.Csv;
using PicoSystems.Domain.Models.Csv;

namespace PicoSystems.Infrastructure.Utility
{
    public static class RegressionPolinomial
    {
        public static void LoadPricesToEstimatedYear(IGetAvgBrentOilPricesRepository listAvg, out List<int> Xyears, out List<decimal> Yprices) {
            Xyears = new List<int>();
            Yprices = new List<decimal>();
            
            foreach (var item in listAvg.GetDataAvg())
            {
                Xyears.Add(item.YearMonth.Year);
                Yprices.Add(item.Avg);
            };

        }

        public static void LoadPricesToEstimatedMonth(IGetAvgBrentOilPricesRepository listAvg, out List<int> Xmonths, out List<decimal> Yprices)
        {
            Xmonths = new List<int>();
            Yprices = new List<decimal>();

            foreach (var item in listAvg.GetDataAvg())
            {
                int month = Convert.ToInt32(item.YearMonth.Month);
                Xmonths.Add(month);
                Yprices.Add(item.Avg);
            };

        }
        public static List<AvgBrentOilPrice> PricesEstimatedForYear(List<int> xValues, List<decimal> yValues, int startYear, int endYear)
        {
            var list = new List<AvgBrentOilPrice>();
            var rangeNums = GetYearsInRange(startYear, endYear);
            foreach (int futureTime in rangeNums)
            {
                var result = PredictPrice(xValues, yValues, futureTime);
                list.Add(new AvgBrentOilPrice
                {
                    YearMonth = new YearMonth
                    {
                        Month = "(1-12)",
                        Year = futureTime
                    },
                    Avg = result
                });
            }
            return list;
        }

        public static List<AvgBrentOilPrice> PricesEstimatedForMonth(List<int> xValues, List<decimal> yValues, int startYear, int endYear)
        {
            var list = new List<AvgBrentOilPrice>();
            var rangeNums = GetMonthsInRange(startYear, endYear);
            int year = startYear;
            foreach (int futureTime in rangeNums)
            {
                var result = PredictPrice(xValues, yValues, futureTime);
                list.Add(new AvgBrentOilPrice
                {
                    YearMonth = new YearMonth
                    {
                        Month = futureTime.ToString(),
                        Year = year
                    },
                    Avg = result
                });
                if (futureTime == 12) {
                    year++;
                }
            }
            return list;
        }

        private static decimal PredictPrice(List<int> xValues, List<decimal> yValues, int futureTime)
        {
            int n = xValues.Count();
            decimal sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0;

            for (int i = 0; i < n; i++)
            {
                sumX += xValues[i];
                sumY += yValues[i];
                sumXY += xValues[i] * yValues[i];
                sumX2 += xValues[i] * xValues[i];
            }

            decimal slope = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            decimal intercept = (sumY - slope * sumX) / n;
            decimal estimatedPrice = slope * futureTime + intercept;
            return estimatedPrice;
        }

        private static int[] GetYearsInRange(int startYear, int endYear)
        {
            if (startYear > endYear)
            {
                throw new ArgumentException("Start year must be less than or equal to end year.");
            }
            int numberOfYears = endYear - startYear + 1;
            int[] yearsInRange = new int[numberOfYears];

            for (int i = 0; i < numberOfYears; i++)
            {
                yearsInRange[i] = startYear + i;
            }
            return yearsInRange;
        }

        private static int[] GetMonthsInRange(int startYear, int endYear)
        {
            if (startYear > endYear)
            {
                throw new ArgumentException("Start year must be less than or equal to end year.");
            }

            var monthsInRange = new List<int>();

            for (int year = startYear; year <= endYear; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    monthsInRange.Add(month);
                }
            }
            return monthsInRange.ToArray();
        }
    }
}
