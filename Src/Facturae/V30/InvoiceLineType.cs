using System;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Irene.Solutions.Edi.Babel.Facturae.V30
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2007/v3.0/Facturae")]
    public class InvoiceLineType : InvoiceLineBaseType
    {

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public double PurchaseOrderReference { get; set; }

        [XmlIgnore()]
        public bool PurchaseOrderReferenceSpecified { get; set; }




    }
}
