using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Irene.Solutions.Edi.Babel.Facturae.V322
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.facturae.gob.es/formato/Versiones/Facturaev3_2_2.xml")]
    [XmlRoot(Namespace = "http://www.facturae.gob.es/formato/Versiones/Facturaev3_2_2.xml", IsNullable = false)]
    public class Facturae : Edi.Babel.Facturae.Facturae
    {

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public FileHeaderType FileHeader { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public PartiesType Parties { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Invoice", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public InvoiceType[] Invoices { get; set; }

    }


}
