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
    public partial class ProductDetails : System.Web.UI.Page
    {
        public int productItemsId = 0;
        IAdministrator administrator;
        public ProductDetails()
        {
            administrator = new Administrator();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            productItemsId = Convert.ToInt32(Request.QueryString["ProductItemsId"]);
            if (productItemsId == 0)
            {
                Response.Redirect("~/Views/Home.aspx", true);
            }
        }
        protected void dtnAddCard_Click(object sender, EventArgs e)
        {
            MessageReturnType messageReturnType = new MessageReturnType();
            if (this.Page.User.Identity.IsAuthenticated)
            {
                try
                {
                    CartItems cartItems = new CartItems();
                    var usersLogin = Session["UsersLogin"] as UsersLogin;
                    cartItems.ProductItemsId = Convert.ToInt32(ProductItemsId.Value);
                    cartItems.UserId = usersLogin.UserId;
                    cartItems.Quantity = 1;
                    var returnMessageMode = administrator.AddItemsToCart(cartItems);
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + returnMessageMode.ReturnMessage + "');", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + ex.Message + "');", true);
                }
            }
            else
            {
                Response.Redirect("~/Views/User/UserLogin.aspx", true);
            }
        }
    }
}