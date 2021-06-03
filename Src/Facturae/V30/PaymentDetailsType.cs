using System;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Irene.Solutions.Edi.Babel.Facturae.V30
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2007/v3.0/Facturae")]
    public class PaymentDetailsType
    {

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime AssignmentDuePaymentDate { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string AssignmentPaymentMeans { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string IBAN { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PaymentReference { get; set; }

    }
}
