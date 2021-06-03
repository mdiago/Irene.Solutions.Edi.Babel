using System;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Irene.Solutions.Edi.Babel.Facturae.V32
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2009/v3.2/Facturae")]
    public class FactoringAssignmentDataType
    {

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AssigneeType Assignee { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Installment", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public InstallmentType[] PaymentDetails { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string FactoringAssignmentClauses { get; set; }

    }
}
