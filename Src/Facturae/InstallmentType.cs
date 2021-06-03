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

using Irene.Solutions.Edi.Babel.Xml;
using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Irene.Solutions.Edi.Babel.Facturae
{

    /// <summary>
    /// Vencimiento.
    /// </summary>
    [Serializable()]
    public class InstallmentType
    {

        #region Public Properties

        /// <summary>
        /// Fechas en las que se deben atender los pagos. ISO 8601:2004.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "date")]
        public DateTime InstallmentDueDate { get; set; }

        /// <summary>
        /// Importe a satisfacer en cada plazo. Siempre con dos decimales.
        /// </summary>
        [XmlIgnore()]
        public decimal InstallmentAmount { get; set; }


        /// <summary>
        /// Representación con dos decimales del precio unitario
        /// sin impuestos.
        /// </summary>
        [XmlElement(ElementName = "InstallmentAmount", Form = XmlSchemaForm.Unqualified)]
        public string InstallmentAmountString
        {
            get
            {
                return XmlParser.FromDecimal(InstallmentAmount);
            }
            set
            {
                InstallmentAmount = XmlParser.ToDecimal(value);
            }
        }

        /// <summary>
        /// Cada vencimiento/importe podrá tener un medio de pago concreto.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public PaymentMeansType PaymentMeans { get; set; }

        /// <summary>
        /// Cuenta de abono. Único formato admitido. Cuando la forma de pago 
        /// (PaymentMeans) sea "transferencia" este dato será obligatorio.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AccountType AccountToBeCredited { get; set; }

        /// <summary>
        /// Referencia expresa del pago. Dato que precisa el Emisor para 
        /// conciliar los pagos con cada factura.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PaymentReconciliationReference { get; set; }

        /// <summary>
        /// Cuenta de cargo. Único formato admitido. Cuando la forma de 
        /// pago (PaymentMeans) sea "recibo domiciliado" este dato será 
        /// obligatorio.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AccountType AccountToBeDebited { get; set; }

        /// <summary>
        /// Observaciones de cobro. Libre para uso del Emisor. 
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CollectionAdditionalInformation { get; set; }

        /// <summary>
        /// Válido a partir de la versión 3.2.
        /// Código Estadístico. Usado en las operaciones transfronterizas según las 
        /// especificaciones de la circular del Banco España 15/1992
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RegulatoryReportingData { get; set; }

        /// <summary>
        /// Válido a partir de la versión 3.2.
        /// Referencia del cliente pagador, similar a la utilizada por elemisor 
        /// para la conciliación de los pagos.
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DebitReconciliationReference { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Representación textual de la instancia de InstallmentType.
        /// </summary>
        /// <returns>Representación textual de la instancia de InstallmentType.</returns>
        public override string ToString()
        {
            return $"{InstallmentDueDate}, {InstallmentAmount}";
        }

        #endregion


    }
}
