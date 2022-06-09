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
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Irene.Solutions.Edi.Babel.Facturae.Signature.Xades
{
    /// <summary>
    /// Bloque KeyInfo.
    /// </summary>
    public class KeyInfo : Element
    {

        /// <summary>
        /// Datos certificado.
        /// </summary>
        public X509Data X509Data { get; set; }

        /// <summary>
        /// Datos certificado.
        /// </summary>
        public X509Data X509Data2 { get; set; }

        /// <summary>
        /// Datos certificado.
        /// </summary>
        public X509Data X509Data3 { get; set; }


        /// <summary>
        /// Datos clave firma.
        /// </summary>
        public KeyValue KeyValue { get; set; }

        /// <summary>
        /// Datos certificado X509 v2.
        /// </summary>
        public X509Certificate2 Certificate;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="certificate">Certificado.</param>
        /// <param name="IdCertificate">Id. del certificado.</param>
        public KeyInfo(X509Certificate2 certificate, 
            string IdCertificate) : base("ds:KeyInfo")
        {

            AddAttribute("Id", "Certificate" + IdCertificate);
            Certificate = certificate;

            X509Data = (X509Data)AddElement(new X509Data());            
            
            X509Data.X509Certificate = Util.ToBase64(Certificate.GetRawCertData());           

            X509Chain ch = new X509Chain();
            ch.ChainPolicy.RevocationMode = X509RevocationMode.Online;
            ch.Build(certificate);

            if (ch.ChainElements.Count > 1) 
            {

                for (int c = 1; c < ch.ChainElements.Count; c++) 
                {

                    var el = new Element("ds:X509Certificate");
                    el.Content = Util.ToBase64(ch.ChainElements[c].Certificate.GetRawCertData());
                    X509Data.AddElement(el);

                }

            }

            KeyValue = (KeyValue)AddElement(new KeyValue());

            KeyValue.RSAKeyValue.Modulus = Util.ToBase64(GetCertificateModulus());
            KeyValue.RSAKeyValue.Exponent = Convert.ToBase64String(((RSACryptoServiceProvider)Certificate.PublicKey.Key).ExportParameters(false).Exponent);

        }   

        /// <summary>
        /// Devuelve una matriz de bytes con el módulo
        /// del certificado digital.
        /// </summary>
        /// <returns>Módulo del certificado digital.</returns>
        private byte[] GetCertificateModulus()
        {
            return ((RSACryptoServiceProvider)Certificate.PublicKey.Key).ExportParameters(false).Modulus;
        }

    }
}
