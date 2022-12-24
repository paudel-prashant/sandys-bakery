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
    public partial class UserPaymentOptions : System.Web.UI.Page
    {
        IAdministrator administrator;
        public UserPaymentOptions()
        {
            administrator = new Administrator();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPaymentOptions();
                LoadCardOptions();
            }
        }
        protected void btnPaymentOption_Click(object sender, EventArgs e)
        {
            MessageReturnType messageReturnType = new MessageReturnType();
            if (this.Page.User.Identity.IsAuthenticated)
            {
                try
                {
                    PaymentGateway paymentGateway = new PaymentGateway();
                    var usersLogin = Session["UsersLogin"] as UsersLogin;
                    paymentGateway.CardNumber = Convert.ToInt32(txtCardNumber.Text);
                    paymentGateway.UserId = usersLogin.UserId;
                    paymentGateway.CardTypeId = Convert.ToInt32(ddlPaymentOption.SelectedValue);
                    paymentGateway.CardName = txtNameOnCard.Text;
                    paymentGateway.ExpiryDate = Convert.ToDateTime(txtExpiryDate.Text);
                    paymentGateway.PostalCode = txtPostalCode.Text;
                    paymentGateway.SecurityCode = Convert.ToInt32(txtSecurityCode.Text);
                    if (HdPaymentGetwayId.Value != "")
                    {
                        paymentGateway.PaymentGatewayId = Convert.ToInt32(HdPaymentGetwayId.Value);
                        messageReturnType = administrator.EditPaymentOptions(paymentGateway);
                    }
                    else
                    {
                        messageReturnType = administrator.AddPaymentOptions(paymentGateway);
                    }
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + messageReturnType.ReturnMessage + "');", true);
                    Response.Redirect(Request.RawUrl, false);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ex.Message + "');", true);
                }
            }
            else
            {
                Response.Redirect("~/View/User/UserRegistration.aspx", true);
            }
        }
        protected void btnbtnView_Click(object sender, EventArgs e)
        {

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            PaymentGateway paymentGateway = new PaymentGateway();
            paymentGateway = administrator.GetPaymentGatewayById(id);
            HdPaymentGetwayId.Value = id.ToString();
            txtCardNumber.Text = paymentGateway.CardNumber.ToString();
            ddlPaymentOption.SelectedValue = paymentGateway.CardTypeId.ToString();
            txtNameOnCard.Text = paymentGateway.CardName;
            txtExpiryDate.Text = paymentGateway.ExpiryDate.ToString();
            txtPostalCode.Text = paymentGateway.PostalCode.ToString();
            txtSecurityCode.Text = paymentGateway.SecurityCode.ToString();
        }
        private void LoadCardOptions()
        {
            DataTable dataTable = administrator.CommonStatus(3);
            ddlPaymentOption.DataTextField = "StatusName";
            ddlPaymentOption.DataValueField = "CommonStatusId";
            ddlPaymentOption.DataSource = dataTable;
            ddlPaymentOption.DataBind();

        }
        private void LoadPaymentOptions()
        {
            var usersLogin = Session["UsersLogin"] as UsersLogin;
            grdPayoption.DataSource = administrator.PaymentDetailsByUserId(usersLogin.UserId);
            grdPayoption.DataBind();
        }

        protected void grdPayoption_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPayoption.PageIndex = e.NewPageIndex;
            this.LoadPaymentOptions();
            this.LoadCardOptions();
        }
    }
}