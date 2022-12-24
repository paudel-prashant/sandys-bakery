using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SandysBakery.Views.User
{
    public partial class UserInvoice : System.Web.UI.Page
    {
        public DateTime addedDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            addedDate = Convert.ToDateTime(Request.QueryString["addDate"]);
        }
    }
}