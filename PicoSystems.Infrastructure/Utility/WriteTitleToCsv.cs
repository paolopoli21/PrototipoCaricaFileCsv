using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace PicoSystems.Infrastructure.Utility
{
    public static class WriteTitleToCsv
    {
        public static void WriteTitle(string text, string path)
        {
            CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = !File.Exists(path)
            };
            using (FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    using (var csv = new CsvWriter(streamWriter, csvConfig))
                    {
                        csv.NextRecord();
                        csv.WriteComment(text);
                        csv.NextRecord();
                    }
                }
            }
        }
    }
}
