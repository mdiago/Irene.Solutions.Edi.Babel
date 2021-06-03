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

namespace Irene.Solutions.Edi.Babel.Facturae.Signature.Xades
{

    /// <summary>
    /// Elemento xml SignedInfo.
    /// </summary>
    public class SignedInfo : Element
    {

        /// <summary>
        /// Elemento xml ReferenceSignedProperties.
        /// </summary>
        public ReferenceSignedProperties ReferenceSignedProperties { get; set; }

        /// <summary>
        /// Elemento xml ReferenceCertificate.
        /// </summary>
        public ReferenceCertificate ReferenceCertificate { get; set; }

        /// <summary>
        /// Elemento xml ReferenceContent.
        /// </summary>
        public ReferenceContent ReferenceContent { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="idSignedInfo">IdSignedInfo</param>
        /// <param name="signedPropertiesID">SignedPropertiesID</param>
        /// <param name="idSignature">IdSignature</param>
        /// <param name="idSignedProperties">IdSignedProperties</param>
        /// <param name="idObjRef">IdObjRef</param>
        /// <param name="idCertificate">IdCertificate</param>
        public SignedInfo(string idSignedInfo, string signedPropertiesID, string idSignature, 
            string idSignedProperties, string idObjRef, string idCertificate)
            : base("ds:SignedInfo")
        {
            AddAttribute("Id", "Signature-SignedInfo" + idSignedInfo);
            Element CanonicalizationMethod = new Element("ds:CanonicalizationMethod");
            CanonicalizationMethod.AddAttribute("Algorithm", Signer.DefaultCanonicalizationMethod);
            Element SignatureMethod = new Element("ds:SignatureMethod");
            SignatureMethod.AddAttribute("Algorithm", Signer.DefaultSignatureMethod);
            AddElement(CanonicalizationMethod);
            AddElement(SignatureMethod);
            ReferenceSignedProperties = (ReferenceSignedProperties)AddElement(new ReferenceSignedProperties(signedPropertiesID, idSignature, idSignedProperties, idObjRef));
            ReferenceCertificate = (ReferenceCertificate)AddElement(new ReferenceCertificate(idCertificate));
            ReferenceContent = (ReferenceContent)AddElement(new ReferenceContent(idObjRef));
        }
    }
}
