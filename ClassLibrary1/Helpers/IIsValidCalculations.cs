// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIsValidCalculations.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The IsValidCalculations interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Helpers
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The IsValidCalculations interface.
    /// </summary>
    public interface IIsValidCalculations
    {
        /// <summary>
        /// The calculate.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Calculate(string param);

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
        bool Calculate(string param, Func<string, bool> func);
    }
}