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
    public partial class ManageOrder : System.Web.UI.Page
    {
        IAdministrator administrator; 
        public ManageOrder()
        {
            administrator = new Administrator();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadItemsInGrid();
            }
        }
        private void LoadItemsInGrid()
        {
            UsersLogin usersLogin = Session["UsersLogin"] as UsersLogin;
            DataTable dataTable = administrator.DisplayOrderedItems(usersLogin.UserId, usersLogin.RoleName);
            grdUserOrder.DataSource = dataTable;
            grdUserOrder.DataBind();
        }
        protected void btnView_click(object sender, EventArgs e)
        {
            string[] commandArgs = ((sender as LinkButton).CommandArgument).Split(new char[] { ',' });
            DateTime addDate = Convert.ToDateTime(commandArgs[0]);
            int UserId = Convert.ToInt32(commandArgs[1]);
            Response.Redirect(string.Format("~/Views/Admin/Invoice.aspx?addDate={0}&&UserId={1}", addDate, UserId));
        }

        protected void grdUserOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUserOrder.PageIndex = e.NewPageIndex;
            this.LoadItemsInGrid();
        }
    }
}