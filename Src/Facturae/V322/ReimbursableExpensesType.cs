using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Irene.Solutions.Edi.Babel.Facturae.V31
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
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
