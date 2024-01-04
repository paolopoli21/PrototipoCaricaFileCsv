namespace PicoSystems.Application.Contracts.Xml
{
    public interface IXmlObjectRepository<T>
    {
       T ILoadXml();
    }
}
