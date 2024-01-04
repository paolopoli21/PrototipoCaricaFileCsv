using PicoSystems.Application.Contracts.Xml;
using System.Runtime.CompilerServices;

namespace PicoSystems.Infrastructure.Repository.Xml
{
    public class XmlObjectProxyRespository<T> : IXmlObjectRepository<T> where T : class
    {
        private readonly XmlObject<T> _xmlObject;

        public XmlObjectProxyRespository(string file)
        {
            if (_xmlObject == null) { 
                _xmlObject = new XmlObject<T>();
                _xmlObject.file = file;
            }
        }
        public T ILoadXml()
        {
            return _xmlObject.ILoadXml();
        }
    }
}
