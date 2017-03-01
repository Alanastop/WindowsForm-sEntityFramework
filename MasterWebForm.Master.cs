// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasterWebForm.Master.cs" company="Data Communication">
//   DC Tutorial
// </copyright>
// <summary>
//   The master web form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DcProgrammimgTutorialWebForm
{
    #region

    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    using DcProgrammingTutorial.Lib.Controllers;
    using DcProgrammingTutorial.Lib.Enums;
    using DcProgrammingTutorial.Lib.Model;
    using DcProgrammingTutorial.Lib.Model.Persistent;

    #endregion

    /// <summary>
    /// The master web form.
    /// </summary>
    public partial class MasterWebForm : MasterPage
    {
        /// <summary>
        /// The entity user controller.
        /// </summary>
        private EntityUserController entityUserController;

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var currentUser = this.Session["user"] as User;
                if (currentUser == null)
                {
                    this.entityUserController = new EntityUserController();
                    var currentUserName = Environment.UserName;
                    currentUser = this.entityUserController.GetUserByUserName(currentUserName);
                    if (currentUser == null)
                    {
                        var user = new User { Name = currentUserName };
                        try
                        {
                            currentUser = this.entityUserController.CreateOrUpdateEntity(user);
                        }
                        catch (SqlException ex)
                        {
                            Logger.AddLog(ex.Message, ErrorTypes.Error, DateTime.Now);
                            return;
                        }
                    }

                    this.Session["user"] = currentUser;
                }
            }
        }
    }
}