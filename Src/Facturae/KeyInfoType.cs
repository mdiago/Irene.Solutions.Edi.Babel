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

using System;
using System.Xml.Serialization;

namespace Irene.Solutions.Edi.Babel.Facturae
{

    /// <summary>
    /// KeyInfo is an optional element that enables the recipient(s) 
    /// to obtain the key needed to validate the signature.
    /// </summary>
    [Serializable()]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class KeyInfoType
    {

        #region Public Properties

        /// <summary>
        /// The KeyName element contains a string value (in which white
        /// space is significant) which may be used by the signer to 
        /// communicate a key identifier to the recipient. Typically, 
        /// KeyName contains an identifier related to the key pair used 
        /// to sign the message, but it may contain other protocol-related 
        /// information that indirectly identifies a key pair. (Common uses 
        /// of KeyName include simple string names for keys, a key index, 
        /// a distinguished name (DN), an email address, etc.)
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        ///The KeyValue element contains a single public key that may be useful 
        ///in validating the signature. Structured formats for defining DSA 
        ///(required), RSA (required) and ECDSA (required) public keys are defined 
        ///in section 6.4 Signature Algorithms. The KeyValue element may include 
        ///externally defined public keys values represented as PCDATA or element 
        ///types from an external namespace.
        /// </summary>
        public KeyValueType KeyValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MgmtData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PGPDataType PGPData { get; set; }

        /// <summary>
        /// A RetrievalMethod element within KeyInfo is used to convey a reference 
        /// to KeyInfo information that is stored at another location. For example, 
        /// several signatures in a document might use a key verified by an X.509v3 
        /// certificate chain appearing once in the document or remotely outside the 
        /// document; each signature's KeyInfo can reference this chain using a single 
        /// RetrievalMethod element instead of including the entire chain with a 
        /// sequence of X509Certificate elements.
        /// </summary>
        public RetrievalMethodType RetrievalMethod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SPKIDataType SPKIData { get; set; }

        /// <summary>
        /// A RetrievalMethod element within KeyInfo is used to convey a reference to KeyInfo 
        /// information that is stored at another location. For example, several signatures in 
        /// a document might use a key verified by an X.509v3 certificate chain appearing once 
        /// in the document or remotely outside the document; each signature's KeyInfo can 
        /// reference this chain using a single RetrievalMethod element instead of including 
        /// the entire chain with a sequence of X509Certificate elements.
        /// </summary>
        public X509DataType X509Data { get; set; }

        /// <summary>
        /// Identificador.
        /// </summary>
        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Representación textual de la instancia de KeyInfoType.
        /// </summary>
        /// <returns>Representación textual de la instancia de KeyInfoType.</returns>
        public override string ToString()
        {
            return $"{KeyName}";
        }

        #endregion


    }
}
