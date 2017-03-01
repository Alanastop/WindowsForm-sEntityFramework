// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentController.cs" company="DataCommunication">
//  DcProgrammingTutorial 
// </copyright>
// <summary>
//   Defines the IDocumentController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Controllers.Interface
{
    using System.Collections.Generic;

    using DcProgrammingTutorial.Lib.Model.Persistent;

    /// <summary>
    /// The DocumentController interface.
    /// </summary>
    public interface IDocumentController
    {
        /// <summary>
        /// A method that calculates the average balance of our current documents in list.
        /// </summary>
        /// <param name="list">
        /// A list with our current documents.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// Returns the value of the average balance of our documents in list.
        /// </returns>
        double CalculateAverageBalance(IList<Document> list);

        /// <summary>
        /// A method which calculates the tax of the current document.
        /// </summary>
        /// <param name="document">
        /// The selected document name.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// Returns the value of the tax of the selected document.
        /// </returns>
        double CalculateTax(Document document);
    }
}
