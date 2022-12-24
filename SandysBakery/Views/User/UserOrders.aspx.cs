using SandysBakery.BusinessLogic;
using SandysBakery.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SandysBakery.Views.User
{
    public partial class UserOrders : System.Web.UI.Page
    {
        IAdministrator administrator;
        public UserOrders()
        {
            administrator = new Administrator();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsersLogin usersLogin = Session["UsersLogin"] as UsersLogin;
            if (usersLogin != null)
            {
                if (!IsPostBack)
                {
                    LoadItemsInGrid();
                }
            }
            else
            {
                Response.Redirect("~/Views/User/UserRegistration.aspx", true);
            }
        }
        protected void btnCancel_click(object sender, EventArgs e)
        {
            MessageReturnType messageReturnType = new MessageReturnType();
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            messageReturnType = administrator.UpdateOrderStatus(id, 7);
            LoadItemsInGrid();
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + messageReturnType.ReturnMessage + "');", true);

        }
        protected void btnView_click(object sender, EventArgs e)
        {
            DateTime addDate = Convert.ToDateTime((sender as LinkButton).CommandArgument);
            Response.Redirect(string.Format("~/Views/User/UserInvoice.aspx?addDate={0}", addDate));
        }
        private void LoadItemsInGrid()
        {
            UsersLogin usersLogin = Session["UsersLogin"] as UsersLogin;
            DataTable dataTable = administrator.DisplayOrderedItems(usersLogin.UserId, usersLogin.RoleName);
            grdUserOrder.DataSource = dataTable;
            grdUserOrder.DataBind();
        }

        protected void grdUserOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUserOrder.PageIndex = e.NewPageIndex;
            this.LoadItemsInGrid();
        }
    }
}