/*
    This file is part of the Irene.Solutions.Edi.Babel (R) project.
    Copyright (c) 2019-2020 Irene Solutions SL
    Authors: Irene Solutions SL.

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License version 3
    as published by the Free Software Foundation with the addition of the
    following permission added to Section 15 as permitted in Section 7(a):
    FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
    IRENE SOLUTIONS SL. IRENE SOLUTIONS SL DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
    OF THIRD PARTY RIGHTS
    
    This program is distributed in the hope that it will be useful, but
    WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
    or FITNESS FOR A PARTICULAR PURPOSE.
    See the GNU Affero General Public License for more details.
    You should have received a copy of the GNU Affero General Public License
    along with this program; if not, see http://www.gnu.org/licenses or write to
    the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
    Boston, MA, 02110-1301 USA, or download the license from the following URL:
        http://www.irenesolutions.com/terms-of-use.pdf
    
    The interactive user interfaces in modified source and object code versions
    of this program must display Appropriate Legal Notices, as required under
    Section 5 of the GNU Affero General Public License.
    
    You can be released from the requirements of the license by purchasing
    a commercial license. Buying such a license is mandatory as soon as you
    develop commercial activities involving the Kivu software without
    disclosing the source code of your own applications.
    These activities include: offering paid services to customers as an ASP,
    serving Irene.Solutions.Edi.Babel services on the fly in a web application, 
    shipping Irene.Solutions.Edi.Babel with a closed source product.
    
    For more information, please contact Irene Solutions SL. at this
    address: info@irenesolutions.com
 */

