using System;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Irene.Solutions.Edi.Babel.Facturae.V30
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.facturae.es/Facturae/2007/v3.0/Facturae")]
    [XmlRoot(Namespace = "http://www.facturae.es/Facturae/2007/v3.0/Facturae", IsNullable = false)]
    public class Facturae : Edi.Babel.Facturae.Facturae
    {

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public FileHeaderType FileHeader { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Invoice", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public InvoiceType[] Invoices { get; set; }

    }
}
