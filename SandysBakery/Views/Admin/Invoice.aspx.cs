using SandysBakery.BusinessLogic;
using SandysBakery.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SandysBakery.Views.Admin
{
    public partial class Invoice : System.Web.UI.Page
    {
        public DateTime addedDate;
        public int UserId;
        IAdministrator administrator;
        public Invoice()
        {
            administrator = new Administrator();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            addedDate = Convert.ToDateTime(Request.QueryString["addDate"]);
            UserId = Convert.ToInt32(Request.QueryString["UserId"]);
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            MessageReturnType messageReturnType = new MessageReturnType();
            messageReturnType = administrator.UpdateOrderStatus(addedDate, UserId, 8);
            Response.Redirect(Request.RawUrl, false);
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + messageReturnType.ReturnMessage + "');", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            MessageReturnType messageReturnType = new MessageReturnType();
            messageReturnType = administrator.UpdateOrderStatus(addedDate, UserId, 7);
            Response.Redirect(Request.RawUrl, false);
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + messageReturnType.ReturnMessage + "');", true);
        }
    }
}