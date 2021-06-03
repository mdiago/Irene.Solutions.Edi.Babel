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
    /// Elemento xml ReferenceSignedProperties.
    /// </summary>
    public class ReferenceSignedProperties : Element
    {

        Element _DigestValue;

        /// <summary>
        /// Hash del elemento.
        /// </summary>
        public string DigestValue
        {
            get
            {
                return _DigestValue.Content;
            }
            set
            {
                _DigestValue.Content = value;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="SignedPropertiesID">Id. del elemento.</param>
        /// <param name="IdSignature">Id. de la firma.</param>
        /// <param name="IdSignedProperties">Id. para firma</param>
        /// <param name="IdObjRef">Id. Object ref.</param>
        public ReferenceSignedProperties(string SignedPropertiesID, string IdSignature, 
            string IdSignedProperties, string IdObjRef)
            : base("ds:Reference")
        {
            AddAttribute("Id", "SignedPropertiesID" + SignedPropertiesID);
            AddAttribute("Type", "http://uri.etsi.org/01903#SignedProperties");
            AddAttribute("URI", "#Signature" + IdSignature + "-SignedProperties" + IdSignedProperties);
            AddElement(new DigestMethod());
            _DigestValue = AddElement(new Element("ds:DigestValue", ""));
        }
    }
}
