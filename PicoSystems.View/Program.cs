using PicoSystems.Domain.Models.Xml;
using PicoSystems.Infrastructure.Data;
using PicoSystems.Infrastructure.Repository.Xml;
using PicoSystems.Infrastructure.Utility;
using PicoSystems.Infrastructure.Repository.Cvs;
using PicoSystems.Application.Contracts.Csv;
using PicoSystems.Infrastructure;

RunInit();

static void RunInit()
{
    var pathBrentOilPrices = PicoSystemsSettings.pathBrentOilPrices;
    if (!Utility.ExistsPath(pathBrentOilPrices))
    {
        Print.LogError("Verificare il percorso del path!");
        return;
    }
    var context = new BrentOilPricesDbContext(pathBrentOilPrices);
    IGetAvgBrentOilPricesRepository listAvg;
    IPrintRepository print;
    IWriteAvgBrentOilPricesRepository writeAvg;

    Print.LogInfo("Premi P Stampa a video prezzi media mensile");
    Print.LogInfo("Premi Q Stampa a video prezzi media annuale");
    Print.LogInfo("Premi R Importa prezzi media mensile csv");
    Print.LogInfo("Premi Y Importa prezzi media annuale csv");
    Print.LogInfo("Premi Z Calcola prezzi stimati per anno e importa su csv");
    Print.LogInfo("Premi X Calcola prezzi stimati per mese e importa su csv");
    
    Print.LogInfo("Premi A e carica oggetto xml BidNotification.xml");
    Print.LogInfo("Premi B e carica oggetto xml BidSummittaIMGP.xml");

    Print.LogInfo("Premi E Esci");
    while (true)
    {
        var key = Console.ReadKey();
        Console.WriteLine("\n");
        switch (key.Key)
        {
            case ConsoleKey.P:
                Print.LogDati("Lista prezzi media mensile");
                listAvg = new GetAvgPriceForMonthRepository(context);
                var avgPricesMonth = listAvg.GetDataAvg();
                print = new PrintAvgPricesMonthRepository();
                print.PrintBy(avgPricesMonth);
                break;

            case ConsoleKey.Q:
                Print.LogDati("Lista prezzi media annuale");
                listAvg = new GetAvgPriceForYearRepository(context);
                var avgPricesYear = listAvg.GetDataAvg();
                print = new PrintAvgPricesYearRepository();
                print.PrintBy(avgPricesYear);
                break;

            case ConsoleKey.R:
                listAvg = new GetAvgPriceForMonthRepository(context);
                writeAvg = new WriteAvgPricesForMonthCvsRepository(listAvg, PicoSystemsSettings.pathBrentOilPricesForMonth);
                writeAvg.WriteAvgPrices();
                Print.LogSuccess("La scrittura del file Csv avvenuta con successo!");
                Print.LogSuccess("percorso: Infrastructure\\CSV_Files");
                break;

            case ConsoleKey.Y:
                listAvg = new GetAvgPriceForYearRepository(context);
                writeAvg = new WriteAvgPricesForYearCvsCvsRepository(listAvg, PicoSystemsSettings.pathBrentOilPricesForYear);
                writeAvg.WriteAvgPrices();
                Print.LogSuccess("La scrittura del file Csv avvenuta con successo!");
                Print.LogSuccess("percorso: Infrastructure\\CSV_Files");
                break;

            case ConsoleKey.Z:
                List<int> Xyears = new List<int>();
                List<decimal> YavgPricesYear = new List<decimal>();
                listAvg = new GetAvgPriceForYearRepository(context);
                RegressionPolinomial.LoadPricesToEstimatedYear(listAvg,out Xyears,out YavgPricesYear);
                int fromYear = 2020;
                int toYear = 2021;
                var listAvgEstimateYear = RegressionPolinomial.PricesEstimatedForYear(Xyears, YavgPricesYear, fromYear, toYear);
                var pathBrentOilPricesForYear = PicoSystemsSettings.pathBrentOilPricesForYear;
                if (!Utility.ExistsPath(pathBrentOilPricesForYear))
                {
                    Print.LogError("Verificare il percorso del path!");
                    break;
                }
                var writeObject = new WriteAvgPricesEstimatedForYearRepository(pathBrentOilPricesForYear);
                string title = $"Media di prezzi stimati Da {fromYear} a {toYear} data: {DateTime.Now.ToString("dd/MM/yyyy:HH:mm:ss")}"; 
                WriteTitleToCsv.WriteTitle(title, pathBrentOilPricesForYear);
                writeObject.WriteAvgPricesEstimatedToCsv(listAvgEstimateYear);

                Print.LogSuccess("La scrittura del file Csv avvenuta con successo!");
                Print.LogSuccess("percorso: Infrastructure\\CSV_Files\\BrentOilPricesForYear");
                break;

            case ConsoleKey.X:
                List<int> Xmonths = new List<int>();
                List<decimal> YavgPricesMonth = new List<decimal>();
                listAvg = new GetAvgPriceForMonthRepository(context);
                RegressionPolinomial.LoadPricesToEstimatedMonth(listAvg, out Xmonths, out YavgPricesMonth);
                int fromYear1 = 2020;
                int toYear1 = 2021;
                var listAvgEstimateMonth = RegressionPolinomial.PricesEstimatedForMonth (Xmonths, YavgPricesMonth, fromYear1, toYear1);
                var pathBrentOilPricesForMonth = PicoSystemsSettings.pathBrentOilPricesForMonth;
                if (!Utility.ExistsPath(pathBrentOilPricesForMonth))
                {
                    Print.LogError("Verificare il percorso del path!");
                    break;
                }
                var writeObject1 = new WriteAvgPricesEstimatedForYearRepository(pathBrentOilPricesForMonth);
                string title1 = $"Media di prezzi stimati Da {fromYear1} a {toYear1} data: {DateTime.Now.ToString("dd/MM/yyyy:HH:mm:ss")}";
                WriteTitleToCsv.WriteTitle(title1, pathBrentOilPricesForMonth);
                writeObject1.WriteAvgPricesEstimatedToCsv(listAvgEstimateMonth);

                Print.LogSuccess("La scrittura del file Csv avvenuta con successo!");
                Print.LogSuccess("percorso: Infrastructure\\CSV_Files\\BrentOilPricesForMonth.cvs");
                break;

            case ConsoleKey.A:
                var pathBindNotification = PicoSystemsSettings.pathBindNotification;
                if (!Utility.ExistsPath(pathBindNotification)) {
                    Print.LogError("Verificare il percorso del path!");
                    break;
                }
                var xmlObjectProxyRespository = new XmlObjectProxyRespository<BidNotificationRoot>(pathBindNotification);
                var bidNotification = xmlObjectProxyRespository.ILoadXml();
                if (bidNotification == null) {
                    Print.LogError("Problemi di caricamento!");
                    break;
                }
                Print.LogSuccess("il file xml BidNotification caricato!");
            break;
            
            case ConsoleKey.B:
                var pathBindBidSubmittalIMGP = PicoSystemsSettings.pathBindBidSubmittalIMGP;
                if (!Utility.ExistsPath(pathBindBidSubmittalIMGP))
                {
                    Print.LogError("Verificare il percorso del path!");
                    break;
                }
                var bidSubmittalMGP = new XmlObjectProxyRespository<BidSubmittaIMGP>(pathBindBidSubmittalIMGP);
                if (bidSubmittalMGP == null)
                {
                    Print.LogError("Problemi di caricamento!");
                    break;
                }
                Print.LogSuccess("il file xml BidSubmittaIMGP caricato con successo!");
                break;

            case ConsoleKey.E:
                Print.LogDati("Grazie per avere utilizzato il programma");
                return;
            default:
                Print.LogError("Nessuna funzinalità valida per questo tasto!");
                break;
        }
    }
}

