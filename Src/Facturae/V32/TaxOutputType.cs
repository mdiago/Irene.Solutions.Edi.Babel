using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Irene.Solutions.Edi.Babel.Xml;

namespace Irene.Solutions.Edi.Babel.Facturae.V32
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2009/v3.2/Facturae")]
    public class TaxOutputType
    {

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public TaxTypeCodeType TaxTypeCode { get; set; }

        [XmlIgnore]
        public decimal TaxRate { get; set; }

        [XmlElement(ElementName= "TaxRate", Form = XmlSchemaForm.Unqualified)]
        public string TaxRateString
        {
            get
            {
                return XmlParser.FromDecimal(TaxRate);
            }
            set
            {
                TaxRate = XmlParser.ToDecimal(value);
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AmountType TaxableBase { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AmountType TaxAmount { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AmountType SpecialTaxableBase { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AmountType SpecialTaxAmount { get; set; }
    

        [XmlElement(ElementName= "EquivalenceSurcharge", Form = XmlSchemaForm.Unqualified)]
        public decimal EquivalenceSurcharge { get; set; }

        [XmlIgnore()]
        public bool EquivalenceSurchargeSpecified { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AmountType EquivalenceSurchargeAmount { get; set; }

    }
}
