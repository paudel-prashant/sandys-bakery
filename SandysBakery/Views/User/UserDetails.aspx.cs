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
    public partial class UserDetails : System.Web.UI.Page
    {
        IUsers users;
        public UserDetails()
        {
            users = new Users();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                MessageReturnType messageReturnType = new MessageReturnType();
                UsersRegistration usersRegistration = new UsersRegistration();
                usersRegistration.FirstName = txtFirstName.Text;
                usersRegistration.MiddleName = txtMiddleName.Text;
                usersRegistration.LastName = txtLastName.Text;
                usersRegistration.EmailId = txtEmail.Text;
                usersRegistration.PhoneNumber = txtPhoneNumber.Text;
                usersRegistration.ShippingAddress = txtShippingAddress.Text;
                
                if (RegistrationId.Value != "")
                {
                    usersRegistration.RegistrationId = Convert.ToInt32(RegistrationId.Value);
                    messageReturnType =  users.EditUsers(usersRegistration);
                }
                if (messageReturnType.IsSuccess)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + messageReturnType.ReturnMessage + "');", true);
                    txtFirstName.Text = "";
                    txtMiddleName.Text = "";
                    txtLastName.Text = "";
                    txtEmail.Text = "";
                    txtPhoneNumber.Text = "";
                    txtShippingAddress.Text = "";
                    Response.Redirect(Request.RawUrl, false);
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = messageReturnType.ReturnMessage;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserDetails();
            }
        }
        private void GetUserDetails()
        {
            var usersLogin = Session["UsersLogin"] as UsersLogin;
            //UsersLogin usersLogin = new UsersLogin();
            grdUserDetails.DataSource = users.UsersList(usersLogin.UserId);
            grdUserDetails.DataBind();
        }
        protected void btnbtnView_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            UsersRegistration usersRegistration = new UsersRegistration();
            usersRegistration = users.GetUserDetailsById(id);
            RegistrationId.Value = Convert.ToString(usersRegistration.RegistrationId);
            txtFirstName.Text = usersRegistration.FirstName;
            txtMiddleName.Text = usersRegistration.MiddleName;
            txtLastName.Text = usersRegistration.LastName;
            txtEmail.Text = usersRegistration.EmailId;
            txtPhoneNumber.Text = usersRegistration.PhoneNumber;
            txtShippingAddress.Text = usersRegistration.ShippingAddress;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl, false);
        }

        protected void grdUserDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUserDetails.PageIndex = e.NewPageIndex;
            this.GetUserDetails();
        }
    }
}