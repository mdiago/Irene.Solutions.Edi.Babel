using Irene.Solutions.Edi.Babel.Facturae.Signature.Xml;

namespace Irene.Solutions.Edi.Babel.Facturae.Signature
{

    /// <summary>
    /// Representa un facturae sin firmar.
    /// </summary>
    public class Facturae : Element
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public Facturae() : base("fe:Facturae")
        {
            AddAttribute("xmlns:ds", "http://www.w3.org/2000/09/xmldsig#");
            AddAttribute("xmlns:fe", "http://www.facturae.es/Facturae/2009/v3.2/Facturae");
        }
    }
}
