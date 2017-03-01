// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VatCalculation.cs" company="Data Communication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The vat calculation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Helpers
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The vat calculation.
    /// </summary>
    public class VatCalculation : IIsValidCalculations
    {
        /// <summary>
        /// The calculate vat func.
        /// </summary>
        private readonly Func<string, bool> calculateVatFunc = (vat) =>
            {
                int number;
                if (vat.Length != 9)
                {
                    return false;
                }

                if (!int.TryParse(vat, out number))
                {
                    return false;
                }

                var temp = number / 10;
                var sum = 0;
                for (var i = 2; i < 257; i = i * 2)
                {
                    sum += (temp % 10) * i;
                    temp = temp / 10;
                }

                var temp2 = sum % 11 % 10;
                return temp2 == number % 10;
            };

        /// <summary>
        /// The calculate.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Calculate(string param)
        {
            return this.calculateVatFunc.Invoke(param);
        }

        /// <summary>
        /// The calculate.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        /// <param name="func">
        /// The func.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Calculate(string param, Func<string, bool> func)
        {
            return func.Invoke(param);
        }
    }
}