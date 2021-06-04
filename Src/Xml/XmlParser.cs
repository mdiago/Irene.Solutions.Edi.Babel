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

using Irene.Solutions.Edi.Babel.Facturae;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace Irene.Solutions.Edi.Babel.Xml
{
    /// <summary>
    /// Responsable serialización xml.
    /// </summary>
    public class XmlParser
    {

        #region Private Member Variables

        /// <summary>
        /// Tipos según espacio de nombres.
        /// </summary>
        static Dictionary<string, Type> _TypesByNs = new Dictionary<string, Type>() {
            { "http://www.facturae.es/Facturae/2007/v3.0/Facturae",                 typeof(Facturae.V30.Facturae) },
            { "http://www.facturae.es/Facturae/2007/v3.1/Facturae",                 typeof(Facturae.V31.Facturae)},
            { "http://www.facturae.es/Facturae/2009/v3.2/Facturae",                 typeof(Facturae.V32.Facturae) },
            { "http://www.facturae.gob.es/formato/Versiones/Facturaev3_2_2.xml",    typeof(Facturae.V322.Facturae)}
        };

        #endregion

        #region Private Methods

        /// <summary>
        /// Devuelve la clase que se corresponde con la implementación
        /// del tipo de archivo xml cuyo texto se pasa como argumento.
        /// Se busca el espacio de nombres asociado a cada tipo implementado
        /// en la biblioteca y se se encuentra se devuelve su tipo asociado en 
        /// el diccionario estático _TypesByNs.
        /// </summary>
        /// <param name="xmlText">Texto de un archivo xml.</param>
        /// <returns>Tipo que implementa el formato del archivo xml
        /// o nulo si no lo encuentra.</returns>
        private static Type GetTypeFromXmlText(string xmlText)
        {

            foreach (KeyValuePair<string, Type> typesByNs in _TypesByNs)
                if (xmlText.Contains(typesByNs.Key))
                    return typesByNs.Value;

            return null;
            
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Serializa el objeto como xml y lo guarda
        /// en la ruta indicada.
        /// </summary>
        /// <param name="instance">Instancia de objeto a serializar.</param>
        /// <param name="path">Ruta al archivo xml a crear.</param>
        public static void SaveAsXml(object instance, string path, Dictionary<string, string> Ns = null)
        {
            XmlSerializer serializer = new XmlSerializer(instance.GetType());

            if (Ns == null)
            {

                var xmlnsEmpty = new XmlSerializerNamespaces();
                xmlnsEmpty.Add("", "");

                using (StreamWriter w = new StreamWriter(path))
                {
                    serializer.Serialize(w, instance, xmlnsEmpty);
                }
            }
            else
            {

                var xmlNs = new XmlSerializerNamespaces();
                
                foreach (KeyValuePair<string, string> n in Ns)
                    xmlNs.Add(n.Key, n.Value);

                using (StreamWriter w = new StreamWriter(path))
                {
                    serializer.Serialize(w, instance, xmlNs);
                }
            }
        }

        /// <summary>
        /// Obtiene una instancia de objeto a partir de un
        /// archivo xml.
        /// </summary>
        /// <param name="path">Ruta al archivo.</param>
        /// <returns>Instancia de tipo T.</returns>
        public static T FromXml<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            if (File.Exists(path))
            {
                using (StreamReader r = new StreamReader(path))
                {
                    return (T)serializer.Deserialize(r);
                }
            }
            else
            {
                throw new FileNotFoundException($"No se encontró el archivo: {path}");
            }
        }

        /// <summary>
        /// Obtiene una instancia de objeto a partir de un
        /// archivo xml.
        /// </summary>
        /// <param name="path">Ruta al archivo.</param>
        /// <returns>Instancia de tipo T.</returns>
        public static dynamic FromXml(string path)
        {

            string xmlText = File.ReadAllText(path);

            Type type = GetTypeFromXmlText(xmlText); 
            
            if(type == null)
                throw new FileNotFoundException($"No se encontró implementación para el archivo: {path}");

            XmlSerializer serializer = new XmlSerializer(type);

            if (File.Exists(path))
                using (StreamReader r = new StreamReader(path))
                    return serializer.Deserialize(r);
            else
                throw new FileNotFoundException($"No se encontró el archivo: {path}");
        }

        /// <summary>
        /// Serializa el objeto como xml y lo devuelve
        /// como archivo xml en una cadena.
        /// </summary>
        /// <param name="instance">Instancia de objeto a serializar.</param>
        /// <param name="namespaces">Espacios de nombres.</param> 
        /// <param name="indent">Indica si se debe utilizar indentación.</param>
        /// <returns>string con el archivo xml.</returns>
        public static string GetString(object instance, Dictionary<string, string> namespaces, bool indent = false)
        {
            XmlSerializer serializer = new XmlSerializer(instance.GetType());

            var xmlSerializerNamespaces = new XmlSerializerNamespaces();
            foreach (KeyValuePair<string, string> ns in namespaces)
                xmlSerializerNamespaces.Add(ns.Key, ns.Value);
           

            var ms = new MemoryStream();
            string result = null;

            using (var writer = new StreamWriter(ms))
            {
                using (var xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings { Indent = indent, IndentChars = "", Encoding = Encoding.UTF8 }))
                {
                    if(namespaces.Count > 0)
                        serializer.Serialize(xmlWriter, instance, xmlSerializerNamespaces);
                    else
                        serializer.Serialize(xmlWriter, instance);

                    result = Encoding.UTF8.GetString(ms.ToArray());
                }
            }

            return result;
           
        }

        /// <summary>
        /// Devuelve un importe formateado para un campo decimal
        /// de la especificación de facturae.
        /// </summary>
        /// <param name="amount">Impote a formatear</param>
        /// <returns>Importe formateado.</returns>
        public static string FromDecimal(decimal amount)
        {
            return amount.ToString("N", Context.DefaultNumberFormatInfo);
        }

        /// <summary>
        /// Convierte en decimal un importe representado por un texto en 
        /// un tag de un xml del facturae.
        /// </summary>
        /// <param name="amount">Texto de importe a convertir.</param>
        /// <returns>Importe decimal representado.</returns>
        public static decimal ToDecimal(string amount)
        {
            return Convert.ToDecimal(amount, Context.DefaultNumberFormatInfo);
        }

        #endregion

    }
}
