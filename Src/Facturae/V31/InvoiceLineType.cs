using System;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace Irene.Solutions.Edi.Babel.Facturae.V31
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public class InvoiceLineType : InvoiceLineBaseType
    {

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public double PurchaseOrderReference { get; set; }

        [XmlIgnore()]
        public bool PurchaseOrderReferenceSpecified { get; set; }
    

    }
}
