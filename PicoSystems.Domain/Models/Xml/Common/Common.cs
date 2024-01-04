using System.Xml.Serialization;

namespace PicoSystems.Domain.Models.Xml.Common

{
    [XmlRoot(ElementName = "TradingPartner")]
    public class TradingPartner
    {
        [XmlElement(ElementName = "CompanyName")]
        public string CompanyName { get; set; }

        [XmlElement(ElementName = "CompanyIdentifier")]
        public string CompanyIdentifier { get; set; }
    }

    [XmlRoot(ElementName = "Sender")]
    public class Sender
    {

        [XmlElement(ElementName = "TradingPartner")]
        public TradingPartner TradingPartner { get; set; }
    }

    [XmlRoot(ElementName = "Recipient")]
    public class Recipient
    {

        [XmlElement(ElementName = "TradingPartner")]
        public TradingPartner TradingPartner { get; set; }
    }

    [XmlRoot(ElementName = "TradingPartnerDirectory")]
    public class TradingPartnerDirectory
    {
        [XmlElement(ElementName = "Sender")]
        public Sender Sender { get; set; }

        [XmlElement(ElementName = "Recipient")]
        public Recipient Recipient { get; set; }
    }

    [XmlRoot(ElementName = "PIPTransaction")]
    public class PIPTransaction
    {
        [XmlElement(ElementName = "BidNotification")]
        public BidNotification BidNotification { get; set; }

        [XmlAttribute(AttributeName = "ReferenceNumber")]
        public double ReferenceNumber { get; set; }

        [XmlAttribute(AttributeName = "InboundMessageCreationDate")]
        public int InboundMessageCreationDate { get; set; }

        [XmlAttribute(AttributeName = "InboundMessageCreationTime")]
        public int InboundMessageCreationTime { get; set; }

        [XmlAttribute(AttributeName = "OriginalReferenceNumber")]
        public double OriginalReferenceNumber { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
