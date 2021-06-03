using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irene.Solutions.Edi.Babel.Facturae
{

    /// <summary>
    /// Información del contexto de ejecución.
    /// </summary>
    public class Context
    {
        /// <summary>
        /// Formato de importes para los xml.
        /// </summary>
        internal static NumberFormatInfo DefaultNumberFormatInfo = new NumberFormatInfo();

        internal static string DefaultNumberDecimalSeparator = ".";

        /// <summary>
        /// Constructor.
        /// </summary>
        static Context()
        {

            DefaultNumberFormatInfo.CurrencyDecimalSeparator =
              DefaultNumberDecimalSeparator;

            DefaultNumberFormatInfo.NumberDecimalSeparator =
              DefaultNumberDecimalSeparator;

            DefaultNumberFormatInfo.CurrencyDecimalDigits = 2;

            DefaultNumberFormatInfo.NumberDecimalDigits = 2;

            DefaultNumberFormatInfo.CurrencyGroupSeparator = "";

            DefaultNumberFormatInfo.NumberGroupSeparator = "";


        }

    }
}
