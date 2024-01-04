using System.Reflection;

namespace PicoSystems.Infrastructure
{
    public static class PicoSystemsSettings
    {

        private static string relativeBrentOilPricesPath = @"..\..\..\..\PicoSystems.Infrastructure\Db\BrentOilPrices.csv";
        public static string pathBrentOilPrices = Path.GetFullPath(relativeBrentOilPricesPath);

        private static string relativeBrentOilPricesForMonthPath = @"..\..\..\..\PicoSystems.Infrastructure\CSV_Files\BrentOilPricesForMonth.csv";
        public static string pathBrentOilPricesForMonth = Path.GetFullPath(relativeBrentOilPricesForMonthPath);


        private static string relativeBrentOilPricesForYearPath = @"..\..\..\..\PicoSystems.Infrastructure\CSV_Files\BrentOilPricesForYear.csv";
        public static string pathBrentOilPricesForYear = Path.GetFullPath(relativeBrentOilPricesForYearPath);


        private static string relativeBidNotificationPath = @"..\..\..\..\PicoSystems.Infrastructure\Xml\BidNotification.xml";
        public static string pathBindNotification = Path.GetFullPath(relativeBidNotificationPath);

        private static string relativeBidSubmittalMGPPath = @"..\..\..\..\PicoSystems.Infrastructure\Xml\BidSubmittalMGP.xml";
        public static string pathBindBidSubmittalIMGP = Path.GetFullPath(relativeBidSubmittalMGPPath);
    }
}
