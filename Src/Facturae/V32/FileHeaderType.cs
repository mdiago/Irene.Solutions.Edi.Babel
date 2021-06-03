using System;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Irene.Solutions.Edi.Babel.Facturae.V32
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2009/v3.2/Facturae")]
    public class FileHeaderType 
    {

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public FileHeaderType()
        {
            SchemaVersion = SchemaVersionType.Ver32;
        }

        #endregion

        #region Public Properties

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public FactoringAssignmentDataType FactoringAssignmentData { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public SchemaVersionType SchemaVersion { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ModalityType Modality { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public InvoiceIssuerTypeType InvoiceIssuerType { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ThirdPartyType ThirdParty { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public BatchType Batch { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Representación textual de la instancia de FileHeaderType.
        /// </summary>
        /// <returns>Representación textual de la instancia de FileHeaderType.</returns>
        public override string ToString()
        {
            return $"{SchemaVersion}, {Modality}, " +
                $"{InvoiceIssuerType}, {ThirdParty}, {Batch}";
        }

        #endregion

    }
}
