using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Irene.Solutions.Edi.Babel.Facturae.V32
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2009/v3.2/Facturae")]
    public class InvoiceTotalsType : InvoiceTotalsBaseType
    {

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Discount", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public DiscountType[] GeneralDiscounts { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Charge", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public ChargeType[] GeneralSurcharges { get; set; }   


        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Subsidy", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public SubsidyType[] Subsidies { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("PaymentOnAccount", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public PaymentOnAccountType[] PaymentsOnAccount { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("ReimbursableExpenses", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public ReimbursableExpensesType[] ReimbursableExpenses { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public double TotalFinancialExpenses { get; set; }

        [XmlIgnore()]
        public bool TotalFinancialExpensesSpecified { get; set; }  

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public double TotalPaymentsOnAccount { get; set; }

        [XmlIgnore()]
        public bool TotalPaymentsOnAccountSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AmountsWithheldType AmountsWithheld { get; set; }   

    }
}
