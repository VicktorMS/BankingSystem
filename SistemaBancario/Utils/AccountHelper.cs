using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaBancario.Utils
{
    public static class AccountHelper
    {
        public static double StringToDouble(string value)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            double result;
            if (double.TryParse(value, NumberStyles.Number, culture, out result))
            {
                return result;
            }
            throw new ArgumentException("A string não pode ser convertida em um valor double.");
        }

        public static double DolarToReal(double value)
        {
            double exchangeRate = 4.38;
            double result = value * exchangeRate;
            return Math.Round(result, 2);
        }
        public static double RealToDolar(double value)
        {
            double exchangeRate = 4.38;
            double result = value / exchangeRate;
            return Math.Round(result, 2);
        }
    }
}
