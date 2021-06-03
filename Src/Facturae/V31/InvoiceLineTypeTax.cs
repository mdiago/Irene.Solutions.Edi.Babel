using System;
using System.Xml.Serialization;

namespace Irene.Solutions.Edi.Babel.Facturae.V31
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public class InvoiceLineTypeTax : TaxOutputType
    {
    }
}
