using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Irene.Solutions.Edi.Babel.Facturae.V322
{

    [Serializable()]
    [XmlType(Namespace = "http://www.facturae.gob.es/formato/Versiones/Facturaev3_2_2.xml")]
    public class FactoringAssignmentDocumentType
    {

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DocumentCharacter { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RepresentationIdentity { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DocumentType { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RepositoryType Repository { get; set; }

    }
}
