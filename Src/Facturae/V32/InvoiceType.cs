using System;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Irene.Solutions.Edi.Babel.Facturae.V32
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2009/v3.2/Facturae")]
    public class InvoiceType
    {

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public InvoiceHeaderType InvoiceHeader { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public InvoiceIssueDataType InvoiceIssueData { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Tax", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public TaxOutputType[] TaxesOutputs { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Tax", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public TaxType[] TaxesWithheld { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public InvoiceTotalsType InvoiceTotals { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("InvoiceLine", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public InvoiceLineType[] Items { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Installment", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public InstallmentType[] PaymentDetails { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("LegalReference", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public string[] LegalLiterals { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AdditionalDataType AdditionalData { get; set; }

    }
}
