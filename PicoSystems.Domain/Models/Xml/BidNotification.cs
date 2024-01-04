using System.Xml.Serialization;

namespace PicoSystems.Domain.Models.Xml
{
    [Serializable()]
    [XmlRoot(ElementName = "PIPEDocument")]
    public class BidNotificationRoot
    {
        [XmlElement(ElementName = "TradingPartnerDirectory")]
        public TradingPartnerDirectory TradingPartnerDirectory { get; set; }

        [XmlElement(ElementName = "PIPTransaction")]
        public PIPTransaction PIPTransaction { get; set; }
    }

    [XmlRoot(ElementName = "PIPTransaction")]
    public class PIPTransaction
    {
        [XmlElement(ElementName = "BidNotification")]
        public BidNotification BidNotification { get; set; }

        [XmlAttribute(AttributeName = "ReferenceNumber")]
        public string ReferenceNumber { get; set; }

        [XmlAttribute(AttributeName = "InboundMessageCreationDate")]
        public int InboundMessageCreationDate { get; set; }

        [XmlAttribute(AttributeName = "InboundMessageCreationTime")]
        public int InboundMessageCreationTime { get; set; }

        [XmlAttribute(AttributeName = "OriginalReferenceNumber")]
        public string OriginalReferenceNumber { get; set; }

        //[XmlText]
        //public string Text { get; set; }

    }

    [XmlRoot(ElementName = "BidNotification")]
    public class BidNotification
    {

        [XmlElement(ElementName = "Market")]
        public string Market { get; set; }

        [XmlElement(ElementName = "GMEReferenceNumber")]
        public string GMEReferenceNumber { get; set; }

        [XmlElement(ElementName = "Date")]
        public int Date { get; set; }

        [XmlElement(ElementName = "Hour")]
        public int Hour { get; set; }

        [XmlElement(ElementName = "UnitReferenceNumber")]
        public string UnitReferenceNumber { get; set; }

        [XmlElement(ElementName = "AwardedQuantity")]
        public AwardedQuantity AwardedQuantity { get; set; }

        [XmlElement(ElementName = "AwardedPrice")]
        public string AwardedPrice { get; set; }

        [XmlElement(ElementName = "AwardedValue")]
        public string AwardedValue { get; set; }

        [XmlAttribute(AttributeName = "Status")]
        public string Status { get; set; }

        [XmlAttribute(AttributeName = "Purpose")]
        public string Purpose { get; set; }

        [XmlAttribute(AttributeName = "PartialAcceptedQuantityIndicator")]
        public string PartialAcceptedQuantityIndicator { get; set; }

        //[XmlText]
        //public string Text { get; set; }
    }


    //[XmlRoot(ElementName = "BidNotification")]
    //public class BidNotification
    //{
    //    //[XmlElement(ElementName = "Market")]
    //    //public string Market { get; set; }

    //    //[XmlElement(ElementName = "GMEReferenceNumber")]
    //    //public string GMEReferenceNumber { get; set; }

    //    //[XmlElement(ElementName = "Date")]
    //    //public string Date { get; set; }

    //    //[XmlElement(ElementName = "Hour")]
    //    //public int Hour { get; set; }

    //    //[XmlAttribute(AttributeName = "UnitReferenceNumber")]
    //    //public string UnitReferenceNumber { get; set; }

    //    //[XmlAttribute(AttributeName = "AwardedQuantity")]
    //    //public AwardedQuantity AwardedQuantity { get; set; }

    //    //[XmlAttribute(AttributeName = "AwardedPrice")]
    //    //public string AwardedPrice { get; set; }

    //    //[XmlAttribute(AttributeName = "AwardedValue")]
    //    //public string AwardedValue { get; set; }
    //}

    [XmlRoot(ElementName = "AwardedQuantity")]
    public class AwardedQuantity
    {

        [XmlAttribute(AttributeName = "UnitOfMeasure")]
        public string UnitOfMeasure { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
