using PicoSystems.Application.Contracts.Xml;
using System.Xml.Serialization;

namespace PicoSystems.Infrastructure.Repository.Xml
{
    public class XmlObject<T> : IXmlObjectRepository<T> where T : class
    {
        public string file { get; set; }
        private T _object;
        public T ILoadXml()
        {
            using (var sw = new StreamReader(file))
            {
                try
                {
                    _object = (T)new XmlSerializer(typeof(T)).Deserialize(sw);
                    return _object;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
