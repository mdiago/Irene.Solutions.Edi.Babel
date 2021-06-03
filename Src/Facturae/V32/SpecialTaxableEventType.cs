using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Irene.Solutions.Edi.Babel.Facturae.V32
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2009/v3.2/Facturae")]
    public class SpecialTaxableEventType
    {

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public SpecialTaxableEventCodeType SpecialTaxableEventCode { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string SpecialTaxableEventReason { get; set; }

    }
}