using Irene.Solutions.Edi.Babel.Facturae.Signature.Xml;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Irene.Solutions.Edi.Babel.Facturae.Signature.Xades
{

    /// <summary>
    /// Se encarga de firmar documentos facturae.
    /// </summary>
    public class Signer
    {

        string _XmlCanSignedProperties;
        string _XmlCanSignedInfo;
        string _XmlContent;
        string _XmlKeyInfo;
        string _XmlSignedProperties;
        string _XmlSignedInfo;
        string _XmlCanKeyInfo;
        X509Certificate2 _Certificate { get; set; }
        Element _Signature { get; set; }
        Facturae _Facturae { get; set; }



        /// <summary>
        /// Función hash por defecto.
        /// </summary>
        internal static string DefaultDigestMethod = "http://www.w3.org/2000/09/xmldsig#sha1";

        /// <summary>
        /// Función transformación por defecto.
        /// </summary>
        internal static string DefaultReferenceContentTransform = "http://www.w3.org/2000/09/xmldsig#enveloped-signature";

        /// <summary>
        /// Id. Política de firma por defecto.
        /// </summary>
        internal static string DefaultSignaturePolicyIdentifier = "http://www.facturae.es/politica_de_firma_formato_facturae/politica_de_firma_formato_facturae_v3_1.pdf";

        /// <summary>
        /// Descripción política de firma por defecto.
        /// </summary>
        internal static string DefaultSignaturePolicyDescription = "Política de Firma FacturaE v3.1";

        /// <summary>
        /// Hash política de firma por defecto.
        /// </summary>
        internal static string DefaultSignaturePolicyHash = "Ohixl6upD6av8N7pEvDABhEL6hM=";

        /// <summary>
        /// Algoritmo de Canonicalización xml utilizado.
        /// </summary>
        internal static string DefaultCanonicalizationMethod = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315";

        /// <summary>
        /// Método de firma por defecto.
        /// </summary>
        internal static string DefaultSignatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";

        /// <summary>
        /// HashContent
        /// </summary>
        public string HashContent { get; set; }

        /// <summary>
        /// HashKeyInfo
        /// </summary>
        public string HashKeyInfo { get; set; }

        /// <summary>
        /// HashSignedProperties
        /// </summary>
        public string HashSignedProperties { get; set; }

        /// <summary>
        /// IdSignature
        /// </summary>
        public string IdSignature { get; set; }

        /// <summary>
        /// IdObjRef
        /// </summary>
        public string IdObjRef { get; set; }

        /// <summary>
        /// IdSignedProperties
        /// </summary>
        public string IdSignedProperties { get; set; }

        /// <summary>
        /// IdCertificate
        /// </summary>
        public string IdCertificate { get; set; }

        /// <summary>
        /// FraeSigned
        /// </summary>
        public string Signed;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="idSignature"></param>
        /// <param name="idObjRef"></param>
        /// <param name="idSignedProperties"></param>
        /// <param name="certificate"></param>
        /// <param name="idCertificate"></param>
        /// <param name="nsVersion">Versión facturae. Por defecto 3.2</param>
        public Signer(string xml, string idSignature, string idObjRef, 
            string idSignedProperties, X509Certificate2 certificate, string idCertificate,
            string nsVersion = "http://www.facturae.es/Facturae/2009/v3.2/Facturae")
        {

            IdSignature = idSignature;
            IdObjRef = idObjRef;
            IdSignedProperties = idSignedProperties;
            IdCertificate = idCertificate;
            _Certificate = certificate;
            _Facturae = new Facturae(nsVersion);

            // Únicamente el cuerpo

            _XmlContent = xml;

            _XmlContent = Regex.Match(xml, @"<fe:Facturae[^>]+>[\s\S]+").Value;
            _XmlContent = Regex.Match(xml, @"^[\s\S]+</fe:Facturae>").Value;

            // Canonicalizo el cuerpo
            XmlDocument myDoc = new XmlDocument();
            myDoc.LoadXml(_XmlContent);

            XmlDsigC14NTransform xmlTransform = new XmlDsigC14NTransform();
            xmlTransform.LoadInput(myDoc);
            MemoryStream ms = (MemoryStream)xmlTransform.GetOutput(typeof(MemoryStream));

            var bufferXml = ms.ToArray();

            _XmlContent = Encoding.UTF8.GetString(bufferXml);
            
            HashContent = GetStringUTF8HashToBase64(_XmlContent);

            KeyInfo fKeyInfo = new KeyInfo(_Certificate, IdCertificate);
            Object fObject = new Object(IdSignature, IdObjRef, IdSignedProperties, _Certificate);


            fKeyInfo.AddAttributeAt("xmlns:fe", _Facturae.GetVersionNamespace(), 0);
            fKeyInfo.AddAttributeAt("xmlns:etsi", "http://uri.etsi.org/01903/v1.3.2#", 0);
            fKeyInfo.AddAttributeAt("xmlns:ds", "http://www.w3.org/2000/09/xmldsig#", 0);

            fObject.SignedProperties.AddAttributeAt("xmlns:fe", _Facturae.GetVersionNamespace(), 0);
            fObject.SignedProperties.AddAttributeAt("xmlns:etsi", "http://uri.etsi.org/01903/v1.3.2#", 0);
            fObject.SignedProperties.AddAttributeAt("xmlns:ds", "http://www.w3.org/2000/09/xmldsig#", 0);


            _Signature = new Element("ds:Signature");
            _Signature.AddAttribute("xmlns:etsi", "http://uri.etsi.org/01903/v1.3.2#");
            _Signature.AddAttribute("Id", "Signature" + IdSignature);

            _Signature.AddElement(fKeyInfo);
            _Signature.AddElement(fObject);

            _Facturae.AddElement(_Signature);

            HashKeyInfo = ComputeHashOfTag(_Facturae, "ds:KeyInfo", out _XmlCanKeyInfo);

            HashSignedProperties = ComputeHashOfTag(_Facturae, "etsi:SignedProperties",
                out _XmlCanSignedProperties, false);

            /*Una vez obtenido el hash quito los atributos redundantes utilizados en la canonicalización*/

            fKeyInfo.DelAttribute("xmlns:ds");
            fKeyInfo.DelAttribute("xmlns:etsi");
            fKeyInfo.DelAttribute("xmlns:fe");

            fObject.SignedProperties.DelAttribute("xmlns:ds");
            fObject.SignedProperties.DelAttribute("xmlns:etsi");
            fObject.SignedProperties.DelAttribute("xmlns:fe");

            _XmlKeyInfo = GetUTF8StringOfTag(_Facturae, "ds:KeyInfo");
            _XmlSignedProperties = GetUTF8StringOfTag(_Facturae, "etsi:SignedProperties", false);

        }

        /// <summary>
        /// Calcula el elemento SignedInfo.
        /// </summary>
        /// <param name="idSignedInfo">idSignedInfo</param>
        /// <param name="signedPropertiesID">signedPropertiesID</param>
        /// <param name="idSignatureValue">idSignatureValue</param>
        /// <param name="idSignatureObject">idSignatureObject</param>
        public void GetSignedInfo(string idSignedInfo, string signedPropertiesID, string idSignatureValue, string idSignatureObject = "")
        {

            SignedInfo SignedInfo = new SignedInfo(idSignedInfo, signedPropertiesID, 
                IdSignature, IdSignedProperties, IdObjRef, IdCertificate);

            SignedInfo.ReferenceSignedProperties.DigestValue = HashSignedProperties;
            SignedInfo.ReferenceCertificate.DigestValue = HashKeyInfo;
            SignedInfo.ReferenceContent.DigestValue = HashContent;
            _Signature.AddElementFirst(SignedInfo);

            SignedInfo.AddAttributeAt("xmlns:fe", _Facturae.GetVersionNamespace(), 0);
            SignedInfo.AddAttributeAt("xmlns:etsi", "http://uri.etsi.org/01903/v1.3.2#", 0);
            SignedInfo.AddAttributeAt("xmlns:ds", "http://www.w3.org/2000/09/xmldsig#", 0);

            _XmlCanSignedInfo = GetUTF8StringOfTag(_Facturae, "ds:SignedInfo");

            SignedInfo.DelAttribute("xmlns:ds");
            SignedInfo.DelAttribute("xmlns:etsi");
            SignedInfo.DelAttribute("xmlns:fe");

            _XmlSignedInfo = GetUTF8StringOfTag(_Facturae, "ds:SignedInfo");

            byte[] DataToSign = Encoding.UTF8.GetBytes(_XmlCanSignedInfo);
            RSACryptoServiceProvider pk = (RSACryptoServiceProvider)_Certificate.PrivateKey;
            byte[] Sign = pk.SignData(DataToSign, new SHA1Managed());
            SignatureValue SignatureValue = new SignatureValue(Util.ToBase64(Sign), idSignatureValue);
            _Signature.AddElementAt(SignatureValue, 1);

            Signed = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + _XmlContent;
            Signed = Signed.Insert(Signed.Length - 14, "<ds:Signature xmlns:etsi=\"http://uri.etsi.org/01903/v1.3.2#\" Id=\"Signature" + IdSignature + "\">");
            Signed = Signed.Insert(Signed.Length - 14, _XmlSignedInfo + SignatureValue.InnerCanXML + _XmlKeyInfo);
            Signed = Signed.Insert(Signed.Length - 14, "<ds:Object Id=\"Signature" + IdSignature + "-Object"+ idSignatureObject + "\"><etsi:QualifyingProperties Target=\"#Signature" + IdSignature + "\">");
            Signed = Signed.Insert(Signed.Length - 14, _XmlSignedProperties);
            Signed = Signed.Insert(Signed.Length - 14, "</etsi:QualifyingProperties></ds:Object></ds:Signature>");

        }

        /// <summary>
        /// Guarda el documento xml firmado en la ruta indicada.
        /// </summary>
        /// <param name="path">Ruta de destino</param>
        public void SaveSignedFrae(string path )
        {
            File.WriteAllBytes(path, Encoding.UTF8.GetBytes(Signed));
        }

        /// <summary>
        /// Devuelve el hash de una cadena previamente
        /// codificada en UTF8 como una cadena en base 64.
        /// </summary>
        /// <param name="text">Texto del que obtener el hash.</param>
        /// <returns></returns>
        public string GetStringUTF8HashToBase64(string text)
        {
            return Convert.ToBase64String(GetStringUTF8Hash(text));
        }

        /// <summary>
        /// Devuelve hash de una cadena tras codificarla
        /// en UTF8.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private byte[] GetStringUTF8Hash(string text)
        {
            return new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        /// Devuelve el fragmento de texto del tag
        /// especificado como parámetro.
        /// </summary>
        /// <param name="facturae">Facturae que contiene el tag.</param>
        /// <param name="tag">Nombre del elemento xml a recuperar.</param>
        /// <param name="withNL">Indica si se quiere recuperar el tag
        /// con saltos de línea.</param>
        /// <returns></returns>
        private string GetUTF8StringOfTag(Facturae facturae, string tag, 
            bool withNL = true)
        {
            string strEnc = withNL ? facturae.InnerWithoutIndentXML : facturae.InnerCanXML;         

            int ini = strEnc.IndexOf($"<{tag}");
            int fin = strEnc.IndexOf($"</{tag}>") + ($"</{tag}>").Length;
            return strEnc.Substring(ini, fin - ini);

        }


        private string ComputeHashOfTag(Facturae Facturae, string strXML, out string strHashed, bool WithNL = true)
        {
            strHashed = GetUTF8StringOfTag(Facturae, strXML, WithNL);
            return GetStringUTF8HashToBase64(strHashed);
        }

    }

}
