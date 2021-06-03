using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Irene.Solutions.Edi.Babel.Xml;

namespace Irene.Solutions.Edi.Babel.Facturae.V32
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2009/v3.2/Facturae")]
    public class InvoiceLineType : InvoiceLineBaseType
    {
     
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public SpecialTaxableEventType SpecialTaxableEvent { get; set; }

    }
}
