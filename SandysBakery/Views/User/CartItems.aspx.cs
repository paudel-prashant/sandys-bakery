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
    public partial class CartItems : System.Web.UI.Page
    {
        IAdministrator administrator;
        public bool isExist;
        public CartItems()
        {
            administrator = new Administrator();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsersLogin usersLogin = Session["UsersLogin"] as UsersLogin;
            if (usersLogin != null)
            {
                DataTable dataTable = administrator.DisplayItemsInCart(usersLogin.UserId);
                if (dataTable.Rows.Count > 0)
                {
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }
                if (!IsPostBack)
                {
                    LoadCartOfUser();
                    LoadCardOptions();
                }
            }
            else
            {
                Response.Redirect("~/Views/User/UserRegistration.aspx", true);
            }
        }
        public void LoadCartOfUser()
        {
            UsersLogin usersLogin = Session["UsersLogin"] as UsersLogin;
            DataTable dataTable = administrator.DisplayItemsInCart(usersLogin.UserId);
            grdcart.DataSource = dataTable;
            grdcart.DataBind();
            if (dataTable.Rows.Count > 0)
            {
                decimal total = dataTable.AsEnumerable().Sum(row => row.Field<decimal>("SellingPrice"));
                decimal quantity = dataTable.AsEnumerable().Sum(row => row.Field<int>("Quantity"));
                grdcart.FooterRow.Cells[0].Text = "Total";
                grdcart.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                grdcart.FooterRow.Cells[2].Text = total.ToString("N2");
                grdcart.FooterRow.Cells[1].Text = quantity.ToString("N2");
            }
        }
        protected void btnDelete_click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
                var returnMessage = administrator.RemoveItemsFromCart(id);
                LoadCartOfUser();
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + returnMessage.ReturnMessage + "');", true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                var usersLogin = Session["UsersLogin"] as UsersLogin;
                Order order = new Order();
                order.UserId = usersLogin.UserId;
                order.PaymentType = ddlPaymentOption.SelectedItem.Text.ToLower();
                order.PaymentTypeId = Convert.ToInt32(ddlPaymentOption.SelectedValue);
                if (ddlPaymentType.SelectedValue != "")
                {
                    order.PaymentGatewayId = Convert.ToInt32(ddlPaymentType.SelectedValue);
                }
                else
                {
                    string type = ddlPaymentOption.SelectedItem.Text.ToLower();
                    if (type.Equals("pay by credit card"))
                    {
                        lblmessage.Visible = true;
                        lblmessage.Text = "Payment is required.";
                        return;
                    }
                }
                var returnMessage = administrator.Order(order);
                LoadCartOfUser();
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + returnMessage.ReturnMessage + "');", true);
                Response.Redirect(Request.RawUrl, false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LoadCardOptions()
        {
            DataTable dataTable = administrator.CommonStatus(1);
            ddlPaymentOption.DataTextField = "StatusName";
            ddlPaymentOption.DataValueField = "CommonStatusId";
            ddlPaymentOption.DataSource = dataTable;
            ddlPaymentOption.DataBind();

        }
        private void LoadPaymentOption()
        {
            ddlPaymentType.DataTextField = "CardNumber";
            ddlPaymentType.DataValueField = "PaymentGatewayId";
            var usersLogin = Session["UsersLogin"] as UsersLogin;
            ddlPaymentType.DataSource = administrator.PaymentDetailsByUserId(usersLogin.UserId);
            ddlPaymentType.DataBind();
        }
        protected void ddlPaymentOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = ddlPaymentOption.SelectedItem.Text.ToLower();
            if (type.Equals("pay by credit card"))
            {
                LoadPaymentOption();
                ddlPaymentType.Visible = true;
            }
            else
            {
                ddlPaymentType.Visible = false;
            }
        }
        protected void grdcart_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdcart.PageIndex = e.NewPageIndex;
            this.LoadCartOfUser();
            this.LoadCardOptions();
        }
    }
}