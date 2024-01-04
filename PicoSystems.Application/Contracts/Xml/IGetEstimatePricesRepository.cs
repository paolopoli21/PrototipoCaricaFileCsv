namespace PicoSystems.Application.Contracts.Xml
{
    public interface IGetEstimatePricesRepository
    {
        double[] GetEstimatePrices(double[] xValues, double[] yValues, double futureTime);
    }
}
