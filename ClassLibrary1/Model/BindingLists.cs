// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BindingLists.cs" company="DataCommunication">
// DcProgrammingTutorial  
// </copyright>
// <summary>
//   Defines the BindingLists type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Model
{
    using System;
    using System.ComponentModel;

    using DcProgrammingTutorial.Lib.Model.Persistent;

    /// <summary>
    /// A class which contains the list of documents and the list of companies.
    /// </summary>
    [Obsolete]
    public class BindingLists
    {
        /// <summary>
        /// Gets or sets the document list.
        /// </summary>
        public BindingList<Document> DocumentList { get; set; }

        /// <summary>
        /// Gets or sets the company list.
        /// </summary>
        public BindingList<Company> CompanyList { get; set; }
    }
}
