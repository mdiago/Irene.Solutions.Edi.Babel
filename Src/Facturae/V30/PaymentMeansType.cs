using System;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Irene.Solutions.Edi.Babel.Facturae.V30
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2007/v3.0/Facturae")]
    public enum PaymentMeansType
    {


        [XmlEnum("01")]
        Item01,


        [XmlEnum("02")]
        Item02,


        [XmlEnum("03")]
        Item03,


        [XmlEnum("04")]
        Item04,


        [XmlEnum("05")]
        Item05,


        [XmlEnum("06")]
        Item06,


        [XmlEnum("07")]
        Item07,


        [XmlEnum("08")]
        Item08,


        [XmlEnum("09")]
        Item09,


        [XmlEnum("10")]
        Item10,


        [XmlEnum("11")]
        Item11,


        [XmlEnum("12")]
        Item12,


        [XmlEnum("13")]
        Item13,


        [XmlEnum("14")]
        Item14,


        [XmlEnum("15")]
        Item15,


        [XmlEnum("16")]
        Item16,
    }
}
