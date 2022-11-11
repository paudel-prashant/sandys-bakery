using SandysBakery.BusinessLogic;
using SandysBakery.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SandysBakery.Views.User
{
    public partial class UserLogin : System.Web.UI.Page
    {
        IUsers users;
        public UserLogin()
        {
            users = new Users();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.User.Identity.IsAuthenticated)
            {
                var usersLogin = Session["UsersLogin"] as UsersLogin;
                if (usersLogin != null)
                {
                    if (usersLogin.RoleName == "User")
                    {
                        Response.Redirect("~/Views/Home.aspx", true);
                    }
                    else
                    {
                        Response.Redirect(FormsAuthentication.GetRedirectUrl(usersLogin.UserName, true));
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsersLogin usersLoginModel = new UsersLogin();
            usersLoginModel.UserName = txtUserName.Text;
            usersLoginModel.UserPassword = new DataAccess.Adaptors.Helper().Encrypt(txtPassword.Text);
            UsersLogin usersLogin = users.UserLogin(usersLoginModel);
            if (usersLogin != null)
            {
                Session["UsersLogin"] = usersLogin;
                FormsAuthenticationTicket formsAuthenticationTicket = new FormsAuthenticationTicket(1, usersLogin.UserName, DateTime.Now, DateTime.Now.AddMinutes(10), true, usersLogin.RoleName, FormsAuthentication.FormsCookiePath);
                string hash = FormsAuthentication.Encrypt(formsAuthenticationTicket);
                HttpCookie httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                if (formsAuthenticationTicket.IsPersistent)
                {
                    httpCookie.Expires = formsAuthenticationTicket.Expiration;
                }
                Response.Cookies.Add(httpCookie);
                if (usersLogin.RoleName == "Administrator")
                {
                    Response.Redirect(FormsAuthentication.GetRedirectUrl(usersLogin.UserName, true));
                }
                else
                {
                    Response.Redirect("~/Views/Home.aspx", true);
                }
            }
        }
    }
}