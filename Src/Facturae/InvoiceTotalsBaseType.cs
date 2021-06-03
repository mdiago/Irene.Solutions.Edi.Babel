using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Irene.Solutions.Edi.Babel.Xml;

namespace Irene.Solutions.Edi.Babel.Facturae
{

    /// <summary>
    /// Clase base para InvoiceTotalsBaseType. De ella derivan los InvoiceTotals
    /// de cada una de las versiones: 3.0, 3.1, 3.2, 3.2.2
    /// </summary>
    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2009/v3.2/Facturae")]
    public class InvoiceTotalsBaseType
    {

        /// <summary>
        /// Importe bruto
        /// </summary>
        [XmlIgnore]
        public decimal TotalGrossAmount { get; set; }

        /// <summary>
        /// Representación en dos decimales del importe bruto.
        /// </summary>
        [XmlElement(ElementName = "TotalGrossAmount", Form = XmlSchemaForm.Unqualified)]
        public string TotalGrossAmountString
        {
            get
            {
                return XmlParser.FromDecimal(TotalGrossAmount);
            }
            set
            {
                TotalGrossAmount = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// Total descuentos
        /// </summary>
        [XmlIgnore]
        public decimal TotalGeneralDiscounts { get; set; }

        /// <summary>
        /// Representación en dos decimales de total descuentos.
        /// </summary>
        [XmlElement(ElementName = "TotalGeneralDiscounts", Form = XmlSchemaForm.Unqualified)]
        public string TotalGeneralDiscountsString
        {
            get
            {
                return XmlParser.FromDecimal(TotalGeneralDiscounts);
            }
            set
            {
                TotalGeneralDiscounts = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// Total cargos.
        /// </summary>
        [XmlIgnore]
        public decimal TotalGeneralSurcharges { get; set; }

        /// <summary>
        /// Total cargos con dos decimales.
        /// </summary>
        [XmlElement(ElementName = "TotalGeneralSurcharges", Form = XmlSchemaForm.Unqualified)]
        public string TotalGeneralSurchargesString
        {
            get
            {
                return XmlParser.FromDecimal(TotalGeneralSurcharges);
            }
            set
            {
                TotalGeneralSurcharges = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// Bruto antes de impuestos.
        /// </summary>
        [XmlIgnore]
        public decimal TotalGrossAmountBeforeTaxes { get; set; }

        /// <summary>
        /// Bruto antes de impuestos dos decimales.
        /// </summary>
        [XmlElement(ElementName = "TotalGrossAmountBeforeTaxes", Form = XmlSchemaForm.Unqualified)]
        public string TotalGrossAmountBeforeTaxesString
        {
            get
            {
                return XmlParser.FromDecimal(TotalGrossAmountBeforeTaxes);
            }
            set
            {
                TotalGrossAmountBeforeTaxes = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// Total impuestos soportados.
        /// </summary>
        [XmlIgnore]
        public decimal TotalTaxOutputs { get; set; }

        /// <summary>
        /// Total impuestos soportados dos decimales.
        /// </summary>
        [XmlElement(ElementName = "TotalTaxOutputs", Form = XmlSchemaForm.Unqualified)]
        public string TotalTaxOutputsString
        {
            get
            {
                return XmlParser.FromDecimal(TotalTaxOutputs);
            }
            set
            {
                TotalTaxOutputs = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// Total impuestos retenidos.
        /// </summary>
        [XmlIgnore]
        public decimal TotalTaxesWithheld { get; set; }

        /// <summary>
        /// Representación dos decimales impuestos retenidos totales.
        /// </summary>
        [XmlElement(ElementName = "TotalTaxesWithheld", Form = XmlSchemaForm.Unqualified)]
        public string TotalTaxesWithheldString
        {
            get
            {
                return XmlParser.FromDecimal(TotalTaxesWithheld);
            }
            set
            {
                TotalTaxesWithheld = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// Total factura.
        /// </summary>
        [XmlIgnore]
        public decimal InvoiceTotal { get; set; }

        /// <summary>
        /// Total factura con dos decimales.
        /// </summary>
        [XmlElement(ElementName = "InvoiceTotal", Form = XmlSchemaForm.Unqualified)]
        public string InvoiceTotalString
        {
            get
            {
                return XmlParser.FromDecimal(InvoiceTotal);
            }
            set
            {
                InvoiceTotal = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// Total importe pendiente.
        /// </summary>
        [XmlIgnore]
        public decimal TotalOutstandingAmount { get; set; }

        /// <summary>
        /// Total importe pendiente dos decimales.
        /// </summary>
        [XmlElement(ElementName = "TotalOutstandingAmount", Form = XmlSchemaForm.Unqualified)]
        public string TotalOutstandingAmountString
        {
            get
            {
                return XmlParser.FromDecimal(TotalOutstandingAmount);
            }
            set
            {
                TotalOutstandingAmount = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// Total importe ejecutable.
        /// </summary>
        [XmlIgnore]
        public decimal TotalExecutableAmount { get; set; }

        /// <summary>
        /// Total importe ejecutable dos decimales.
        /// </summary>
        [XmlElement(ElementName = "TotalExecutableAmount", Form = XmlSchemaForm.Unqualified)]
        public string TotalExecutableAmountString
        {
            get
            {
                return XmlParser.FromDecimal(TotalExecutableAmount);
            }
            set
            {
                TotalExecutableAmount = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// Total gastos reembolsables. En la 3.0 no está
        /// </summary>
        [XmlIgnore]
        public decimal TotalReimbursableExpenses { get; set; }

        /// <summary>
        /// Total gastos reembolsables. En la 3.0 no está
        /// </summary>
        [XmlElement(ElementName = "TotalReimbursableExpenses", Form = XmlSchemaForm.Unqualified)]
        public virtual string TotalReimbursableExpensesString
        {
            get
            {

                if (TotalReimbursableExpenses == 0)
                    return null;

                return XmlParser.FromDecimal(TotalReimbursableExpenses);
            }
            set
            {   
                TotalReimbursableExpenses = XmlParser.ToDecimal(value); 
            }
        }

    }
}
