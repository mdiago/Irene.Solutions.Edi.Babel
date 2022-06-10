using Irene.Solutions.Edi.Babel.Facturae.Signature.Xml;

namespace Irene.Solutions.Edi.Babel.Facturae.Signature
{

    /// <summary>
    /// Representa un facturae sin firmar.
    /// </summary>
    public class Facturae : Element
    {
        string _NsVersion;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nsVersion">Por defecto versión 3.2</param>
        public Facturae(string nsVersion = "http://www.facturae.es/Facturae/2009/v3.2/Facturae") : base("fe:Facturae")
        {
            AddAttribute("xmlns:ds", "http://www.w3.org/2000/09/xmldsig#");
            AddAttribute("xmlns:fe", nsVersion);
            _NsVersion = nsVersion;
        }

        /// <summary>
        /// Devuelve el espacio de nombres de la versión.
        /// </summary>
        /// <returns>Espacio de nombres de la versión.</returns>
        public virtual string GetVersionNamespace()
        {
            return _NsVersion;
        }


    }
}
