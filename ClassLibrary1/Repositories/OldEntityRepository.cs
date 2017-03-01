// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OldEntityRepository.cs" company="DataCommunication">
//   DcProgrammingTutorial
// </copyright>
// <summary>
//   The document provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammingTutorial.Lib.Repositories
{
    #region

    using System;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;

    using DcProgrammingTutorial.Lib.Model;
    using DcProgrammingTutorial.Lib.Model.Persistent;
    using DcProgrammingTutorial.Lib.Properties;

    #endregion

    /// <summary>
    /// The document provider.
    /// </summary>
    [Obsolete]
    public class OldEntityRepository
    {
        /// <summary>
        /// The company list.
        /// </summary>
        // ReSharper disable once StyleCop.SA1401
        public BindingList<Company> CompanyList;

        /// <summary>
        /// The documents list.
        /// </summary>
        private readonly BindingList<Document> documentList;

        /// <summary>
        /// The list container.
        /// </summary>
        private readonly BindingLists listContainer;

        /// <summary>
        /// The document.
        /// </summary>
        private readonly Document myDocument;

        /// <summary>
        /// Initializes a new instance of the <see cref="OldEntityRepository"/> class.
        /// </summary>
        public OldEntityRepository()
        {
            this.CompanyList = new BindingList<Company>();
            this.listContainer = new BindingLists();
            this.documentList = new BindingList<Document>();
            this.myDocument = new Document();
        }

        /// <summary>
        /// Creates a new company.
        /// </summary>
        /// <param name="company">
        /// The new company.
        /// </param>
        public void CreateCompany(Company company)
        {
            var queryString =
                $@"INSERT into Company (Code,Name,Active,Created,CreatedBy,Updated, UpdatedBy, Deleted, DeletedBy) values ('{company.Code}', '{company.Name}', '{company.Active}',
                '{company.Created:yyyyMMdd hh:mm:ss}', '{company.CreatedBy}','{company.Updated:yyyyMMdd hh:mm:ss}', '{company.UpdatedBy}','{company.Deleted:yyyyMMdd hh:mm:ss}', '{company.DeletedBy}')";

            using (var sqlConnection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// A method which creates a new document.
        /// </summary>
        /// <param name="document">
        /// It takes the newly created document as parameter.
        /// </param>
        public void CreateDocument(Document document)
        {
            var queryString =
                $@"INSERT into Document (CompanyID,Code,Name,Balance,Created,CreatedBy,Updated,UpdatedBy,Deleted,DeletedBy) values ('{document.Company.Id}', '{document.Code}', 
                '{document.Name}', '{document.Balance.ToString(CultureInfo.InvariantCulture)}','{document.Created:yyyyMMdd hh:mm:ss}', '{document.CreatedBy}','{document.Updated:yyyyMMdd hh:mm:ss}',
                '{document.UpdatedBy}','{document.Deleted:yyyyMMdd hh:mm:ss}', '{document.DeletedBy}')";

            using (var sqlConnection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes the selected company.
        /// </summary>
        /// <param name="company">
        /// The selected company.
        /// </param>
        public void DeleteCompany(Company company)
        {
            var queryString = $"DELETE FROM Company WHERE ID = '{company.Id}'";

            using (var sqlConnection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();

                    this.myDocument.OnDocumentUpdated();
                }
            }
        }

        /// <summary>
        /// Deletes the selected company from database.
        /// </summary>
        /// <param name="companyCode">
        /// A string which contains the company code.
        /// </param>
        public void DeleteCompany(string companyCode)
        {
            var queryString = $"DELETE FROM Company WHERE Code = '{companyCode}'";

            using (var sqlConnection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes the selected document.
        /// </summary>
        /// <param name="document">
        /// The selected document to be deleted.
        /// document 
        /// </param>
        public void DeleteDocument(Document document)
        {
            var queryString = $"DELETE FROM Document WHERE Id = '{document.Id}'";

            using (var sqlConnection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Reads all companies from database.
        /// </summary>
        /// <returns>
        /// The <see cref="BindingList{Company}"/>.
        /// Returns a list which contains the existing companies in database.
        /// </returns>
        public BindingList<Company> ReadAllCompanies()
        {
            const string QueryString =
                @"Select Company.Id,Company.Code,Company.Name,Company.Created,Company.CreatedBy,Company.Updated,Company.UpdatedBy,Company.Deleted,Company.DeletedBy,Company.Active FROM Company";

            using (var sqlConnection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(QueryString, sqlConnection))
                {
                    this.CompanyList.Clear();
                    sqlConnection.Open();
                    var sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        var company = new Company
                                          {
                                              Id = sqlDataReader.GetInt32(0),
                                              Code = sqlDataReader.GetString(1),
                                              Name = sqlDataReader.GetString(2),
                                              Created = sqlDataReader.GetDateTime(3),
                                              CreatedBy = sqlDataReader.GetString(4),
                                              Active = sqlDataReader.GetBoolean(9)
                                          };

                        if (!sqlDataReader.IsDBNull(5))
                        {
                            company.Updated = sqlDataReader.GetDateTime(5);
                            company.UpdatedBy = sqlDataReader.GetString(6);
                        }

                        if (!sqlDataReader.IsDBNull(7))
                        {
                            company.Deleted = sqlDataReader.GetDateTime(7);
                            company.DeletedBy = sqlDataReader.GetString(8);
                        }

                        this.CompanyList.Add(company);
                    }
                }
            }

            return this.CompanyList;
        }

        /// <summary>
        /// Bings all documents from data base.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// Returns an object which holds a list of documents and a list of companies.
        /// </returns>
        public BindingLists ReadAllDocuments()
        {
            // var sqlConnection = new SqlConnection(Settings.Default.DatabaseConnection);
            const string QueryString =
                @"Select document.Id, document.Code,document.Name,document.Balance,document.Created,document.CreatedBy,
                                document.Updated,document.UpdatedBy,document.Deleted,document.DeletedBy ,Company.Id,Company.Code,Company.Name,
                                Company.Created,Company.CreatedBy,Company.Updated,Company.UpdatedBy,Company.Deleted,Company.DeletedBy,Company.Active
                                From Document inner join Company on Document.CompanyId = Company.Id";

            using (var sqlConnection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(QueryString, sqlConnection))
                {
                    sqlConnection.Open();
                    var sqlDataReader = sqlCommand.ExecuteReader();
                    this.documentList.Clear();
                    this.CompanyList.Clear();

                    while (sqlDataReader.Read())
                    {
                        var companyId = sqlDataReader.GetInt32(10);

                        var company = new Company
                                          {
                                              Id = companyId,
                                              Code = sqlDataReader.GetString(11),
                                              Name = sqlDataReader.GetString(12),
                                              Created = sqlDataReader.GetDateTime(13),
                                              CreatedBy = sqlDataReader.GetString(14),
                                              Active = sqlDataReader.GetBoolean(19)
                                          };

                        if (!sqlDataReader.IsDBNull(15))
                        {
                            company.Updated = sqlDataReader.GetDateTime(15);
                            company.UpdatedBy = sqlDataReader.GetString(16);
                        }

                        if (!sqlDataReader.IsDBNull(17))
                        {
                            company.Deleted = sqlDataReader.GetDateTime(17);
                            company.DeletedBy = sqlDataReader.GetString(18);
                        }
                        
                        var document = new Document
                                           {
                                               Id = sqlDataReader.GetInt32(0),
                                               Code = sqlDataReader.GetString(1),
                                               Name = sqlDataReader.GetString(2),
                                               Balance = sqlDataReader.GetDouble(3),
                                               Created = sqlDataReader.GetDateTime(4),
                                               CreatedBy = sqlDataReader.GetString(5)
                                           };

                        if (!sqlDataReader.IsDBNull(6))
                        {
                            document.Updated = sqlDataReader.GetDateTime(6);
                            document.UpdatedBy = sqlDataReader.GetString(7);
                        }

                        if (!sqlDataReader.IsDBNull(8))
                        {
                            document.Deleted = sqlDataReader.GetDateTime(8);
                            document.DeletedBy = sqlDataReader.GetString(9);
                        }

                        document.Company = company;
                        this.documentList.Add(document);
                    }

                    sqlConnection.Close();
                }
            }

            this.listContainer.DocumentList = this.documentList;
            this.listContainer.CompanyList = this.CompanyList;
            return this.listContainer;
        }

        /// <summary>
        /// Reads one company.
        /// </summary>
        /// <param name="company">
        /// The selected company.
        /// </param>
        public void ReadOneCompany(Company company)
        {
            var queryString = $"Select * FROM Document WHERE ID = '{company.Id}'";

            using (var sqlConnection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes the selected document from database.
        /// </summary>
        /// <param name="document">
        ///  The name of the selected document.
        /// </param>
        /// <returns>
        /// The <see cref="Document"/>.
        /// Returns a document.
        /// </returns>
        public Document ReadOneDocument(Document document)
        {
            return this.ReadAllDocuments().DocumentList.SingleOrDefault(x => x.Code == document.Code);

            // var queryString = $"Select * FROM Document WHERE Id = '{document.Id}'";

            // using (var sqlConnection = new SqlConnection(Settings.Default.DataBaseConnection))
            // {
            // using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
            // {
            // sqlConnection.Open();
            // sqlCommand.ExecuteNonQuery();

            // sqlConnection.Close();
            // }
            // }
        }

        /// <summary>
        /// Updates the company.
        /// </summary>
        /// <param name="company">
        /// The selected company to be updated.
        /// </param>
        public void UpdateCompany(Company company)
        {
            var queryString = @"update Company set Company.Name =  '" + company.Name + "'  where Company.Id =  "
                              + company.Id;

            using (var sqlConnection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates the selected document.
        /// </summary>
        /// <param name="document">
        /// The selected document to be updated.
        /// </param>
        public void UpdateDocument(Document document)
        {
            var queryString =
                $"update Document set Document.Name =  '{document.Name}', Document.Balance = '{document.Balance.ToString(CultureInfo.InvariantCulture)}', Document.Code = '{document.Code}', Document.Updated = '{document.Updated:yyyyMMdd hh:mm:ss}', Document.UpdatedBy = '{document.UpdatedBy}'  where Document.Id = '{document.Id}'";

            using (var sqlConnection = new SqlConnection(Settings.Default.ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}