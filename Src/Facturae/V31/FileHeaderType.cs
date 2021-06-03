using System;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace Irene.Solutions.Edi.Babel.Facturae.V31
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.es/Facturae/2007/v3.1/Facturae")]
    public class FileHeaderType 
    {

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public FileHeaderType()
        {
            SchemaVersion = SchemaVersionType.Ver31;
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
