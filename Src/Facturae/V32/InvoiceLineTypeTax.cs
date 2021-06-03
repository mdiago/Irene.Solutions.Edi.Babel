using System;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Irene.Solutions.Edi.Babel.Facturae.V32
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.facturae.es/Facturae/2009/v3.2/Facturae")]
    public class InvoiceLineTypeTax : TaxOutputType
    {
    }
}
