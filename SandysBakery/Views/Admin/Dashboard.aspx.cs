using SandysBakery.BusinessLogic;
using SandysBakery.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SandysBakery.Views.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        IAdministrator administrator;
        public Dashboard()
        {
            administrator = new Administrator();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OrderedItems();
            }
        }
        protected void OrderedItems()
        {
            UsersLogin usersLogin = Session["UsersLogin"] as UsersLogin;
            DataTable dataTable = administrator.DisplayOrderedItems(usersLogin.UserId, usersLogin.RoleName, "Dashboard");
            grdUserOrder.DataSource = dataTable;
            grdUserOrder.DataBind();
        }
        protected void grdUserOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUserOrder.PageIndex = e.NewPageIndex;
            this.OrderedItems();
        }
    }
}