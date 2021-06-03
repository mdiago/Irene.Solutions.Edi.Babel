using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Irene.Solutions.Edi.Babel.Facturae.V322
{


    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.gob.es/formato/Versiones/Facturaev3_2_2.xml")]
    public class InvoiceLineType : InvoiceLineBaseType
    {


        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public SpecialTaxableEventType SpecialTaxableEvent { get; set; }


    }
}
