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
    /// Tipo de impuesto.
    /// </summary>
    [Serializable()]
    public enum TaxTypeCodeType
    {

        /// <summary>
        /// IVA: Impuesto sobre el valor añadido
        /// </summary>
        [XmlEnum("01")]
        Item01,

        /// <summary>
        /// IPSI: Impuesto sobre la producción, los servicios y la importación
        /// </summary>
        [XmlEnum("02")]
        Item02,

        /// <summary>
        /// IGIC: Impuesto general indirecto de Canarias
        /// </summary>
        [XmlEnum("03")]
        Item03,

        /// <summary>
        /// IRPF: Impuesto sobre la Renta de las personas físicas
        /// </summary>
        [XmlEnum("04")]
        Item04,

        /// <summary>
        /// Otro
        /// </summary>
        [XmlEnum("05")]
        Item05,

        /// <summary>
        /// ITPAJD: Impuesto sobre transmisiones patrimoniales y actos jurídicos documentados
        /// </summary>
        [XmlEnum("06")]
        Item06,

        /// <summary>
        /// IE: Impuestos especiales
        /// </summary>
        [XmlEnum("07")]
        Item07,

        /// <summary>
        /// Ra: Renta aduanas
        /// </summary>
        [XmlEnum("08")]
        Item08,

        /// <summary>
        /// IGTECM: Impuesto general sobre el tráfico de empresas que se aplica en Ceuta y Melilla
        /// </summary>
        [XmlEnum("09")]
        Item09,

        /// <summary>
        /// IECDPCAC: Impuesto especial sobre los combustibles derivados del petróleo en la Comunidad Autonoma Canaria
        /// </summary>
        [XmlEnum("10")]
        Item10,

        /// <summary>
        /// IIIMAB: Impuesto sobre las instalaciones que inciden sobre el medio ambiente en las Baleares
        /// </summary>
        [XmlEnum("11")]
        Item11,

        /// <summary>
        /// ICIO: Impuesto sobre las construcciones, instalaciones y obras
        /// </summary>
        [XmlEnum("12")]
        Item12,

        /// <summary>
        /// IMVDN: Impuesto municipal sobre las viviendas desocupadas en Navarra
        /// </summary>
        [XmlEnum("13")]
        Item13,

        /// <summary>
        /// IMSN: Impuesto municipal sobre solares en Navarra
        /// </summary>
        [XmlEnum("14")]
        Item14,

        /// <summary>
        /// IMGSN: Impuesto municipal sobre gastos suntuarios en Navarra
        /// </summary>
        [XmlEnum("15")]
        Item15,

        /// <summary>
        /// IMPN: Impuesto municipal sobre publicidad en Navarra
        /// </summary>
        [XmlEnum("16")]
        Item16,

        /// <summary>
        /// REIVA: Régimen especial de IVA para agencias de viajes
        /// </summary>
        [XmlEnum("17")]
        Item17,

        /// <summary>
        /// REIGIC: Régimen especial de IGIC: para agencias de viajes
        /// </summary>
        [XmlEnum("18")]
        Item18,

        /// <summary>
        /// REIPSI: Régimen especial de IPSI para agencias de viajes
        /// </summary>
        [XmlEnum("19")]
        Item19,

        /// <summary>
        /// IPS: Impuestos sobre las primas de seguros
        /// </summary>
        [XmlEnum("20")]
        Item20,

        /// <summary>
        /// RLEA: Recargo destinado a financiar las funciones de liquidación de entidades aseguradoras
        /// </summary>
        [XmlEnum("21")]
        Item21,

        /// <summary>
        /// IVPEE: Impuesto sobre el valor de la producción de la energía eléctrica
        /// </summary>
        [XmlEnum("22")]
        Item22,

        /// <summary>
        /// Impuesto sobre la producción de combustible nuclear gastado y residuos 
        /// radiactivos resultantes de la generación de energía nucleoeléctrica
        /// </summary>
        [XmlEnum("23")]
        Item23,

        /// <summary>
        /// Impuesto sobre el almacenamiento de combustible nuclear gastado y residuos 
        /// radioactivos en instalaciones centralizadas
        /// </summary>
        [XmlEnum("24")]
        Item24,

        /// <summary>
        /// IDEC: Impuesto sobre los Depósitos en las Entidades de Crédito
        /// </summary>
        [XmlEnum("25")]
        Item25,

        /// <summary>
        /// Impuesto sobre las labores del tabaco en la Comunidad Autónoma de Canarias
        /// </summary>
        [XmlEnum("26")]
        Item26,

        /// <summary>
        /// IGFEI: Impuesto sobre los Gases Fluorados de Efecto Invernadero
        /// </summary>
        [XmlEnum("27")]
        Item27,

        /// <summary>
        /// IRNR: Impuesto sobre la Renta de No Residentes
        /// </summary>
        [XmlEnum("28")]
        Item28,

        /// <summary>
        /// Impuesto sobre Sociedades
        /// </summary>
        [XmlEnum("29")]
        Item29,
    }
}
