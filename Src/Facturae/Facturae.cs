using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Collections.Generic;
using Irene.Solutions.Edi.Babel.Xml;
using System.Text.RegularExpressions;
using Irene.Solutions.Edi.Babel.Facturae.Signature.Xades;
using System.Security.Cryptography.X509Certificates;

namespace Irene.Solutions.Edi.Babel.Facturae
{

    /// <summary>
    /// Representa una factura den formato facturae.
    /// </summary>
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.facturae.es/Facturae/2007/v3.0/Facturae")]
    [XmlRoot(Namespace = "http://www.facturae.es/Facturae/2007/v3.0/Facturae", IsNullable = false)]
    public class Facturae
    {

        /// <summary>
        /// Extensiones.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ExtensionsType Extensions { get; set; }

        /// <summary>
        /// Firma
        /// </summary>
        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature { get; set; }

        /// <summary>
        /// Devuelve la cadena del bloque facturae de
        /// la instancia de facturae sin identación y sin
        /// saltos de línea, preparada para el hash.
        /// </summary>
        /// <returns>La cadena del bloque facturae de
        /// la instancia de facturae sin identación y sin
        /// saltos de línea, preparada para el hash.</returns>
        public string GetString()
        {

            Dictionary<string, string> namespaces = new Dictionary<string, string>()
            {
                { "ds", "http://www.w3.org/2000/09/xmldsig#"},
                { "fe", "http://www.facturae.es/Facturae/2009/v3.2/Facturae"},
            };

            var xml = XmlParser.GetString(this, namespaces, false);

            return xml;

        }

        /// <summary>
        /// Devuelve el texto de un archivo xml facturae firmado.
        /// </summary>
        /// <param name="certificate">Certificado para la firma</param>
        /// <param name="idSignature">Id. de la firma</param>
        /// <param name="idObjRef">Id. para el bloque ObjectRef.</param>
        /// <param name="idSignedProperties">Id. para el bloque SignedProperties</param>
        /// <param name="idCertificate">Id. para el certificado.</param>
        /// <param name="idSignedInfo">idSignedInfo</param>
        /// <param name="signedPropertiesID">signedPropertiesID</param>
        /// <param name="idSignatureValue">idSignatureValue</param>
        /// <param name="idSignatureObject">idSignatureObject</param>
        /// <returns></returns>
        public string GetSigned(X509Certificate2 certificate, 
            string idSignature = "", string idObjRef = "", 
            string idSignedProperties = "", string idCertificate = "", 
            string idSignedInfo = "", string signedPropertiesID = "", 
            string idSignatureValue = "", string idSignatureObject = "")
        {

            var xmlFacturae = GetString();

            Signer signer = new Signer(xmlFacturae, idSignature, 
                idObjRef, idSignedProperties, certificate, idCertificate);

            signer.GetSignedInfo(idSignedInfo, signedPropertiesID, idSignatureValue, idSignatureObject);

            return signer.Signed;
        }

    }
}
