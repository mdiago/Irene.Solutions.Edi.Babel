using System;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Irene.Solutions.Edi.Babel.Facturae.V32
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2009/v3.2/Facturae")]
    public class ReimbursableExpensesType
    {

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public TaxIdentificationType ReimbursableExpensesSellerParty { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public TaxIdentificationType ReimbursableExpensesBuyerParty { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime IssueDate { get; set; }

        [XmlIgnore()]
        public bool IssueDateSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string InvoiceNumber { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string InvoiceSeriesCode { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public double ReimbursableExpensesAmount { get; set; }

    }
}
