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

namespace Irene.Solutions.Edi.Babel.Facturae.Signature.Xml
{

    /// <summary>
    /// Representa un tag de apertura de elemento xml.
    /// </summary>
    class Stag
    {

        /// <summary>
        /// Nombre del elemento xml.
        /// </summary>
        string _Name;

        /// <summary>
        /// Representación del tag de apertura
        /// de un elemento xml.
        /// </summary>
        public string Xml
        {
            get
            {
                return (Attributes.Count == 0) ? $"<{_Name}>" :
                        $"<{_Name} { Attributes.AttributesString}>"; ;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Nombre del elemento xml.</param>
        public Stag(string name)
        {
            _Name = name.Trim();
        }

        /// <summary>
        /// Lista de atributos del elemento.
        /// </summary>
        public AttributeList Attributes = new AttributeList();

        /// <summary>
        /// Añade un atributo al elemento.
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns>Atributo añadido.</returns>
        public Attribute AddAttribute(Attribute attribute)
        {
            return Attributes.Insert(attribute);
        }

        /// <summary>
        /// Crea y añada un atributo al elemento.
        /// </summary>
        /// <param name="name">Nombre del atributo a crear.</param>
        /// <param name="value">Valor del atributo.</param>
        /// <returns>Atributo creado.</returns>
        public Attribute AddAttribute(string name, string value)
        {
            return Attributes.Insert(name, value);
        }

        /// <summary>
        /// Añade un atributo en la posición indicada.
        /// </summary>
        /// <param name="attribute">Atributo a añadir</param>
        /// <param name="index">Posición en la que añadir el elemento.</param>
        public void AddAttributeAt(Attribute attribute, int index)
        {
            Attributes.InsertAt(attribute, index);
        }

        /// <summary>
        /// Borra un atributo de la lista de atributos.
        /// </summary>
        /// <param name="name">Nombre del atributo a aliminar</param>
        public void DelAttribute(string name)
        {
            Attributes.Delete(name);
        }
    }
}
