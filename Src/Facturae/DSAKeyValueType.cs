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
    /// Valor clave DSA.
    /// </summary>
    [Serializable()]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlRoot("DSAKeyValue", Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public class DSAKeyValueType
    {

        #region Public Properties

        /// <summary>
        /// Prime modulus meeting the [FIPS-186-3] requirements
        /// </summary>
        [XmlElement(DataType = "base64Binary")]
        public byte[] P { get; set; }

        /// <summary>
        /// An integer in the range 2**159 gt Q lt 2**160 which is a prime divisor of P-1
        /// </summary>
        [XmlElement(DataType = "base64Binary")]
        public byte[] Q { get; set; }

        /// <summary>
        /// An integer with certain properties with respect to P and Q
        /// </summary>
        [XmlElement(DataType = "base64Binary")]
        public byte[] G { get; set; }

        /// <summary>
        /// G**X mod P (where X is part of the private key and not made public)
        /// </summary>
        [XmlElement(DataType = "base64Binary")]
        public byte[] Y { get; set; }

        /// <summary>
        /// (P - 1) / Q
        /// </summary>
        [XmlElement(DataType = "base64Binary")]
        public byte[] J { get; set; }

        /// <summary>
        /// DSA prime generation seed
        /// </summary>
        [XmlElement(DataType = "base64Binary")]
        public byte[] Seed { get; set; }

        /// <summary>
        /// DSA prime generation seed
        /// </summary>
        [XmlElement(DataType = "base64Binary")]
        public byte[] PgenCounter { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Representación textual de la instancia de DSAKeyValueType.
        /// </summary>
        /// <returns>Representación textual de la instancia de DSAKeyValueType.</returns>
        public override string ToString()
        {
            return $"{Seed}";
        }

        #endregion


    }
}
