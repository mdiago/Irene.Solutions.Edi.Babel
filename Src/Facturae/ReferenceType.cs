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
    /// Referencia de la firma.
    /// </summary>
    [Serializable()]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class ReferenceType
    {

        #region Public Properties

        /// <summary>
        /// Transformaciones aplicadas al archivo xml.
        /// </summary>
        [XmlArrayItem("Transform", IsNullable = false)]
        public TransformType[] Transforms { get; set; }

        /// <summary>
        /// Método hash utilizado.
        /// </summary>
        public DigestMethodType DigestMethod { get; set; }

        /// <summary>
        /// Valor del hash.
        /// </summary>
        [XmlElement(DataType = "base64Binary")]
        public byte[] DigestValue { get; set; }

        /// <summary>
        /// Identificador.
        /// </summary>
        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// URI
        /// </summary>
        [XmlAttribute(DataType = "anyURI")]
        public string URI { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [XmlAttribute(DataType = "anyURI")]
        public string Type { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Representación textual de la instancia de ReferenceType.
        /// </summary>
        /// <returns>Representación textual de la instancia de ReferenceType.</returns>
        public override string ToString()
        {
            return $"{DigestMethod}";
        }

        #endregion


    }
}
