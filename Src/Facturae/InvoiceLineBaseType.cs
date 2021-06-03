using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Irene.Solutions.Edi.Babel.Xml;
using System.Globalization;

namespace Irene.Solutions.Edi.Babel.Facturae
{

    /// <summary>
    /// Representa una línea de factura.
    /// </summary>
    [Serializable()]
    public class InvoiceLineBaseType
    {

        /// <summary>
        /// Referencia contrato.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string IssuerContractReference { get; set; }

        /// <summary>
        /// Fecha de contrato.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime IssuerContractDate { get; set; }

        /// <summary>
        /// Indica si se ha especificado IssuerContractDate.
        /// </summary>
        [XmlIgnore()]
        public bool IssuerContractDateSpecified { get; set; }

        /// <summary>
        /// Referencia de la transacción para el emisor.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string IssuerTransactionReference { get; set; }

        /// <summary>
        /// Fecha de la transacción para el emisor.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime IssuerTransactionDate { get; set; }

        /// <summary>
        /// Indica si se ha especificado IssuerTransactionDate. 
        /// </summary>
        [XmlIgnore()]
        public bool IssuerTransactionDateSpecified { get; set; }

        /// <summary>
        /// Referencia de contrato para el receptor.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ReceiverContractReference { get; set; }

        /// <summary>
        /// Fecha contrato receptor.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime ReceiverContractDate { get; set; }

        /// <summary>
        /// Indica si se ha especificado ReceiverContractDate.
        /// </summary>
        [XmlIgnore()]
        public bool ReceiverContractDateSpecified { get; set; }

        /// <summary>
        /// ReceiverTransactionReference
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ReceiverTransactionReference { get; set; }

        /// <summary>
        /// ReceiverTransactionDate
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime ReceiverTransactionDate { get; set; }

        /// <summary>
        /// Si se ha especificado ReceiverTransactionDate.
        /// </summary>
        [XmlIgnore()]
        public bool ReceiverTransactionDateSpecified { get; set; }

        /// <summary>
        /// FileReference
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string FileReference { get; set; }

        /// <summary>
        /// Fecha archivo.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime FileDate { get; set; }

        /// <summary>
        /// Fecha de archivo espedificada.
        /// </summary>
        [XmlIgnore()]
        public bool FileDateSpecified { get; set; }

        /// <summary>
        /// SequenceNumber
        /// </summary>
        [XmlIgnore()]
        public decimal SequenceNumber { get; set; }

        /// <summary>
        /// Representación con dos decimales del precio unitario
        /// sin impuestos.
        /// </summary>
        [XmlElement(ElementName = "SequenceNumber", Form = XmlSchemaForm.Unqualified)]
        public string SequenceNumberString
        {
            get
            {

                NumberFormatInfo sequenceFormatInfo = new NumberFormatInfo()
                {
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = "",
                    NumberDecimalDigits = 1
                };

                return SequenceNumber.ToString("N", sequenceFormatInfo);
            }
            set
            {
                SequenceNumber = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// SequenceNumberSpecified
        /// </summary>
        [XmlIgnore()]
        public bool SequenceNumberSpecified { get; set; }

        /// <summary>
        /// DeliveryNotesReferences
        /// </summary>
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("DeliveryNote", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public DeliveryNoteType[] DeliveryNotesReferences { get; set; }

        /// <summary>
        /// ItemDescription
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ItemDescription { get; set; }

        /// <summary>
        /// Cantidad
        /// </summary>
        [XmlIgnore()]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Representación con dos decimales del precio unitario
        /// sin impuestos.
        /// </summary>
        [XmlElement(ElementName = "Quantity", Form = XmlSchemaForm.Unqualified)]
        public string QuantityString
        {
            get
            {

                NumberFormatInfo quantityFormatInfo = new NumberFormatInfo()
                {
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = "",
                    NumberDecimalDigits = 1
                };

                return Quantity.ToString("N", quantityFormatInfo);
            }
            set
            {
                Quantity = XmlParser.ToDecimal(value);
            }
        }


        /// <summary>
        /// Unidad de medida
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public UnitOfMeasureType UnitOfMeasure { get; set; }

        /// <summary>
        /// Indica si se ha especificado UnitOfMeasure.
        /// </summary>
        [XmlIgnore()]
        public bool UnitOfMeasureSpecified { get; set; }

        /// <summary>
        /// Precio unitario sin impuestos.
        /// </summary>
        [XmlIgnore()]
        public decimal UnitPriceWithoutTax { get; set; }

        /// <summary>
        /// Representación con dos decimales del precio unitario
        /// sin impuestos.
        /// </summary>
        [XmlElement(ElementName = "UnitPriceWithoutTax", Form = XmlSchemaForm.Unqualified)]
        public string UnitPriceWithoutTaxString
        {
            get
            {

                NumberFormatInfo priceFormatInfo = new NumberFormatInfo() 
                { 
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = "",
                    NumberDecimalDigits = 6
                };

                return UnitPriceWithoutTax.ToString("N", priceFormatInfo);
            }
            set
            {
                UnitPriceWithoutTax = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// Coste total
        /// </summary>
        [XmlIgnore()]
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Representación con dos decimales del Coste total
        /// sin impuestos.
        /// </summary>
        [XmlElement(ElementName = "TotalCost", Form = XmlSchemaForm.Unqualified)]
        public string TotalCostString
        {
            get
            {
                NumberFormatInfo costFormatInfo = new NumberFormatInfo()
                {
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = "",
                    NumberDecimalDigits = 6
                };

                return TotalCost.ToString("N", costFormatInfo);
            }
            set
            {
                TotalCost = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// Descuentos reducciones
        /// </summary>
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Discount", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public DiscountType[] DiscountsAndRebates { get; set; }

        /// <summary>
        /// Cargos
        /// </summary>
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Charge", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public ChargeType[] Charges { get; set; }

        /// <summary>
        /// Importe bruto
        /// </summary>
        [XmlIgnore()]
        public decimal GrossAmount { get; set; }


        /// <summary>
        /// Representación con dos decimales del bruto
        /// sin impuestos.
        /// </summary>
        [XmlElement(ElementName = "GrossAmount", Form = XmlSchemaForm.Unqualified)]
        public string GrossAmountString
        {
            get
            {
                NumberFormatInfo amountFormatInfo = new NumberFormatInfo()
                {
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = "",
                    NumberDecimalDigits = 6
                };

                return GrossAmount.ToString("N", amountFormatInfo);
            }
            set
            {
                GrossAmount = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// Impuestos soportados
        /// </summary>
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Tax", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public TaxType[] TaxesOutputs { get; set; }

        /// <summary>
        /// Impuestos retenidos.
        /// </summary>
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Tax", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public TaxType[] TaxesWithheld { get; set; } 

        /// <summary>
        /// Periodo
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public PeriodDates LineItemPeriod { get; set; }

        /// <summary>
        /// Fecha transacción
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Indica si se facilitado TransactionDate
        /// </summary>
        [XmlIgnore()]
        public bool TransactionDateSpecified { get; set; }

        /// <summary>
        /// Información adicional de lá línea.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string AdditionalLineItemInformation { get; set; }

        /// <summary>
        /// Código de artículo.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ArticleCode { get; set; }

        /// <summary>
        /// Extensiones.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ExtensionsType Extensions { get; set; }

    }
}
