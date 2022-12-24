using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SandysBakery.Views
{
    public partial class Home : System.Web.UI.Page
    {
        public int categoryId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
        }
    }
}