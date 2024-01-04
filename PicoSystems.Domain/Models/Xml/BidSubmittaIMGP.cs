using System.Xml.Serialization;

namespace PicoSystems.Domain.Models.Xml
{

    [XmlRoot(ElementName = "PIPEDocument")]
    public class BidSubmittaIMGP
    {
        [XmlElement(ElementName = "TradingPartnerDirectory")]
        public TradingPartnerDirectory TradingPartnerDirectory { get; set; }

        [XmlElement(ElementName = "PIPTransaction")]
        public List<PIPTransactionMgp> PIPTransaction { get; set; }

    }

    [XmlRoot(ElementName = "TradingPartner")]
    public class TradingPartner
    {

        [XmlElement(ElementName = "CompanyName")]
        public string CompanyName { get; set; }

        [XmlElement(ElementName = "CompanyIdentifier")]
        public string CompanyIdentifier { get; set; }

        [XmlAttribute(AttributeName = "PartnerType")]
        public string PartnerType { get; set; }

        [XmlText]
        public string Text { get; set; }
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

    [XmlRoot(ElementName = "BidQuantity")]
    public class BidQuantity
    {

        [XmlAttribute(AttributeName = "UnitOfMeasure")]
        public string UnitOfMeasure { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "BidSubmittal")]
    public class BidSubmittal
    {
        [XmlElement(ElementName = "Market")]
        public string Market { get; set; }

        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }

        [XmlElement(ElementName = "Hour")]
        public string Hour { get; set; }

        [XmlElement(ElementName = "UnitReferenceNumber")]
        public string UnitReferenceNumber { get; set; }

        [XmlElement(ElementName = "BidQuantity")]
        public BidQuantity BidQuantity { get; set; }

        [XmlElement(ElementName = "EnergyPrice")]
        public string EnergyPrice { get; set; }

        [XmlAttribute(AttributeName = "Purpose")]
        public string Purpose { get; set; }

        [XmlAttribute(AttributeName = "PredefinedOffer")]
        public string PredefinedOffer { get; set; }

        [XmlAttribute(AttributeName = "ReplacementIndicator")]
        public string ReplacementIndicator { get; set; }

    }

    [XmlRoot(ElementName = "PIPTransaction")]
    public class PIPTransactionMgp
    {

        [XmlElement(ElementName = "BidSubmittal")]
        public BidSubmittal BidSubmittal { get; set; }
    }





}
