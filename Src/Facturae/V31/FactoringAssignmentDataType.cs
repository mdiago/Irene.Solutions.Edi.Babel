using System;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace Irene.Solutions.Edi.Babel.Facturae.V31
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public class FactoringAssignmentDataType
    {

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AssigneeType Assignee { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public PaymentDetailsType PaymentDetails { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string FactoringAssignmentClauses { get; set; }

    }
}
