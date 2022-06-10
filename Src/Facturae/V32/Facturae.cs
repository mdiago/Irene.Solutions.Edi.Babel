using System;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Irene.Solutions.Edi.Babel.Facturae.V32
{

    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.facturae.es/Facturae/2009/v3.2/Facturae")]
    [XmlRoot(Namespace = "http://www.facturae.es/Facturae/2009/v3.2/Facturae", IsNullable = false)]
    public class Facturae : Edi.Babel.Facturae.Facturae
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public FileHeaderType FileHeader { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public PartiesType Parties { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Invoice", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public InvoiceType[] Invoices { get; set; }

        /// <summary>
        /// Devuelve el espacio de nombres de la versión.
        /// </summary>
        /// <returns>Espacio de nombres de la versión.</returns>
        public override string GetVersionNamespace()
        {
            return "http://www.facturae.es/Facturae/2009/v3.2/Facturae";
        }


    }
}
