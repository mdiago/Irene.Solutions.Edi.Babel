using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Irene.Solutions.Edi.Babel.Facturae.V322
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.gob.es/formato/Versiones/Facturaev3_2_2.xml")]
    public class FactoringAssignmentDataType
    {

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AssigneeType Assignee { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Installment", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public InstallmentType[] PaymentDetails { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string FactoringAssignmentClauses { get; set; }

        [XmlElement("FactoringAssignmentDocument", Form = XmlSchemaForm.Unqualified)]
        public FactoringAssignmentDocumentType[] FactoringAssignmentDocument { get; set; }

    }
}
