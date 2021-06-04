using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irene.Solutions.Edi.Babel.Facturae.Ns
{

    /// <summary>
    /// Espacios de nombre de facturae.
    /// </summary>
    public static class Namespaces
    {

        /// <summary>
        /// Firma digital xml.
        /// </summary>
        public static readonly string Xsig = "http://www.w3.org/2000/09/xmldsig#";


        /// <summary>
        /// Facturae versión 3.0
        /// </summary>
        public static readonly string V30 = "http://www.facturae.es/Facturae/2007/v3.0/Facturae";

        /// <summary>
        /// Facturae versión 3.0
        /// </summary>
        public static readonly string V31 = "http://www.facturae.es/Facturae/2007/v3.1/Facturae";

        /// <summary>
        /// Facturae versión 3.0
        /// </summary>
        public static readonly string V32 = "http://www.facturae.es/Facturae/2009/v3.2/Facturae";

        /// <summary>
        /// Facturae versión 3.0
        /// </summary>
        public static readonly string V322 = "http://www.facturae.gob.es/formato/Versiones/Facturaev3_2_2.xml";

        /// <summary>
        /// Espacios de nombres por tipo.
        /// </summary>
        static readonly Dictionary<Type, string> _NamespacesByType = new Dictionary<Type, string>() 
        {
            { typeof(Irene.Solutions.Edi.Babel.Facturae.V30.Facturae), V30},
            { typeof(Irene.Solutions.Edi.Babel.Facturae.V31.Facturae), V31},
            { typeof(Irene.Solutions.Edi.Babel.Facturae.V32.Facturae), V32},
            { typeof(Irene.Solutions.Edi.Babel.Facturae.V322.Facturae), V322},
        };

        /// <summary>
        /// Devuelve el espacio de nombres apropiado para una tipo.
        /// </summary>
        /// <param name="type">tipo.</param>
        /// <returns>Espacio de nombres apropiado para una tipo.</returns>
        public static string GetNamespace(Type type) 
        {

            if (!_NamespacesByType.ContainsKey(type))
                throw new ArgumentException($"No namespace for type {type}.");

            return _NamespacesByType[type];

        }

    }
}
