using SandysBakery.BusinessLogic;
using SandysBakery.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SandysBakery.Views.User
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        IUsers users = null;
        public UserRegistration()
        {
            users = new Users();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                MessageReturnType messageReturnType = new MessageReturnType();
                UsersRegistration usersRegistration = new UsersRegistration();
                usersRegistration.FirstName = txtFirstName.Text;
                usersRegistration.MiddleName = txtMiddleName.Text;
                usersRegistration.LastName = txtLastName.Text;
                usersRegistration.EmailId = txtEmail.Text;
                usersRegistration.UserLogin.UserPassword = txtPassword.Text;
                usersRegistration.PhoneNumber = txtPhoneNumber.Text;
                usersRegistration.ShippingAddress = txtShippingAddress.Text;

                messageReturnType = users.UserRegistration(usersRegistration);
                lblMessage.Visible = true;
                lblMessage.Text = messageReturnType.ReturnMessage;
                
                if (messageReturnType.IsSuccess)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("~/Views/User/UserLogin.aspx");
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    Page.ClientScript.RegisterStartupScript(
                                                            Page.GetType(),
                                                            "MessageBox",
                                                            "<script language='javascript'>alert('" + messageReturnType.ReturnMessage + "');</script>"
           );
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ex.Message.ToString() + "');", true);
            }
        }
    }
}