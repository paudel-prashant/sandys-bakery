using SandysBakery.BusinessLogic;
using SandysBakery.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SandysBakery.Views
{
    public partial class Feedbacks : System.Web.UI.Page
    {
        IAdministrator administrator;
        public Feedbacks()
        {
            administrator = new Administrator();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                MessageReturnType messageReturnType = new MessageReturnType(); 
                Feedback feedback = new Feedback();
                feedback.FullName = txtFullName.Text;
                feedback.Email = txtEmail.Text;
                feedback.Comment = txtComment.Text;
                UsersLogin usersLogin = Session["UsersLogin"] as UsersLogin;
                if (usersLogin != null)
                {
                    feedback.UserId = usersLogin.UserId;
                }
                messageReturnType = administrator.AddFeedback(feedback);
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + messageReturnType.ReturnMessage + "');", true);
                Response.Redirect(Request.RawUrl, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}