using Irene.Solutions.Edi.Babel.Xml;
using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Irene.Solutions.Edi.Babel.Facturae.V30
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2007/v3.0/Facturae")]
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

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public double TotalPaymentsOnAccount { get; set; }

        [XmlIgnore()]
        public bool TotalPaymentsOnAccountSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AmountsWithheldType AmountsWithheld { get; set; }

        /// <summary>
        /// En la 3.0 no está
        /// </summary>
        [XmlElement(ElementName = "TotalReimbursableExpenses", Form = XmlSchemaForm.Unqualified)]
        public override string TotalReimbursableExpensesString
        {
            get
            {
                return null;
            }
            set
            {
                throw new InvalidOperationException("TotalReimbursableExpenses no válido para la versión 3.0");
            }
        }

    }
}
